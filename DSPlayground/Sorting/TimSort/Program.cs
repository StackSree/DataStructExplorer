namespace TimSort;

public class Program
{
    const int RUN = 32;
    static void Main(string[] args)
    {
        int[] arr = { 5, 21, 7, 23, 19, 3, 17, 13, 2, 1, 9, 8 };
        int n = arr.Length;

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", arr));

        TimSortArray(arr, n);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", arr));
    }

    // The main function that sorts the array using TimSort.
    public static void TimSortArray(int[] arr, int n)
    {
        // Sort individual subarrays of size RUN.
        for (int i = 0; i < n; i += RUN)
            InsertionSort(arr, i, Math.Min((i + RUN - 1), (n - 1)));

        // Start merging from size RUN (or 32). It will merge to form size 64, 128, etc.
        for (int size = RUN; size < n; size = 2 * size)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min((left + 2 * size - 1), (n - 1));

                if (mid < right)
                    Merge(arr, left, mid, right);
            }
        }
    }

    // This function sorts an array using insertion sort.
    public static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
    }

    // Merge function to merge two sorted runs.
    public static void Merge(int[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1, len2 = right - mid;
        int[] leftArr = new int[len1];
        int[] rightArr = new int[len2];

        for (int x = 0; x < len1; x++)
            leftArr[x] = arr[left + x];
        for (int x = 0; x < len2; x++)
            rightArr[x] = arr[mid + 1 + x];

        int i = 0, j = 0, k = left;

        while (i < len1 && j < len2)
        {
            if (leftArr[i] <= rightArr[j])
                arr[k++] = leftArr[i++];
            else
                arr[k++] = rightArr[j++];
        }

        while (i < len1)
            arr[k++] = leftArr[i++];

        while (j < len2)
            arr[k++] = rightArr[j++];
    }
}
