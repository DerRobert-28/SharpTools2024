namespace SharpTools2024.UnitTests.SizeOfTests;

using SharpTools2024;
using SharpTools2024.UnitTests.Helpers;

public class LimitTests : SizeOfHelper {

	[Test]
	public void BitSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		var result = sizeOf.inBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void ByteSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size);
		var result = sizeOf.inBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void KiloBitSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size);
		var result = sizeOf.inKBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void KiloByteSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size);
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.KiloBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void MegaBitSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBits(size);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void MegaByteSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBytes(size);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void GigaBitSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBits(size);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inGBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void GigaByteSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBytes(size);
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void TeraBitSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.TBits(size);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inTBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}

	[Test]
	public void TeraByteSizeShouldBeExact() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.TBytes(size);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inTBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
		//
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.Not.EqualTo(size - 1));
		Assert.That(result, Is.Not.EqualTo(size + 1));
	}
}
