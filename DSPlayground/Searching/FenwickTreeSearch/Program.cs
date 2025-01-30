namespace FenwickTreeSearch;

internal class Program
{
    static void Main(string[] args)
    {
        FenwickTree ft = new FenwickTree(10);

        // Sample updates
        ft.Update(1, 2);
        ft.Update(2, 3);
        ft.Update(3, 4);
        ft.Update(4, 5);
        ft.Update(5, 6);

        Console.WriteLine("Prefix Sum of first 5 elements: " + ft.PrefixSum(5)); // Output: 20

        int target = 7;
        Console.WriteLine($"Smallest index with prefix sum >= {target}: " + ft.FindSmallestIndexWithSum(target));
    }
}

public class FenwickTree
{
    private int[] bit;
    private int size;

    public FenwickTree(int n)
    {
        size = n;
        bit = new int[n + 1]; // BIT is 1-based index
    }

    // Update index i by adding delta (arr[i] += delta)
    public void Update(int i, int delta)
    {
        while (i <= size)
        {
            bit[i] += delta;
            i += (i & -i); // Move to next index
        }
    }

    // Get prefix sum from index 1 to i
    public int PrefixSum(int i)
    {
        int sum = 0;
        while (i > 0)
        {
            sum += bit[i];
            i -= (i & -i); // Move to parent index
        }
        return sum;
    }

    // Get range sum [l, r]
    public int RangeSum(int l, int r)
    {
        return PrefixSum(r) - PrefixSum(l - 1);
    }

    public int FindSmallestIndexWithSum(int target)
    {
        int sum = 0, pos = 0;
        int maxPower = 1;

        // Find the largest power of 2 within the range
        while (maxPower <= size) maxPower <<= 1;

        // Binary lifting search
        for (int step = maxPower >> 1; step > 0; step >>= 1)
        {
            if (pos + step <= size && sum + bit[pos + step] < target)
            {
                sum += bit[pos + step];
                pos += step;
            }
        }

        return pos + 1; // Convert to 1-based index
    }
}
