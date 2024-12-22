namespace PancakeSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 3, 6, 1, 9, 2, 5 };
        Console.WriteLine("Original Array:");
        PrintArray(arr);

        PancakeSortArray(arr);

        Console.WriteLine("Sorted Array:");
        PrintArray(arr);
    }

    // Utility function to print an array
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    public static void PancakeSortArray(int[] arr)
    {
        int n = arr.Length;

        // Iterate through the array from the largest unsorted element to the smallest
        for (int currSize = n; currSize > 1; currSize--)
        {
            // Find the index of the largest element in the current unsorted portion
            int maxIndex = FindMaxIndex(arr, currSize);

            // If the largest element is not already in place
            if (maxIndex != currSize - 1)
            {
                // Flip the array to bring the largest element to the front
                Flip(arr, maxIndex);

                // Flip again to bring the largest element to its correct position
                Flip(arr, currSize - 1);
            }
        }
    }

    // Function to flip the array from 0 to i
    private static void Flip(int[] arr, int i)
    {
        int start = 0;
        while (start < i)
        {
            // Swap elements at start and i
            int temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            start++;
            i--;
        }
    }

    // Function to find the index of the maximum element in the array up to size
    private static int FindMaxIndex(int[] arr, int size)
    {
        int maxIndex = 0;
        for (int i = 1; i < size; i++)
        {
            if (arr[i] > arr[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }
}
