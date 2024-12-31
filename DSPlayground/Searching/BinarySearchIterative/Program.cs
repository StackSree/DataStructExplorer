namespace BinarySearchIterative;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        int target = 7;
        int result = BinarySearch(arr, target);

        Console.WriteLine(result != -1 ? $"Found at index {result}" : "Not found");
    }

   private static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid; // Target found
            else if (arr[mid] < target)
                left = mid + 1; // Target is in the right half
            else
                right = mid - 1; // Target is in the left half
        }

        return -1; // Target not found
    }
}
