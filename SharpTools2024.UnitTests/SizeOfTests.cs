namespace SharpTools2024.UnitTests;

using SharpTools2024;

public class SizeOfTests
{
	[Test]
	public void BitsShouldStayBits()
	{
		var bits = SizeOf.Bits(12);
		var result = bits.inBits();
		Assert.That(result, Is.EqualTo(12));
	}
}
