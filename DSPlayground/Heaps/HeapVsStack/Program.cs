using System;

namespace HeapVsStack;

internal class Program
{
    static void Main(string[] args)
    {
        // 🔹 STACK (Value Type)
       // y changes to 10, but x remains 5, proving they are separate copies in the stack.
        int x = 5;    
        int y = x;
        y = 10;

        Console.WriteLine($"x: {x}, y: {y}"); // Output: x: 10, y: 10

        // 🔹 HEAP (Reference Type)
        // Object stored in the heap
        var p1 = new Person{ Name = "Alice" };

        // p2 points to the same heap memory as p1
        var p2 = p1;

        // Output: Alice, Alice
        Console.WriteLine($"p1: {p1.Name}, p2: {p2.Name}");

        // Modify p2, it affects p1 (since both point to the same object)
        p2.Name = "Bob";

        // Output: Bob, Bob
        Console.WriteLine($"After Modification: p1: {p1.Name}, p2: {p2.Name}");
        

        // Stack Example with Method Calls
        StackExample();

        Console.WriteLine("Execution Complete!");

        /*
         * 
         *  Stack is faster but limited(used for method calls, value types).
         *  Heap is slower but flexible(stores reference types, large objects).
         *  Garbage Collector cleans the heap, but the stack is managed automatically.
         *  Overusing recursion leads to StackOverflowException.          
         */
      
    }

    static void StackExample()
    {
        int a = 5; // Stored in stack
        int b = 10;
        int result = a + b; // Computation on stack

        Console.WriteLine($"Stack Example Result: {result}");
    }
}


public class Person
{
    public string Name { get; set; }
}
