using System.Buffers;

namespace HeapLargeObjectHeapOptimization;

internal class Program
{
    static void Main(string[] args)
    {
        ArrayPool<int> pool = ArrayPool<int>.Shared;

        // Rent a large array instead of allocating on LOH
        int[] largeArray = pool.Rent(100_000);

        largeArray[0] = 42;
        Console.WriteLine($"First Element: {largeArray[0]}");

        // Return the array to the pool (does not free memory immediately)
        pool.Return(largeArray);
    }
}
