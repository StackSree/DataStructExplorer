namespace RadixSort;

internal class Program
{
    // Test the Radix Sort
    public static void Main(string[] args)
    {
        int[] array = { 170, 45, 75, 90, 802, 24, 2, 66 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(", ", array));

        PerformRadixSort(array);

        Console.WriteLine("Sorted Array:");
        Console.WriteLine(string.Join(", ", array));
    }

    public static void PerformRadixSort(int[] array)
    {
        // Find the maximum number to know the number of digits
        int max = FindMax(array);

        // Perform counting sort for each digit
        for (int place = 1; max / place > 0; place *= 10)
        {
            CountingSort(array, place);
        }
    }

    // A utility function to find the maximum number in an array
    private static int FindMax(int[] array)
    {
        int max = array[0];
        foreach (int num in array)
        {
            if (num > max)
                max = num;
        }
        return max;
    }

    // Counting Sort based on a specific digit (place)
    private static void CountingSort(int[] array, int place)
    {
        int n = array.Length;
        int[] output = new int[n];
        int[] count = new int[10]; // Digits range from 0-9

        // Count occurrences of each digit in the current place
        for (int i = 0; i < n; i++)
        {
            int digit = (array[i] / place) % 10;
            count[digit]++;
        }

        // Update count[i] to contain the actual position of the digit in output[]
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (array[i] / place) % 10;
            output[count[digit] - 1] = array[i];
            count[digit]--;
        }

        // Copy the output array to the original array
        for (int i = 0; i < n; i++)
        {
            array[i] = output[i];
        }
    }
}
