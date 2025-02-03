namespace HeapSimple;

internal class Program
{
    static void Main(string[] args)
    {
        // "p1" and "p2" are stored on the stack, but the objects are stored on the heap
        Person p1 = new("Alice", 25);
        Person p2 = new("Bob", 30);

        p1.Display();
        p2.Display();

        // Now eligible for garbage collection
        // Objects without references become eligible for garbage collection.
        p1 = null;
        p2 = null;

        // Force garbage collection
        // Not recommended for general use
        GC.Collect();

        // Wait for destructor to run
        GC.WaitForPendingFinalizers(); 

        Console.WriteLine("Garbage collection completed.");
    }
}


record Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    ~Person() => Console.WriteLine("Object destroyed!");
}
