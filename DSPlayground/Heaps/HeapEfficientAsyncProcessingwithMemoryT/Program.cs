namespace HeapEfficientAsyncProcessingwithMemoryT;

internal class Program
{
    static async Task Main(string[] args)
    {
        byte[] buffer = new byte[1024];

        string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}log.txt";

        using FileStream fs = new(filePath, FileMode.Open);
        Memory<byte> memoryBuffer = buffer;

        int bytesRead = await fs.ReadAsync(memoryBuffer); // No extra allocations!
        Console.WriteLine($"Bytes Read: {bytesRead}");
    }
}
