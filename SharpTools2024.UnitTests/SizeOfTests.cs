namespace SharpTools2024.UnitTests;

using SharpTools2024;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

public class SizeOfTests
{
	private const long
		KILO = 1024,
		MEGA = KILO * KILO,
		GIGA = MEGA * KILO,
		TERA = GIGA * KILO;

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
	public void KiloBits_ShouldBe_Bits_Times1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * KILO);
		var result = sizeOf.inKBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * KILO);
		result = sizeOf.inKiloBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * KILO));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * KILO));
	}

	[Test]
	public void MegaBits_ShouldBe_Bits_Times1024_Squared()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * MEGA);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * MEGA);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * MEGA));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.MegaBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * MEGA));
	}

	[Test]
	public void MegaBits_ShouldBe_KiloBits_Times1024()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.KBits(size * KILO);
		var result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * KILO);
		result = sizeOf.inMBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KBits(size * KILO);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.KiloBits(size * KILO);
		result = sizeOf.inMegaBits();
		Assert.That(result, Is.EqualTo(size));
	}

	[Test]
	public void GigaBits_ShouldBe_Bits_Times1024_Cubed()
	{
		var size = fetchRandomSize();
		var sizeOf = SizeOf.Bits(size * GIGA);
		var result = sizeOf.inGBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.Bits(size * GIGA);
		result = sizeOf.inGigaBits();
		Assert.That(result, Is.EqualTo(size));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * GIGA));
		//
		size = fetchRandomSize();
		sizeOf = SizeOf.GigaBits(size);
		result = sizeOf.inBits();
		Assert.That(result, Is.EqualTo(size * GIGA));
	}

//	#########################
//	##                     ##
//	##  Bit-to-Byte-Tests  ##
//	##                     ##
//	#########################

//	#########################
//	##                     ##
//	##  Byte-to-Bit-Tests  ##
//	##                     ##
//	#########################

