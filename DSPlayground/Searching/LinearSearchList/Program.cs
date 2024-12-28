namespace LinearSearchList;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 5, 15, 25, 35, 45 };
        int target = 35;

        int result = LinearSearch(numbers, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found");
    }

    static int LinearSearch<T>(List<T> list, T target)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Equals(target))
                return i;
        }
        return -1;
    }
}
