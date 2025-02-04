namespace HeapObjectPool;

internal class Program
{
    static void Main(string[] args)
    {
        ObjectPool<Sample> pool = new();

        // Get an object from the pool
        Sample obj1 = pool.GetObject();
        obj1.Data = 42;

        Console.WriteLine($"Object Data: {obj1.Data}");

        // Return object to the pool
        pool.ReturnObject(obj1);

        // Get another object (reused)
        Sample obj2 = pool.GetObject();
        Console.WriteLine($"Reused Object Data: {obj2.Data}"); // Still 42
    }
}
class Sample
{
    public int Data;
}

class ObjectPool<T> where T : new()
{
    private readonly Stack<T> _pool = new();

    public T GetObject()
    {
        return _pool.Count > 0 ? _pool.Pop() : new T();
    }

    public void ReturnObject(T obj)
    {
        _pool.Push(obj);
    }
}
