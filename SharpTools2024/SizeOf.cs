namespace SharpTools2024;

public sealed class SizeOf
{
	private long internalSize;

	public static SizeOf Bits(long count) => new(count);
	public static SizeOf Bytes(long count) => Bits(count * 8);
	public static SizeOf KBytes(long count) => Bytes(count * 1024);
	public static SizeOf KiloBytes(long count) => KBytes(count);
	public static SizeOf MBytes(long count) => KBytes(count * 1024);
	public static SizeOf MegaBytes(long count) => MBytes(count);
	public static SizeOf GBytes(long count) => KBytes(count * 1024);
	public static SizeOf GigaBytes(long count) => GBytes(count);
	public static SizeOf TBytes(long count) => GBytes(count * 1024);
	public static SizeOf TeraBytes(long count) => TBytes(count);

	public long inBits() => internalSize;
	public long inBytes() => internalSize / 8;

	
	private SizeOf() {}
	private SizeOf(long count) => internalSize = count;
}
