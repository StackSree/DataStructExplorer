namespace CombSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 8, 4, 1, 56, 3, -44, 23, -6, 28, 0 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        CombSortArray(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void CombSortArray(int[] array)
    {
        int n = array.Length;
        int gap = n; // Initial gap size
        bool swapped = true;

        // Continue sorting until gap is 1 and no swaps are made
        while (gap != 1 || swapped)
        {
            // Update the gap for the next iteration
            gap = GetNextGap(gap);

            swapped = false;

            // Compare and swap elements at the current gap
            for (int i = 0; i < n - gap; i++)
            {
                if (array[i] > array[i + gap])
                {
                    Swap(array, i, i + gap);
                    swapped = true;
                }
            }
        }
    }

    private static int GetNextGap(int gap)
    {
        // Shrink gap using the shrink factor of 1.3
        gap = (int)(gap / 1.3);
        return Math.Max(gap, 1); // Ensure the gap is at least 1
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
