namespace SinglyLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        // Usage
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Display();
    }
}

public class SinglyLinkedList<T>
{
    public class Node
    {
        public T Value;
        public Node Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public Node Head;

    public void Add(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Display()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

