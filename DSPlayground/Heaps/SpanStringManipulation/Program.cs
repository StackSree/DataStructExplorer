namespace SpanStringManipulation;

internal class Program
{
    static void Main(string[] args)
    {
        ReadOnlySpan<char> span = "Hello World".AsSpan();

        ReadOnlySpan<char> subSpan = span.Slice(6, 5); // Extract "World"

        Console.WriteLine(subSpan.ToString()); // Output: World
    }
}
