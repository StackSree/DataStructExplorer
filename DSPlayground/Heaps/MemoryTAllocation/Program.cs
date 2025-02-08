namespace MemoryTAllocation;

internal class Program
{
    static async Task Main(string[] args)
    {
        Memory<int> memory = new int[] { 10, 20, 30, 40, 50 };

        await ProcessMemory(memory);
    }

    static async Task ProcessMemory(Memory<int> data)
    {
        // Simulating async operation
        await Task.Delay(100); 

        // Convert Memory<T> to Span<T>
        data.Span[0] = 99;

        Console.WriteLine($"Modified Memory: {data.Span[0]}"); // Output: 99
    }
}
