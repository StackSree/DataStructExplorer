namespace BinarySearchListBuiltIn;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 1, 3, 5, 7, 9, 11 };
        int target = 7;

        int result = list.BinarySearch(target);

        Console.WriteLine(result >= 0 ? $"Found at index {result}" : "Not found");
    }
}
