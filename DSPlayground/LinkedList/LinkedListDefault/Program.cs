namespace LinkedListDefault;

internal class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new LinkedList<int>();

        // Add elements
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);

        // Insert an element at the beginning
        linkedList.AddFirst(0);

        // Remove an element
        linkedList.Remove(2);

        // Iterate through the list
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }
    }
}
