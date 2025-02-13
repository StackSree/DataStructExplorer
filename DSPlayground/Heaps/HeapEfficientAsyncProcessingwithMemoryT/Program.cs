namespace HeapEfficientAsyncProcessingwithMemoryT;

internal class Program
{
    static async Task Main(string[] args)
    {
        byte[] buffer = new byte[1024];

        string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}log.txt";

        using FileStream fs = new(filePath, FileMode.Open);
        Memory<byte> memoryBuffer = buffer;

        // No extra allocations!
        int bytesRead = await fs.ReadAsync(memoryBuffer); 

        Console.WriteLine($"Bytes Read: {bytesRead}");
    }
}
