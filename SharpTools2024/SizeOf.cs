namespace SharpTools2024;

using SharpTools2024.Exceptions;

public sealed class SizeOf {
	private const long
		ONE = 1,
		EIGHT = 8,
		THOUSAND = 1_024,
		MILLION = 1_048_576,
		BILLION = 1_073_741_824,
		TRILLION = 1_099_511_627_776,
		EIGHT_THOUSAND = EIGHT * THOUSAND,
		EIGHT_MILLION = EIGHT * MILLION,
		EIGHT_BILLION = EIGHT * BILLION,
		EIGHT_TRILLION = EIGHT * TRILLION;

	private long internalSize;

	//
	//	BITS
	//
	public static SizeOf Bits(long count) => new(count);
	public static SizeOf KBits(long count) => new(count, THOUSAND);
	public static SizeOf KiloBits(long count) => KBits(count);
	public static SizeOf MBits(long count) => new(count, MILLION);
	public static SizeOf MegaBits(long count) => MBits(count);
	public static SizeOf GBits(long count) => new(count, BILLION);
	public static SizeOf GigaBits(long count) => GBits(count);
	public static SizeOf TBits(long count) => new(count, TRILLION);
	public static SizeOf TeraBits(long count) => TBits(count);

	//
	//	BYTES
	//	
	public static SizeOf Bytes(long count) => new(count, EIGHT);
	public static SizeOf KBytes(long count) => new(count, EIGHT_THOUSAND);
	public static SizeOf KiloBytes(long count) => KBytes(count);
	public static SizeOf MBytes(long count) => new(count, EIGHT_MILLION);
	public static SizeOf MegaBytes(long count) => MBytes(count);
	public static SizeOf GBytes(long count) => new(count, EIGHT_BILLION);
	public static SizeOf GigaBytes(long count) => GBytes(count);
	public static SizeOf TBytes(long count) => new(count, EIGHT_TRILLION);
	public static SizeOf TeraBytes(long count) => TBytes(count);

	//
	//	BIT-CONVERSION
	//
	public long inBits() => internalSize;
	public long inKBits() => divide(inBits(), THOUSAND);
	public long inKiloBits() => inKBits();
	public long inMBits() => divide(inBits(), MILLION);
	public long inMegaBits() => inMBits();
	public long inGBits() => divide(inBits(), BILLION);
	public long inGigaBits() => inGBits();
	public long inTBits() => divide(inBits(), TRILLION);
	public long inTeraBits() => inTBits();

	//
	//	BYTE-CONVERSION
	//
	public long inBytes() => divide(inBits(), EIGHT);
	public long inKBytes() => divide(inBits(), EIGHT_THOUSAND);
	public long inKiloBytes() => inKBytes();
	public long inMBytes() => divide(inBits(), EIGHT_MILLION);
	public long inMegaBytes() => inMBytes();
	public long inGBytes() => divide(inBits(), EIGHT_BILLION);
	public long inGigaBytes() => inGBytes();
	public long inTBytes() => divide(inBits(), EIGHT_TRILLION);
	public long inTeraBytes() => inTBytes();

	private static void assume(bool condition, string elseMessage) {
		if(condition) throw new SizeOfException(elseMessage);
	}

	private static long divide(long size, long factor) {
		assume(size < 0, "Size must not be to negative.");
		assume(factor < 0, "Factor must not be to negative.");
		return size / factor;
	}

	private static long multiply(long size, long factor) {
		assume(size < 0, "Size must not be to negative.");
		assume(factor < 0, "Factor must not be to negative.");
		var maxSize = long.MaxValue / factor;
		var maxFactor = long.MaxValue / size;
		assume(size > maxSize, "Factor must not be to negative.");
		assume(factor > maxFactor, "Factor must not be to negative.");
		return size * factor;
	}
	
	private SizeOf(long size) => internalSize = multiply(size, 1);
	private SizeOf(long size, long factor) => internalSize = multiply(size, factor);
}
