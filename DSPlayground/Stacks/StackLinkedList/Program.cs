namespace StackLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        var stack = new LinkedListStack<int>();
        // Push elements onto the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Peek the top element
        Console.WriteLine("Top element: " + stack.Peek());

        // Pop elements off the stack
        Console.WriteLine("Popped: " + stack.Pop());
        Console.WriteLine("Popped: " + stack.Pop()); 
        
        Console.WriteLine("Elements: "+ stack.Count());
    }
}
class LinkedListStack<T>
{
    private LinkedList<T> list = new LinkedList<T>();

    public void Push(T value)
    {
        list.AddLast(value);
    }

    public T Pop()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T value = list.Last.Value;
        list.RemoveLast();
        return value;
    }

    public T Peek()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return list.Last.Value;
    }

    public int Count() => list.Count;
}
