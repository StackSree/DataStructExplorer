namespace LinearSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        int target = 30;

        int result = LinearSearch(numbers, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i; // Return the index of the target element
        }
        return -1; // Return -1 if the element is not found
    }
}
