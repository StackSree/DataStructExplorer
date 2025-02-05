namespace WeakReference;

internal class Program
{
    static void Main(string[] args)
    {
        WeakReference<Sample> weakRef = new(new Sample { Name = "Temp Object" });

        if (weakRef.TryGetTarget(out Sample obj))
        {
            Console.WriteLine($"Object is still alive: {obj.Name}");
        }

        GC.Collect(); // Force garbage collection

        if (weakRef.TryGetTarget(out obj))
        {
            Console.WriteLine($"Object survived GC: {obj.Name}");
        }
        else
        {
            Console.WriteLine("Object was collected.");
        }
    }
}


class Sample
{
    public string Name;
}
