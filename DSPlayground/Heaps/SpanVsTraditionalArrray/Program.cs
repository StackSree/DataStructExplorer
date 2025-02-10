using System.Diagnostics;

namespace SpanVsTraditionalArrray;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[1_000_000];

        Stopwatch sw = Stopwatch.StartNew();
        int[] slice = array[500_000..700_000]; // Creates a new array (Heap Allocation)
        sw.Stop();
        Console.WriteLine($"Array slice time: {sw.ElapsedTicks} ticks");

        sw.Restart();
        Span<int> span = array.AsSpan(500_000, 200_000); // No new allocation
        sw.Stop();
        Console.WriteLine($"Span slice time: {sw.ElapsedTicks} ticks");
    }
}
