namespace BogoSort;

internal class Program
{
    static Random random = new Random();

    // Main function to sort the array
    public static void BogoSortMain(int[] array)
    {
        while (!IsSorted(array))
        {
            Shuffle(array);
        }
    }

    // Check if the array is sorted
    private static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    // Shuffle the array randomly
    private static void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = random.Next(array.Length);
            Swap(array, i, randomIndex);
        }
    }

    // Swap two elements in the array
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void Main(string[] args)
    {
        int[] array = { 3, 2, 5, 1, 4 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        BogoSortMain(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }
}
