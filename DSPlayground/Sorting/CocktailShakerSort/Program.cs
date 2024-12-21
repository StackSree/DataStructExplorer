namespace CocktailShakerSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };
        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(", ", array));

        Sort(array);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", array));
    }

    public static void Sort(int[] array)
    {
        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            // Reset the swapped flag on entering the loop
            swapped = false;

            // Traverse from left to right
            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    // Swap elements
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            }

            // If no elements were swapped, the array is sorted
            if (!swapped)
                break;

            // Reset the swapped flag for the next pass
            swapped = false;

            // Move the end point back by one
            end--;

            // Traverse from right to left
            for (int i = end - 1; i >= start; i--)
            {
                if (array[i] > array[i + 1])
                {
                    // Swap elements
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            }

            // Increase the starting point
            start++;
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
