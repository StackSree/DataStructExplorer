namespace LinearSearchArray;

internal class Program
{
    static void Main(string[] args)
    {
        string[] fruits = { "Apple", "Banana", "Cherry", "Date" };
        string target = "Cherry";

        int result = LinearSearch(fruits, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int LinearSearch<T>(T[] array, T target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(target))
                return i; // Return the index of the target element
        }
        return -1; // Return -1 if the element is not found
    }
}
