namespace InsertionSort;

public class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 29, 10, 14, 37, 14 };

        Console.WriteLine("Original array:");
        PrintArray(numbers);

        InsertionSort(numbers);

        Console.WriteLine("Sorted array:");
        PrintArray(numbers);
    }

    static void InsertionSort(int[] array)
    {
        // Starts at the second element(i = 1) since the first element is trivially sorted.
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Move elements that are greater than key to one position ahead
            // of their current position
            // Compares the key(current element) with elements in the sorted part of the array(array[j]).
            // If an element in the sorted part is greater than the key, it shifts to the right.
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
