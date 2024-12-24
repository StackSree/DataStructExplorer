namespace StoogeSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 9, 7, 3, 8, 2, 6, 1, 5 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        // Perform Stooge Sort
        StoogeSortArray(array, 0, array.Length - 1);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    // Stooge Sort method
    public static void StoogeSortArray(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        // If the first element is greater than the last, swap them
        if (array[start] > array[end])
        {
            Swap(array, start, end);
        }

        // If the array has more than two elements
        if (end - start + 1 > 2)
        {
            int third = (end - start + 1) / 3;

            // Recursively sort the first two-thirds
            StoogeSortArray(array, start, end - third);

            // Recursively sort the last two-thirds
            StoogeSortArray(array, start + third, end);

            // Recursively sort the first two-thirds again
            StoogeSortArray(array, start, end - third);
        }
    }

    // Helper method to swap two elements in the array
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

}
