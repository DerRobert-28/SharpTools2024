namespace SharpTools2024.UnitTests;

using SharpTools2024;

public class SizeOfTests
{
	private const int
		_SIZE_1_ = 123,
		_SIZE_2_ = 456;

	private const long
		_KILO_1_ = 1024,
		_KILO_2_ = 8192;

	//
	//  ShouldStayBit-Tests:
	//

	[Test]
	public void BitsShouldStayBits()
	{
		var size = SizeOf.Bits(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}

	[Test]
	public void KBitsShouldStayKBits()
	{
		var size = SizeOf.KBits(_SIZE_1_);
		var result = size.inKBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	[Test]
	public void BitsShouldStayBits()
	{
		var size = SizeOf.Bits(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	[Test]
	public void BitsShouldStayBits()
	{
		var size = SizeOf.Bits(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	[Test]
	public void BitsShouldStayBits()
	{
		var size = SizeOf.Bits(_SIZE_1_);
		var result = size.inBits();
		Assert.That(result, Is.EqualTo(_SIZE_1_));
	}
	
	//
	//  ShouldStayByte-Tests:
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
	//  Conversion-Tests:
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
}
