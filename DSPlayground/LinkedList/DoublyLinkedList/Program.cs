namespace DoublyLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        // Usage
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.DisplayForward();
        list.DisplayBackward();
    }

    public class DoublyLinkedList<T>
    {
        public class Node
        {
            public T Value;
            public Node Next;
            public Node Prev;

            public Node(T value)
            {
                Value = value;
                Next = null;
                Prev = null;
            }
        }

        public Node Head;
        public Node Tail;

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public void DisplayForward()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public void DisplayBackward()
        {
            Node current = Tail;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Prev;
            }
            Console.WriteLine("null");
        }
    }
}
