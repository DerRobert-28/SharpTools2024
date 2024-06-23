namespace SharpTools2024.UnitTests.NegativeTests;

using SharpTools2024;
using SharpTools2024.UnitTests.Helpers;

public class SizeOfTestsForUnits: SizeOfHelper {
	
	[Test]
	public void Bits_ShouldNotBe_Bytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		var result = sizeOf.inBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_KiloBits() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inKBits();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_KiloBytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_MegaBits() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inMBits();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_MegaBytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_GigaBits() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inGBits();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_GigaBytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}
	
	[Test]
	public void Bits_ShouldNotBe_TeraBits() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inTBits();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.Not.EqualTo(size));
	}

	[Test]
	public void Bits_ShouldNotBe_TeraBytes() {
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		//
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.Not.EqualTo(size));
		//
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.Not.EqualTo(size));
	}
}
