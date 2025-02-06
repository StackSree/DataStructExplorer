namespace SpanUnsafeMemoryManipulation;

internal class Program
{
    static void Main(string[] args)
    {
        // Example: Using Span<T> for Efficient Memory Access
        int[] array = { 10, 20, 30, 40 };
        Span<int> span = array.AsSpan();

        span[0] = 100;
        Console.WriteLine(array[0]); // Output: 100
    }
}
