namespace BinarySearchLastOccurrence;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5 };
        int target = 2;

        int result = BinarySearchLastOccurrence(arr, target);
        Console.WriteLine(result != -1 ? $"Found at index {result}" : "Not found");
    }

    static int BinarySearchLastOccurrence(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid; // Potential result
                left = mid + 1; // Search right half for later occurrence
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return result;
    }
}
