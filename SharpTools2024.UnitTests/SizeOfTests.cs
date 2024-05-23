using System.Dynamic;

namespace SharpTools2024.UnitTests;

using NUnit.Framework.Constraints;
using SharpTools2024;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;

public class SizeOfTests
{
	private const long
		BITS_PER_BYTE = 8,
		BYTES_PER_KBIT = 128,
		THOUSAND = 1024,
		MILLION = THOUSAND * THOUSAND,
		BILLION = THOUSAND * MILLION,
		TRILLION = THOUSAND * BILLION;

	 private readonly Random RandomSize = new();

//	########################
//	##                    ##
//	##  Bit-to-Bit-Tests  ##
//	##                    ##
//	########################
	
	[Test]
	public void Bits_ShouldBe_Bits()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size);
		var result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void KiloBits_ShouldBe_BitsTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * THOUSAND);
		var result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * THOUSAND);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}
	
	[Test]
	public void KiloBits_ShouldBe_KiloBits()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size);
		var result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void MegaBits_ShouldBe_BitsTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * MILLION);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * MILLION);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}

	[Test]
	public void MegaBits_ShouldBe_KiloBitsTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * THOUSAND);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * THOUSAND);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * THOUSAND);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * THOUSAND);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}

	[Test]
	public void MegaBits_ShouldBe_MegaBits()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBits(size);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void GigaBits_ShouldBe_BitsTimes1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * BILLION);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * BILLION);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
	}

	[Test]
	public void GigaBits_ShouldBe_KiloBitsTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * MILLION);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * MILLION);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * MILLION);
		result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * MILLION);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}
	
	[Test]
	public void GigaBits_ShouldBe_MegaBitsTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBits(size * THOUSAND);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size * THOUSAND);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * THOUSAND);
		result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * THOUSAND);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}
	
	[Test]
	public void GigaBits_ShouldBe_GigaBits()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBits(size);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void TeraBits_ShouldBe_BitsTimes1024x1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * TRILLION);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * TRILLION);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * TRILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * TRILLION));
	}

	[Test]
	public void TeraBits_ShouldBe_KiloBitsTimes1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * BILLION);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * BILLION);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BILLION);
		result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BILLION);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * BILLION));
	}

	[Test]
	public void TeraBits_ShouldBe_MegaBitsTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBits(size * MILLION);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size * MILLION);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * MILLION);
		result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * MILLION);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}
	
	[Test]
	public void TeraBits_ShouldBe_GigaBitsTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBits(size * THOUSAND);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size * THOUSAND);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size * THOUSAND);
		result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size * THOUSAND);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}

		
	[Test]
	public void TeraBits_ShouldBe_TeraBits()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.TBits(size);
		var result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBits(size);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inTBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBits(size);
		result = sizeOf.inTeraBits();
		Assert.That(result, Is.EqualTo(size));
	}

//	##########################
//	##                      ##
//	##  Byte-to-Byte-Tests  ##
//	##                      ##
//	##########################

	[Test]
	public void Bytes_ShouldBe_Bytes()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size);
		var result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void KiloBytes_ShouldBe_BytesTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * THOUSAND);
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * THOUSAND);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}
	
	[Test]
	public void KiloBytes_ShouldBe_KiloBytes()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size);
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void MegaBytes_ShouldBe_BytesTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * MILLION);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * MILLION);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}

	[Test]
	public void MegaBytes_ShouldBe_KiloBytesTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size * THOUSAND);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size * THOUSAND);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * THOUSAND);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * THOUSAND);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}

	[Test]
	public void MegaBytes_ShouldBe_MegaBytes()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBytes(size);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void GigaBytes_ShouldBe_BytesTimes1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * BILLION);
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * BILLION);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
	}

	[Test]
	public void GigaBytes_ShouldBe_KiloBytesTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size * MILLION);
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size * MILLION);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * MILLION);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * MILLION);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}
	
	[Test]
	public void GigaBytes_ShouldBe_MegaBytesTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBytes(size * THOUSAND);
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size * THOUSAND);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size * THOUSAND);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size * THOUSAND);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}
	
	[Test]
	public void GigaBytes_ShouldBe_GigaBytes()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBytes(size);
		var result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void TeraBytes_ShouldBe_BytesTimes1024x1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * TRILLION);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * TRILLION);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * TRILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * TRILLION));
	}

	[Test]
	public void TeraBytes_ShouldBe_KiloBytesTimes1024x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size * BILLION);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size * BILLION);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * BILLION);
		result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * BILLION);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * BILLION));
	}

	[Test]
	public void TeraBytes_ShouldBe_MegaBytesTimes1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBytes(size * MILLION);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size * MILLION);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size * MILLION);
		result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size * MILLION);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size * MILLION));
	}
	
	[Test]
	public void TeraBytes_ShouldBe_GigaBytesTimes1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.GBytes(size * THOUSAND);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBytes(size * THOUSAND);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size * THOUSAND);
		result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBytes(size * THOUSAND);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inGBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inGigaBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND));
	}

	[Test]
	public void TeraBytes_ShouldBe_TeraBytes()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.TBytes(size);
		var result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TBytes(size);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inTBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.TeraBytes(size);
		result = sizeOf.inTeraBytes();
		Assert.That(result, Is.EqualTo(size));
	}

