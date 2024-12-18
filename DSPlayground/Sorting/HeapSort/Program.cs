namespace HeapSort;

internal class Program
{

    public static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original Array:");
        PrintArray(array);

        Sort(array);

        Console.WriteLine("\nSorted Array:");
        PrintArray(array);
    }

    public static void Sort(int[] array)
    {
        int n = array.Length;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // Extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to the end
            Swap(array, 0, i);

            // Call heapify on the reduced heap
            Heapify(array, i, 0);
        }
    }
    private static void Heapify(int[] array, int heapSize, int rootIndex)
    {
        int largest = rootIndex;      // Initialize largest as root
        int leftChild = 2 * rootIndex + 1; // Left child
        int rightChild = 2 * rootIndex + 2; // Right child

        // Check if left child is larger than root
        if (leftChild < heapSize && array[leftChild] > array[largest])
        {
            largest = leftChild;
        }

        // Check if right child is larger than the largest so far
        if (rightChild < heapSize && array[rightChild] > array[largest])
        {
            largest = rightChild;
        }

        // If largest is not root
        if (largest != rootIndex)
        {
            Swap(array, rootIndex, largest);

            // Recursively heapify the affected sub-tree
            Heapify(array, heapSize, largest);
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Helper method to display the array
    public static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }

    // Main method
    
}
