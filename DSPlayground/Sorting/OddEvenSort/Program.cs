namespace OddEvenSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 8, 3, 1, 7, 2, 6, 4 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        OddEvenSortMain(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void OddEvenSortMain(int[] array)
    {
        int n = array.Length;
        bool isSorted = false;

        while (!isSorted)
        {
            isSorted = true;

            // Perform the odd-indexed pass
            for (int i = 1; i <= n - 2; i += 2)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    isSorted = false;
                }
            }

            // Perform the even-indexed pass
            for (int i = 0; i <= n - 2; i += 2)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    isSorted = false;
                }
            }
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
