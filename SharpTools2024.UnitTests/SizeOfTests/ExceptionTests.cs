namespace SharpTools2024.UnitTests.SizeOfTests;

using SharpTools2024;
using SharpTools2024.Exceptions;
using SharpTools2024.UnitTests.Helpers;
using System;
using System.Reflection;

public class ExceptionTests: SizeOfHelper {

	private const BindingFlags PRIVATE
		= BindingFlags.Static | BindingFlags.NonPublic;
	
	private const string TEST_ERROR_MESSAGE
		= "Test error message";

	[Test]
	public void NegativeBitSizeShouldThrowException()
		=> negativeSizeShouldThrowException(SizeOf.Bits, "Negative bit size should throw an exception");

	[Test]
	public void NegativeByteSizeShouldThrowAnException()
		=> negativeSizeShouldThrowException(SizeOf.Bytes, "Negative byte size should throw an exception");

	[Test]
	public void AssumeShouldThrowException() {
		var result = shouldThrowException("assume", [true, TEST_ERROR_MESSAGE], "Assume should throw an exception");
		Assert.That(result, Is.EqualTo(TEST_ERROR_MESSAGE));
	}

	[Test]
	public void AssumeShouldNotThrowException()
		=> shouldNotThrowException("assume", [false, string.Empty]);

	[Test]
	public void DivisionShouldNotThrowException() {
		var size = fetchRandomSize();
		var factor = fetchRandomSize();
		shouldNotThrowException("divide", [size, factor]);
	}

	[Test]
	public void DivisionWithNegativeSizeShouldThrowException() {
		var negativeSize = -fetchRandomSize();
		var factor = fetchRandomSize();
		divisionWithNegativeValuesShouldThrowException(negativeSize, factor, "size");
	}

	[Test]
	public void DivisionWithNegativeFactorShouldThrowException() {
		var size = fetchRandomSize();
		var negativeFactor = -fetchRandomSize();
		divisionWithNegativeValuesShouldThrowException(size, negativeFactor, "factor");
	}

	//
	//	PRIVATE FUNCTIONS:
	//
	
	private void divisionWithNegativeValuesShouldThrowException(long size, long factor, string which) {
		var message = $"Division with negative {which.ToLower()} should throw an Exception";
		var result = shouldThrowException("divide", [size, factor], message);
		Assert.That(result.ToLower().StartsWith(which.ToLower()), Is.True);
	}

	private MethodInfo expectPrivateMethod(string methodName) {
		var sizeOfType = typeof(SizeOf);
		var method = sizeOfType.GetMethod(methodName, PRIVATE);
		Assert.That(method, Is.Not.Null);
		return method;
	}

	private void negativeSizeShouldThrowException(Func<long, SizeOf> callback, string message) {
		var negativeSize = -fetchRandomSize();
		try {
			var sizeOf = callback(negativeSize);
			Assert.Fail(message);
		}
		catch(Exception ex) {
			var actualType = ex.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
		}
	}

	private void shouldNotThrowException(string methodName, object[] parameters) {
		var method = expectPrivateMethod(methodName);
		try {
			method.Invoke(null, parameters);
		}
		catch {
			Assert.Fail($"Method '{methodName}' should not throw an exception.");
		}
	}

	private string shouldThrowException(string methodName, object[] parameters, string message) {
		var method = expectPrivateMethod(methodName);
		try {
			method.Invoke(null, parameters);
			Assert.Fail(message);
			return string.Empty;
		}
		catch(Exception ex) {
			var innerException = ex.InnerException;
			Assert.That(innerException, Is.Not.Null);
			//
			var actualType = innerException.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
			return innerException.Message;
		}
	}
}
