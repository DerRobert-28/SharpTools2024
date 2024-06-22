namespace SharpTools2024.UnitTests.NegativeTests;

using SharpTools2024;
using SharpTools2024.UnitTests.Helpers;

public class SizeOfTests: SizeOfHelper {

	[Test]
	public void Bits_ShouldNotBe_Bytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		var result = sizeOf.inBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}

}
