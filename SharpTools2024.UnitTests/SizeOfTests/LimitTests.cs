namespace SharpTools2024.UnitTests.SizeOfTests;

using SharpTools2024;
using SharpTools2024.UnitTests.Helpers;

public class LimitTests: SizeOfHelper {

	[Test]
	public void BitSizeShouldBeExact()
		=> shouldBeExactFor(SizeOf.Bits, size => size.inBits);

	[Test]
	public void ByteSizeShouldBeExact()
		=> shouldBeExactFor(SizeOf.Bytes, size => size.inBytes);

	[Test]
	public void KiloBitSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.KBits, size => size.inKBits);
		shouldBeExactFor(SizeOf.KBits, size => size.inKiloBits);
		shouldBeExactFor(SizeOf.KiloBits, size => size.inKBits);
		shouldBeExactFor(SizeOf.KiloBits, size => size.inKiloBits);
	}

	[Test]
	public void KiloByteSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.KBytes, size => size.inKBytes);
		shouldBeExactFor(SizeOf.KBytes, size => size.inKiloBytes);
		shouldBeExactFor(SizeOf.KiloBytes, size => size.inKBytes);
		shouldBeExactFor(SizeOf.KiloBytes, size => size.inKiloBytes);
	}

	[Test]
	public void MegaBitSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.MBits, size => size.inMBits);
		shouldBeExactFor(SizeOf.MBits, size => size.inMegaBits);
		shouldBeExactFor(SizeOf.MegaBits, size => size.inMBits);
		shouldBeExactFor(SizeOf.MegaBits, size => size.inMegaBits);
	}

	[Test]
	public void MegaByteSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.MBytes, size => size.inMBytes);
		shouldBeExactFor(SizeOf.MBytes, size => size.inMegaBytes);
		shouldBeExactFor(SizeOf.MegaBytes, size => size.inMBytes);
		shouldBeExactFor(SizeOf.MegaBytes, size => size.inMegaBytes);
	}

	[Test]
	public void GigaBitSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.GBits, size => size.inGBits);
		shouldBeExactFor(SizeOf.GBits, size => size.inGigaBits);
		shouldBeExactFor(SizeOf.GigaBits, size => size.inGBits);
		shouldBeExactFor(SizeOf.GigaBits, size => size.inGigaBits);
	}

	[Test]
	public void GigaByteSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.GBytes, size => size.inGBytes);
		shouldBeExactFor(SizeOf.GBytes, size => size.inGigaBytes);
		shouldBeExactFor(SizeOf.GigaBytes, size => size.inGBytes);
		shouldBeExactFor(SizeOf.GigaBytes, size => size.inGigaBytes);
	}

	[Test]
	public void TeraBitSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.TBits, size => size.inTBits);
		shouldBeExactFor(SizeOf.TBits, size => size.inTeraBits);
		shouldBeExactFor(SizeOf.TeraBits, size => size.inTBits);
		shouldBeExactFor(SizeOf.TeraBits, size => size.inTeraBits);
	}

	[Test]
	public void TeraByteSizeShouldBeExact() {
		shouldBeExactFor(SizeOf.TBytes, size => size.inTBytes);
		shouldBeExactFor(SizeOf.TBytes, size => size.inTeraBytes);
		shouldBeExactFor(SizeOf.TeraBytes, size => size.inTBytes);
		shouldBeExactFor(SizeOf.TeraBytes, size => size.inTeraBytes);
	}

	//
	// PRIVATE FUNCTIONS:
	//

	private void shouldBeExactFor(Func<long, SizeOf> constructor, Func<SizeOf, Func<long>> callback) {
		var size = fetchRandomSize();
		var sizeOf = constructor(size);
		var result = callback(sizeOf)();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}
}
