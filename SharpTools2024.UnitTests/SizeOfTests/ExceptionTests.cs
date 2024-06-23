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
	public void NegativeBitSizeShouldThrowException() {
		var negativeSize = -fetchRandomSize();
		try {
			var sizeOf = SizeOf.Bits(negativeSize);
			Assert.Fail("Negative bit size should throw an exception");
		}
		catch(Exception ex) {
			var actualType = ex.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
		}
	}

	[Test]
	public void NegativeByteSizeShouldThrowAnException() {
		var negativeSize = -fetchRandomSize();
		try {
			var sizeOf = SizeOf.Bytes(negativeSize);
			Assert.Fail("Negative byte size should throw an exception");
		}
		catch(Exception ex) {
			var actualType = ex.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
		}
	}

	[Test]
	public void AssumeShouldThrowException() {
		var assume = expectPrivateMethod("assume");
		try {
			assume.Invoke(null, [true, TEST_ERROR_MESSAGE]);
			Assert.Fail("Assume should throw an exception");
		}
		catch(Exception ex) {
			var innerException = ex.InnerException;
			Assert.That(innerException, Is.Not.Null);
			//
			var actualType = innerException.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
		}
	}

	[Test]
	public void AssumeShouldNotThrowException() {
		var assume = expectPrivateMethod("assume");
		try {
			assume.Invoke(assume, [false, TEST_ERROR_MESSAGE]);
		}
		catch {
			Assert.Fail("Assume should not throw an exception.");
		}
	}

	[Test]
	public void DivisionShouldNotThrowException() {
		var divide = expectPrivateMethod("divide");
		var size = fetchRandomSize();
		var factor = fetchRandomSize();
		try {
			divide.Invoke(null, [size, factor]);
		}
		catch {
			Assert.Fail("Division should not throw an exception");
		}
	}

	[Test]
	public void DivisionWithNegativeSizeShouldThrowException() {
		var divide = expectPrivateMethod("divide");
		var negativeSize = -fetchRandomSize();
		var factor = fetchRandomSize();
		try {
			divide.Invoke(null, [negativeSize, factor]);
			Assert.Fail("Division with negative size should throw an Exception");
		}
		catch(Exception ex) {
			var innerException = ex.InnerException;
			Assert.That(innerException, Is.Not.Null);
			//
			var actualMessage = innerException.Message;
			var actualType = innerException.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
			Assert.That(actualMessage.StartsWith("Size "), Is.True);
		}
	}

	[Test]
	public void DivisionWithNegativeFactorShouldThrowException() {
		var divide = expectPrivateMethod("divide");
		var size = fetchRandomSize();
		var negativeFactor = -fetchRandomSize();
		try {
			divide.Invoke(null, [size, negativeFactor]);
			Assert.Fail("Division with negative factor should throw an Exception");
		}
		catch(Exception ex) {
			var innerException = ex.InnerException;
			Assert.That(innerException, Is.Not.Null);
			//
			var actualMessage = innerException.Message;
			var actualType = innerException.GetType();
			var expectedType = typeof(SizeOfException);
			Assert.That(actualType, Is.EqualTo(expectedType));
			Assert.That(actualMessage.StartsWith("Factor "), Is.True);
		}
	}

	//
	//	PRIVATE FUNCTIONS:
	//

	private MethodInfo expectPrivateMethod(string methodName) {
		var sizeOfType = typeof(SizeOf);
		var method = sizeOfType.GetMethod(methodName, PRIVATE);
		Assert.That(method, Is.Not.Null);
		return method;
	}
}
