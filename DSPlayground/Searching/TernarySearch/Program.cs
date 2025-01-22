namespace TernarySearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 5, 7, 9, 11, 13 };
        int target = 7;

        int result = Search(arr, target);
        Console.WriteLine(result != -1 ? $"Element found at index {result}" : "Element not found");
    }

    public static int Search(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid1 = left + (right - left) / 3;
            int mid2 = right - (right - left) / 3;

            if (arr[mid1] == target)
                return mid1;

            if (arr[mid2] == target)
                return mid2;

            if (target < arr[mid1])
            {
                right = mid1 - 1;
            }
            else if (target > arr[mid2])
            {
                left = mid2 + 1;
            }
            else
            {
                left = mid1 + 1;
                right = mid2 - 1;
            }
        }

        return -1; // Target not found
    }
}
