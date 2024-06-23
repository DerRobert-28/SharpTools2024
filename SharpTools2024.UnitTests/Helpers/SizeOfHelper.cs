namespace SharpTools2024.UnitTests.Helpers;

public class SizeOfHelper {
	protected const long
		BITS_PER_BYTE = 8,
		BYTES_PER_KBIT = 128,
		THOUSAND = 1024,
		MILLION = THOUSAND * THOUSAND,
		BILLION = THOUSAND * MILLION,
		TRILLION = THOUSAND * BILLION;

	protected readonly Random RandomSize = new();

	protected int fetchRandomSize() {
		while (true) {
			var size = RandomSize.Next() & 127;
			if (size != 0) return size;
		}
	}

	protected int[] fetchTwoRandomSizes() {
		var sizes = new int[2];
		do {
			sizes[0] = fetchRandomSize();
			sizes[1] = fetchRandomSize();
		}
		while(sizes[0] == sizes[1]);
		return sizes;
	}

	protected SizeOfHelper() {}
}
