namespace MergeSort;

internal static class MergeSorter
{
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            // Recursively sort the first half
            MergeSort(array, left, middle);

            // Recursively sort the second half
            MergeSort(array, middle + 1, right);

            // Merge the two halves
            Merge(array, left, middle, right);
        }
    }
    private static void Merge(int[] array, int left, int middle, int right)
    {
        // Determine the sizes of the two subarrays
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        // Create temporary arrays
        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        // Copy data into the temporary arrays
        for (int i = 0; i < leftSize; i++)
            leftArray[i] = array[left + i];

        for (int j = 0; j < rightSize; j++)
            rightArray[j] = array[middle + 1 + j];

        // Merge the temporary arrays back into the original array
        int iLeft = 0, iRight = 0, k = left;

        while (iLeft < leftSize && iRight < rightSize)
        {
            if (leftArray[iLeft] <= rightArray[iRight])
            {
                array[k] = leftArray[iLeft];
                iLeft++;
            }
            else
            {
                array[k] = rightArray[iRight];
                iRight++;
            }
            k++;
        }

        // Copy any remaining elements from the left array
        while (iLeft < leftSize)
        {
            array[k] = leftArray[iLeft];
            iLeft++;
            k++;
        }

        // Copy any remaining elements from the right array
        while (iRight < rightSize)
        {
            array[k] = rightArray[iRight];
            iRight++;
            k++;
        }
    }

    // Utility function to print an array
    private static void PrintArray(int[] array)
    {
        foreach (int item in array)
            Console.Write(item + " ");
        Console.WriteLine();
    }

    // Main program
    static void Main()
    {
        int[] array = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Original array:");
        PrintArray(array);

        MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("Sorted array:");
        PrintArray(array);
    }
}