namespace BitonicSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 3, 7, 4, 8, 6, 2, 1, 5 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        BitonicSortMain(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void BitonicSortMain(int[] array)
    {
        int n = array.Length;

        // Start the recursive bitonic sort process
        BitonicSort(array, 0, n, true);
    }

    private static void BitonicSort(int[] array, int low, int count, bool ascending)
    {
        if (count > 1)
        {
            int mid = count / 2;

            // Sort first half in ascending order
            BitonicSort(array, low, mid, true);

            // Sort second half in descending order
            BitonicSort(array, low + mid, mid, false);

            // Merge the two halves
            BitonicMerge(array, low, count, ascending);
        }
    }

    private static void BitonicMerge(int[] array, int low, int count, bool ascending)
    {
        if (count > 1)
        {
            int mid = count / 2;

            for (int i = low; i < low + mid; i++)
            {
                if (ascending == (array[i] > array[i + mid]))
                {
                    // Swap elements to maintain bitonic sequence
                    Swap(array, i, i + mid);
                }
            }

            // Recursively merge the halves
            BitonicMerge(array, low, mid, ascending);
            BitonicMerge(array, low + mid, mid, ascending);
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
