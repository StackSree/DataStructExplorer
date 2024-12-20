namespace CountingSort;

internal class Program
{
    static void Main(string[] args)
    {
        // Example usage
        int[] array = { 4, 2, 2, 8, 3, 3, 1 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(", ", array));

        Sort(array);

        Console.WriteLine("Sorted Array:");
        Console.WriteLine(string.Join(", ", array));
    }
    public static void Sort(int[] array)
    {
        // Find the maximum value in the array
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
                max = array[i];
        }

        // Initialize the count array
        int[] count = new int[max + 1];

        // Count the occurrences of each element
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        // Reconstruct the sorted array
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                array[index++] = i;
                count[i]--;
            }
        }
    }
}