//	###################
//	##               ##
//	##  Mixed Tests  ##
//	##               ##
//	###################

	[Test]
	public void Bytes_ShouldBe_BitsTimes8()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * BITS_PER_BYTE);
		var result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE));
	}
	
	[Test]
	public void KiloBits_ShouldBe_BytesTimes128()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * BYTES_PER_KBIT);
		var result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * BYTES_PER_KBIT);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
	}

	[Test]
	public void KiloBytes_ShouldBe_BitsTimes8x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * THOUSAND * BITS_PER_BYTE);
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * THOUSAND * BITS_PER_BYTE);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND * BITS_PER_BYTE));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * THOUSAND * BITS_PER_BYTE));
	}

	[Test]
	public void KiloBytes_ShouldBe_KiloBitsTimes8()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * BITS_PER_BYTE);
		var result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * BITS_PER_BYTE);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BITS_PER_BYTE);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BITS_PER_BYTE);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size));
	}
	
	[Test]
	public void MegaBits_ShouldBe_BytesTimes128x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bytes(size * THOUSAND * BYTES_PER_KBIT);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bytes(size * THOUSAND * BYTES_PER_KBIT);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND * BYTES_PER_KBIT));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inBytes();
		Assert.That(result, Is.EqualTo(size * THOUSAND * BYTES_PER_KBIT));
	}

	[Test]
	public void MegaBits_ShouldBe_KiloBytesTimes128()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBytes(size * BYTES_PER_KBIT);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBytes(size * BYTES_PER_KBIT);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * BYTES_PER_KBIT);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBytes(size * BYTES_PER_KBIT);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inKBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inKiloBytes();
		Assert.That(result, Is.EqualTo(size * BYTES_PER_KBIT));
	}

	[Test]
	public void MegaBytes_ShouldBe_BitsTimes8x1024x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * BITS_PER_BYTE * MILLION);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * BITS_PER_BYTE * MILLION);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * MILLION));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * MILLION));
	}

	[Test]
	public void MegaBytes_ShouldBe_KiloBitsTimes8x1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * BITS_PER_BYTE * THOUSAND);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * BITS_PER_BYTE * THOUSAND);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BITS_PER_BYTE * THOUSAND);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * BITS_PER_BYTE * THOUSAND);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * THOUSAND));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE * THOUSAND));
	}

	[Test]
	public void MegaBytes_ShouldBe_MegaBitsTimes8()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.MBits(size * BITS_PER_BYTE);
		var result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size * BITS_PER_BYTE);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * BITS_PER_BYTE);
		result = sizeOf.inMBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size * BITS_PER_BYTE);
		result = sizeOf.inMegaBytes();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBytes(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBytes(size);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size * BITS_PER_BYTE));
	}

	//	#########################
	//	##                     ##
	//	##  Private Method(s)  ##
	//	##                     ##
	//	#########################

	private byte fetchRandomSize() => (byte)(RandomSize.Next() & 127);
}
