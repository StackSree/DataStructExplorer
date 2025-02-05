using System.IO.MemoryMappedFiles;

namespace MemoryMappedFileAccess;

internal class Program
{
    static void Main(string[] args)
    {
        using MemoryMappedFile mmf = MemoryMappedFile.CreateNew("test", 1024);

        using MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor();
        accessor.Write(0, 42); // Store an integer in the memory-mapped file
        Console.WriteLine("Data written.");
        accessor.Read(0, out int data);
        Console.WriteLine(data.ToString());
    }
}
