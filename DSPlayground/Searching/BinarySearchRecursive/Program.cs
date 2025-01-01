namespace BinarySearchRecursive;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        int target = 7;
        int result = BinarySearchRecursive(arr, 0, arr.Length - 1, target);

        Console.WriteLine(result != -1 ? $"Found at index {result}" : "Not found");
    }

    static int BinarySearchRecursive(int[] arr, int left, int right, int target)
    {
        if (left > right)
            return -1; // Target not found

        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
            return mid; // Target found
        else if (arr[mid] < target)
            return BinarySearchRecursive(arr, mid + 1, right, target); // Right half
        else
            return BinarySearchRecursive(arr, left, mid - 1, target); // Left half
    }
}
