namespace SparseTableSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 2, 7, 9, 11, 3, 5, 2, 8 };
        SparseTable st = new SparseTable(arr);

        Console.WriteLine("Min in range [0,5]: " + st.Query(0, 5)); // Output: 1
        Console.WriteLine("Min in range [3,8]: " + st.Query(3, 8)); // Output: 2
        Console.WriteLine("Min in range [2,4]: " + st.Query(2, 4)); // Output: 2
    }
}

public class SparseTable
{
    private int[,] table;
    private int[] logValues;
    private int n;

    public SparseTable(int[] arr)
    {
        n = arr.Length;
        int logN = (int)Math.Log2(n) + 1;
        table = new int[n, logN];
        logValues = new int[n + 1];

        // Precompute logarithm values
        for (int i = 2; i <= n; i++)
            logValues[i] = logValues[i / 2] + 1;

        // Build Sparse Table
        for (int i = 0; i < n; i++)
            table[i, 0] = arr[i];

        for (int j = 1; (1 << j) <= n; j++)
        {
            for (int i = 0; i + (1 << j) - 1 < n; i++)
            {
                table[i, j] = Math.Min(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
            }
        }
    }

    public int Query(int left, int right)
    {
        int length = right - left + 1;
        int log = logValues[length];
        return Math.Min(table[left, log], table[right - (1 << log) + 1, log]);
    }
}
