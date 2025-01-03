namespace CircularLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        // Usage
        var circularList = new CircularLinkedList<int>();
        circularList.Add(1);
        circularList.Add(2);
        circularList.Add(3);
        circularList.Display();
    }

    public class CircularLinkedList<T>
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
                Head.Next = Head; // Pointing to itself
            }
            else
            {
                Node current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = Head; // Circular link
            }
        }

        public void Display()
        {
            if (Head == null) return;

            Node current = Head;
            do
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            } while (current != Head);
            Console.WriteLine("Head");
        }
    }
}
