namespace FlashSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 6, 3, 9, 5, 2, 8, 7, 4 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        FlashSortAlgorithm(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static void FlashSortAlgorithm(int[] array)
    {
        int n = array.Length;
        if (n <= 1) return;

        // Step 1: Find min and max values
        int min = array[0], maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] < min) min = array[i];
            if (array[i] > array[maxIndex]) maxIndex = i;
        }

        // Early exit if array is already sorted
        if (array[maxIndex] == min) return;

        // Step 2: Create buckets and classify elements
        int m = (int)(0.90 * n); // Number of buckets (adjustable)
        int[] buckets = new int[m];
        double c = (double)(m - 1) / (array[maxIndex] - min);

        for (int i = 0; i < n; i++)
        {
            int bucketIndex = (int)(c * (array[i] - min));
            if (bucketIndex >= m) bucketIndex = m - 1; // Fix index out-of-range issue
            buckets[bucketIndex]++;
        }

        // Accumulate bucket counts to get the position index
        for (int i = 1; i < m; i++)
        {
            buckets[i] += buckets[i - 1];
        }

        // Step 3: Permutation: Place elements into their correct buckets
        int k = 0, move = 0, flash;
        while (move < n)
        {
            while (k >= buckets[k]) k++;
            flash = array[k];
            int bucketIndex;
            while (k < buckets[k])
            {
                bucketIndex = (int)(c * (flash - min));
                if (bucketIndex >= m) bucketIndex = m - 1; // Fix index out-of-range issue
                int temp = array[--buckets[bucketIndex]];
                array[buckets[bucketIndex]] = flash;
                flash = temp;
                move++;
            }
        }

        // Step 4: Perform insertion sort within each bucket
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}
