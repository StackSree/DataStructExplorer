namespace QuickSort;

internal class QuickSorter
{
    static void Main(string[] args)
    {
        int[] array = { 10, 7, 8, 9, 1, 5 };
        int n = array.Length;

        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(" ", array));

        QuickSort(array, 0, n - 1);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }
    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Choose the last element as the pivot
        int i = (low - 1); // Index for the smaller element

        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                // Swap array[i] and array[j]
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Swap array[i + 1] and array[high] (pivot)
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }

    // QuickSort method
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Find the partition index
            int pi = Partition(array, low, high);

            // Recursively sort elements before and after partition
            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }
}
