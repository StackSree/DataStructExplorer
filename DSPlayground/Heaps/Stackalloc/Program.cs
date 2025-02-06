namespace Stackalloc;

internal class Program
{
    static void Main(string[] args)
    {
        Span<int> numbers = stackalloc int[5] { 1, 2, 3, 4, 5 };

        Console.WriteLine($"First Number: {numbers[0]}"); // Output: 1
    }
}
