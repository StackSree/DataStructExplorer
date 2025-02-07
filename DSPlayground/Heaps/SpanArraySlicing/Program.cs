namespace SpanArraySlicing;

internal class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 10, 20, 30, 40, 50, 60 };

        Span<int> slice = numbers.AsSpan(2, 3); // Slice from index 2, length 3

        Console.WriteLine($"Original: {numbers[2]}, Span: {slice[0]}"); // Output: 30

        slice[0] = 99; // Modifies the original array
        Console.WriteLine($"Updated Array: {numbers[2]}"); // Output: 99
    }
}
