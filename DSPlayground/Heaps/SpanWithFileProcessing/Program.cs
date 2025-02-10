namespace SpanWithFileProcessing;

internal class Program
{
    static void Main(string[] args)
    {

        string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}log.txt";             

        foreach (var strean in ReadLines(filePath))
        {
            if (strean.Span.Contains("ERROR".AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(strean.Span.ToString()); 
            }
        }
    }   

    private static IEnumerable<ReadOnlyMemory<char>> ReadLines(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);

        // Read in chunks
        char[] buffer = new char[1024]; 
        while (reader.Read(buffer, 0, buffer.Length) > 0)
        {
            // ✅ ReadOnlyMemory<char> works with IEnumerable<T>
            yield return buffer.AsMemory(); 
        }
    }
}
