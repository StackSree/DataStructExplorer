namespace StackDefault;

internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        // Push elements onto the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Peek the top element
        Console.WriteLine("Top element: " + stack.Peek());

        // Pop elements off the stack
        Console.WriteLine("Popped: " + stack.Pop());
        Console.WriteLine("Popped: " + stack.Pop());

        // Check if the stack contains a value
        Console.WriteLine("Contains 1: " + stack.Contains(1));

        // Count of elements
        Console.WriteLine("Count: " + stack.Count);
    }
}
