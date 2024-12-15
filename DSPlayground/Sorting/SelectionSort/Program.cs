namespace SelectionSort;

public class Program
{
    static void Main(string[] args)
    {
        int[] data = { 64, 25, 12, 22, 11 };
        Console.WriteLine("Unsorted Array:");
        PrintArray(data);

        SelectionSort(data);

        Console.WriteLine("Sorted Array:");
        PrintArray(data);
    }

    static void SelectionSort(int[] array)
    {
        int n = array.Length;

        // Outer Loop: It iterates over each element in the array except the last one.
        for (int i = 0; i < n - 1; i++)
        {
            // Assume the minimum value is at the current index
            int minIndex = i;

            // Find the index of the smallest element in the remaining unsorted array
            // Inner Loop: It finds the index of the smallest element in the unsorted portion of the array.
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first element of the unsorted part
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
