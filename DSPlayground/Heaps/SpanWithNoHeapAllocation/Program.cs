namespace SpanWithNoHeapAllocation;

internal class Program
{
    static void Main(string[] args)
    {
        Span<int> numbers = stackalloc int[3] { 1, 2, 3 };

        numbers[0] = 100;
        Console.WriteLine(numbers[0]); // Output: 100
    }
}
