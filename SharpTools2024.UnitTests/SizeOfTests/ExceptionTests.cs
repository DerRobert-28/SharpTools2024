namespace SharpTools2024.UnitTests.SizeOfTests;

using SharpTools2024;
using SharpTools2024.Exceptions;
using SharpTools2024.UnitTests.Helpers;
using System.Reflection;

public class ExceptionTests: SizeOfHelper {

	private const BindingFlags Private = BindingFlags.NonPublic;

	[Test]
	public void NegativeBitSizeShouldThrowAnException() {
		var negativeSize = -fetchRandomSize();
		try {
			var sizeOf = SizeOf.Bits(negativeSize);
		}
		catch(Exception ex) {
			var expectedType = typeof(SizeOfException);
			var actualType = ex.GetType();
			Assert.That(
				actualType,
				Is.EqualTo(expectedType)
			);
			Assert.That(
				ex.Message,
				Is.EqualTo("Size must not be to negative.")
			);
		}
		Assert.Fail("Negative bit size should throw an exception.");
	}

	[Test]
	public void NegativeByteSizeShouldThrowAnException() {
		var negativeSize = -fetchRandomSize();
		try {
			var sizeOf = SizeOf.Bytes(negativeSize);
		}
		catch(Exception ex) {
			var expectedType = typeof(SizeOfException);
			var actualType = ex.GetType();
			Assert.That(
				actualType,
				Is.EqualTo(expectedType)
			);
			Assert.That(
				ex.Message,
				Is.EqualTo("Size must not be to negative.")
			);
		}
		Assert.Fail("Negative byte size should throw an exception.");
	}

	[Test]
	public void AssumeShouldThrowException() {
		var assume = expectPrivateMethod("assume");

	}

	[Test]
	public void DivideTest() {
		var divide = expectPrivateMethod("divide");

	}

	//
	//	PRIVATE FUNCTIONS:
	//

	private MethodInfo expectPrivateMethod(string methodName) {
		var sizeOfType = typeof(SizeOf);
		var method = sizeOfType.GetMethod(methodName, Private);
		Assert.That(method, Is.Not.Null);
		return method;
	}
}
