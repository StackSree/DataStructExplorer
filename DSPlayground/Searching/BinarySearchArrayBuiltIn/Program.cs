namespace BinarySearchArrayBuiltIn;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        int target = 7;

        int result = Array.BinarySearch(arr, target);

        Console.WriteLine(result >= 0 ? $"Found at index {result}" : "Not found");
    }
}
