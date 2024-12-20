namespace ShellSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 12, 34, 54, 2, 3 };
        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(", ", array));

        ShellSorter(array);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(", ", array));
    }

    // Method to perform Shell Sort
    public static void ShellSorter(int[] array)
    {
        int n = array.Length;

        // Start with a big gap, then reduce the gap
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Perform a gapped insertion sort
            for (int i = gap; i < n; i += 1)
            {
                // Save the current element
                int temp = array[i];

                // Shift earlier gap-sorted elements up until the correct location for temp is found
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }

                // Put temp in its correct location
                array[j] = temp;
            }
        }
    }
}
