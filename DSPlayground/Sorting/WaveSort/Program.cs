namespace WaveSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 3, 6, 5, 10, 7, 20, 15 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        WaveSortArray(array);

        Console.WriteLine("\nWave Sorted Array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void WaveSortArray(int[] array)
    {
        int n = array.Length;

        // Traverse all even indexed elements
        for (int i = 0; i < n; i += 2)
        {
            // If the current element is smaller than the previous, swap
            if (i > 0 && array[i] < array[i - 1])
            {
                Swap(array, i, i - 1);
            }

            // If the current element is smaller than the next, swap
            if (i < n - 1 && array[i] < array[i + 1])
            {
                Swap(array, i, i + 1);
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
