namespace SharpTools2024;

public sealed class SizeOf
{
	private long internalSize;

	//
	//	BITS
	//
	public static SizeOf Bits(long count) => new(count);
	public static SizeOf KBits(long count) => Bits(count * 1024);
	public static SizeOf KiloBits(long count) => KBits(count);
	public static SizeOf MBits(long count) => KBits(count * 1024);
	public static SizeOf MegaBits(long count) => MBits(count);
	public static SizeOf GBits(long count) => MBits(count * 1024);
	public static SizeOf GigaBits(long count) => GBits(count);
	public static SizeOf TBits(long count) => GBits(count * 1024);
	public static SizeOf TeraBits(long count) => TBits(count);

	//
	//	BYTES
	//
	public static SizeOf Bytes(long count) => Bits(count * 8);
	public static SizeOf KBytes(long count) => Bytes(count * 1024);
	public static SizeOf KiloBytes(long count) => KBytes(count);
	public static SizeOf MBytes(long count) => KBytes(count * 1024);
	public static SizeOf MegaBytes(long count) => MBytes(count);
	public static SizeOf GBytes(long count) => MBytes(count * 1024);
	public static SizeOf GigaBytes(long count) => GBytes(count);
	public static SizeOf TBytes(long count) => GBytes(count * 1024);
	public static SizeOf TeraBytes(long count) => TBytes(count);

	//
	//	BIT-CONVERSION
	//
	public long inBits() => internalSize;

	//
	//	BYTE-CONVERSION
	//
	public long inBytes() => inBits() / 8;
	public long inKBytes() => inBytes() / 1024;
	public long inKiloBytes() => inKBytes();
	public long inMBytes() => inKBytes() / 1024;
	public long inMegaBytes() => inMBytes();
	public long inGBytes() => inMBytes() / 1024;
	public long inGigaBytes() => inGBytes();
	public long inTBytes() => inGBytes() / 1024;
	public long inTeraBytes() => inTBytes();
	
	private SizeOf() {}
	private SizeOf(long count) => internalSize = count;
}
