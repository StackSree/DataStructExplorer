namespace SpanWithFileProcessing;

internal class Program
{
    static void Main(string[] args)
    {
        const string filePath = "log.txt";       

        foreach (var span in ReadLines("file.txt"))
        {
            if (span.Contains("ERROR", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(span.ToString()); // Print directly
            }
        }
    }   

    private static IEnumerable<ReadOnlyMemory<char>> ReadLines(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);

        char[] buffer = new char[1024]; // Read in chunks
        while (reader.Read(buffer, 0, buffer.Length) > 0)
        {
            yield return buffer.AsMemory(); // ✅ ReadOnlyMemory<char> works with IEnumerable<T>
        }
    }
}
