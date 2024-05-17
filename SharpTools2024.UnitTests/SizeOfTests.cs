namespace SharpTools2024.UnitTests;

using Xunit;
using SharpTools2024;

public class SizeOfTests
{
	[Fact]
	public void BitsShouldStayBits()
	{
		var bits = SizeOf.Bits(12);
		var result = bits.inBits();
		Assert.Equal(12, result);
	}
}
