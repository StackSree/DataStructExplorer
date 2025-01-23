namespace ExponentialSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 2, 3, 4, 10, 40, 50, 60, 70 };
        int target = 10;

        int result = Search(arr, target);
        Console.WriteLine(result != -1 ? $"Element found at index {result}" : "Element not found");
    }

    // Exponential Search method
    public static int Search(int[] arr, int target)
    {
        int n = arr.Length;

        // If the target is at the first position
        if (arr[0] == target)
            return 0;

        // Find the range for binary search
        int i = 1;
        while (i < n && arr[i] <= target)
        {
            i *= 2;
        }

        // Call binary search within the identified range
        return BinarySearch(arr, i / 2, Math.Min(i, n - 1), target);
    }

    // Binary Search method
    public static int BinarySearch(int[] arr, int left, int right, int target)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;

            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Target not found
    }
}
