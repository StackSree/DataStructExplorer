namespace SmoothSort;

internal class Program
{
   // Leonardo numbers for tree sizes
    private static readonly int[] LeonardoNumbers = GenerateLeonardoNumbers();

    private static int[] GenerateLeonardoNumbers()
    {
        int max = 64; // Safe limit for Leonardo numbers
        int[] leo = new int[max];
        leo[0] = 1;
        leo[1] = 1;

        for (int i = 2; i < max; i++)
        {
            leo[i] = leo[i - 1] + leo[i - 2] + 1;
        }

        return leo;
    }

    public static void Sort(int[] array)
    {
        int n = array.Length;

        // Tracks tree sizes in the heap
        int[] heap = new int[n];
        int heapSize = 0;

        // Build the heap
        for (int i = 0; i < n; i++)
        {
            AddToHeap(array, i, heap, ref heapSize);
        }

        // Remove elements from the heap to sort the array
        for (int i = n - 1; i >= 0; i--)
        {
            RemoveFromHeap(array, i, heap, ref heapSize);
        }
    }

    private static void AddToHeap(int[] array, int index, int[] heap, ref int heapSize)
    {
        if (heapSize >= 2 && heap[heapSize - 1] == heap[heapSize - 2] + 1)
        {
            // Merge two trees into one larger tree
            heapSize--;
            heap[heapSize - 1]++;
        }
        else
        {
            // Add a new small tree
            heap[heapSize++] = 1;
        }

        SiftUp(array, index, heap, heapSize);
    }

    private static void RemoveFromHeap(int[] array, int index, int[] heap, ref int heapSize)
    {
        int treeSize = heap[--heapSize];

        if (treeSize > 1)
        {
            int rightChild = index - 1;
            int leftChild = index - LeonardoNumbers[treeSize - 2];

            heap[heapSize++] = treeSize - 1;
            SiftUp(array, leftChild, heap, heapSize);

            heap[heapSize++] = treeSize - 2;
            SiftUp(array, rightChild, heap, heapSize);
        }
    }

    private static void SiftUp(int[] array, int rootIdx, int[] heap, int heapSize)
    {
        while (heapSize > 0)
        {
            int treeSize = heap[heapSize - 1];
            int largest = rootIdx;

            if (treeSize > 1)
            {
                int leftChild = rootIdx - LeonardoNumbers[treeSize - 2];
                int rightChild = rootIdx - 1;

                if (leftChild >= 0 && array[leftChild] > array[largest])
                {
                    largest = leftChild;
                }

                if (rightChild >= 0 && array[rightChild] > array[largest])
                {
                    largest = rightChild;
                }
            }

            if (largest == rootIdx)
            {
                break; // Heap property satisfied
            }

            Swap(array, rootIdx, largest);
            rootIdx = largest;
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void Main(string[] args)
    {
        int[] array = { 4, 10, 3, 5, 1, 7, 8, 6, 2, 9 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        Sort(array);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", array));
    }
}