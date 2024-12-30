namespace LinearSearchRecursive;

internal class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 3, 8, 12, 17, 25 };
        int target = 17;

        int result = LinearSearchRecursive(numbers, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int LinearSearchRecursive(int[] array, int target, int index = 0)
    {
        if (index >= array.Length)
            return -1; // Base case: not found
        if (array[index] == target)
            return index; // Base case: found
        return LinearSearchRecursive(array, target, index + 1); // Recursive step
    }
}