//	##########################
//	##                      ##
//	##  Byte-to-Byte-Tests  ##
//	##                      ##
//	##########################

	

	/*
	[Test]
	public void KiloBitsShouldStayKiloBits()
	{
		var size = SizeOf.KBits(_SIZE_1_);
		var result1 = size.inKBits();
		var result2 = size.inKiloBits();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.KiloBits(_SIZE_2_);
		result1 = size.inKiloBits();
		result2 = size.inKBits();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	[Test]
	public void MegaBitsShouldStayMegaBits()
	{
		var size = SizeOf.MBits(_SIZE_1_);
		var result1 = size.inMBits();
		var result2 = size.inMegaBits();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.MegaBits(_SIZE_2_);
		result1 = size.inMegaBits();
		result2 = size.inMBits();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	[Test]
	public void GigaBitsShouldStayGigaBits()
	{
		var size = SizeOf.GBits(_SIZE_1_);
		var result1 = size.inGBits();
		var result2 = size.inGigaBits();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.GigaBits(_SIZE_2_);
		result1 = size.inGigaBits();
		result2 = size.inGBits();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	[Test]
	public void TeraBitsShouldStayTeraBits()
	{
		var size = SizeOf.TBits(_SIZE_1_);
		var result1 = size.inTBits();
		var result2 = size.inTeraBits();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.TeraBits(_SIZE_2_);
		result1 = size.inTeraBits();
		result2 = size.inTBits();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}
	
	//
	//  "Bytes-Should-Stay-Bytes"-Tests:
	//

	[Test]
	public void BytesShouldStayBytes()
	{
		var size = SizeOf.Bytes(_SIZE_2_);
		var result = size.inBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
	}
	
	[Test]
	public void KiloBytesShouldStayKiloBytes()
	{
		var size = SizeOf.KBytes(_SIZE_1_);
		var result1 = size.inKBytes();
		var result2 = size.inKiloBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.KiloBytes(_SIZE_2_);
		result1 = size.inKiloBytes();
		result2 = size.inKBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	[Test]
	public void MegaBytesShouldStayMegaBytes()
	{
		var size = SizeOf.MBytes(_SIZE_1_);
		var result1 = size.inMBytes();
		var result2 = size.inMegaBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.MegaBytes(_SIZE_2_);
		result1 = size.inMegaBytes();
		result2 = size.inMBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	[Test]
	public void GigaBytesShouldStayGigaBytes()
	{
		var size = SizeOf.GBytes(_SIZE_1_);
		var result1 = size.inGBytes();
		var result2 = size.inGigaBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.GigaBytes(_SIZE_2_);
		result1 = size.inGigaBytes();
		result2 = size.inGBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}
	
	[Test]
	public void TeraBytesShouldStayTeraBytes()
	{
		var size = SizeOf.TBytes(_SIZE_1_);
		var result1 = size.inTBytes();
		var result2 = size.inTeraBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_1_));
		Assert.That(result2, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.TeraBytes(_SIZE_2_);
		result1 = size.inTeraBytes();
		result2 = size.inTBytes();
		Assert.That(result1, Is.EqualTo(_SIZE_2_));
		Assert.That(result2, Is.EqualTo(_SIZE_2_));
	}

	//
	//  Pure Bit-Conversion-Tests:
	//

	

	//
	//  Bit-To-Byte-Conversion-Tests:
	//

	[Test]
	public void BitToByteConversionShouldBeCorrect()
	{
		var size = SizeOf.Bits(_SIZE_1_ * 8);
		var result = size.inBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.Bits(_SIZE_2_ * _KILO_2_);
		result = size.inKBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.Bits(
			_SIZE_1_ *
			_KILO_2_ *
			_KILO_1_);
		result = size.inMBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.Bits(
			_SIZE_2_ *
			_KILO_2_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inGBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.Bits(
			_SIZE_1_ *
			_KILO_2_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inTBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	
	//
	//  Byte-To-Bit-Conversion-Tests:
	//


	//
	//  Byte-Conversion-Tests:
	//

	[Test]
	public void ByteConversionShouldBeCorrect()
	{
		var size = SizeOf.Bytes(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_ * 8));
		//
		size = SizeOf.Bytes(_SIZE_2_ * _KILO_1_);
		result = size.inKBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.Bytes(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inMBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.Bytes(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inGBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.Bytes(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inTBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}

	[Test]
	public void KiloByteConversionShouldBeCorrect()
	{
		var size = SizeOf.KBytes(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_* _KILO_2_));
		//
		size = SizeOf.KBytes(_SIZE_2_);
		result = size.inBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_ * _KILO_1_));
		//
		size = SizeOf.KBytes(_SIZE_1_ * _KILO_1_);
		result = size.inMBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
		//
		size = SizeOf.KBytes(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inGBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.KBytes(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inTBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	
	[Test]
	public void MegaByteConversionShouldBeCorrect()
	{
		var size = SizeOf.MBytes(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(
			_SIZE_1_ *
			_KILO_2_ *
			_KILO_1_));
		//
		size = SizeOf.MBytes(_SIZE_2_);
		result = size.inBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.MBytes(_SIZE_1_);
		result = size.inKBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_ * _KILO_1_));
		//
		size = SizeOf.MBytes(_SIZE_2_ * _KILO_1_);
		result = size.inGBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_));
		//
		size = SizeOf.MBytes(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_);
		result = size.inTBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}

	[Test]
	public void GigaByteConversionShouldBeCorrect()
	{
		var size = SizeOf.GBytes(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(
			_SIZE_1_ *
			_KILO_2_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.GBytes(_SIZE_2_);
		result = size.inBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.GBytes(_SIZE_1_);
		result = size.inKBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.GBytes(_SIZE_2_);
		result = size.inMBytes();
		Assert.That(result, Is.EqualTo(_SIZE_2_ * _KILO_1_));
		//
		size = SizeOf.GBytes(_SIZE_1_ * _KILO_1_);
		result = size.inTBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	
	[Test]
	public void TeraByteConversionShouldBeCorrect()
	{
		var size = SizeOf.TBytes(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(
			_SIZE_1_ *
			_KILO_2_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.TBytes(_SIZE_2_);
		result = size.inBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.TBytes(_SIZE_1_);
		result = size.inKBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_1_ *
			_KILO_1_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.TBytes(_SIZE_2_);
		result = size.inMBytes();
		Assert.That(result, Is.EqualTo(
			_SIZE_2_ *
			_KILO_1_ *
			_KILO_1_));
		//
		size = SizeOf.TBytes(_SIZE_1_);
		result = size.inGBytes();
		Assert.That(result, Is.EqualTo(_SIZE_1_ * _KILO_1_));
	}
	*/

//	#######################
//	##                   ##
//	##  Private Methods  ##
//	##                   ##
//	#######################

	private byte fetchRandomSize() => (byte)(RandomSize.Next() & 127);
}
