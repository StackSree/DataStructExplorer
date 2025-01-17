namespace QueueDefault;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<string> queue = new Queue<string>();

        // Add elements to the queue
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        // Display the elements in the queue
        Console.WriteLine("Initial queue:");
        foreach (string item in queue)
        {
            Console.WriteLine(item);
        }

        // Remove the first element
        string dequeuedItem = queue.Dequeue();
        Console.WriteLine($"\nDequeued: {dequeuedItem}");

        // Peek at the first element without removing it
        string peekedItem = queue.Peek();
        Console.WriteLine($"\nPeeked: {peekedItem}");

        // Display the remaining elements
        Console.WriteLine("\nQueue after dequeue:");
        foreach (string item in queue)
        {
            Console.WriteLine(item);
        }

        // Display the number of elements in the queue
        Console.WriteLine($"\nCount: {queue.Count}");
    }
}
