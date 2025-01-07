namespace StackCustom;

internal class Program
{
    static void Main(string[] args)
    {
       var stack = new CustomStack(10);

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
        Console.WriteLine("Stack status : " + stack.IsEmpty());
    }
}
class CustomStack
{
    private int[] stack;
    private int top;
    private int capacity;

    public CustomStack(int size)
    {
        stack = new int[size];
        capacity = size;
        top = -1;
    }

    public void Push(int item)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        stack[++top] = item;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack Underflow");
            return -1;
        }
        return stack[top--];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public int Peek()
    {
        if (!IsEmpty())
            return stack[top];
        return -1;
    }
}
