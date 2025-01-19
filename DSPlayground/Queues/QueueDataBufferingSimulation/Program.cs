namespace QueueDataBufferingSimulation;

internal class Program
{
    static void Main(string[] args)
    {

            Queue<string> dataBuffer = new Queue<string>();

            // Simulating adding data to the buffer
            Console.WriteLine("Adding data to the buffer...");
            dataBuffer.Enqueue("Data Packet 1");
            dataBuffer.Enqueue("Data Packet 2");
            dataBuffer.Enqueue("Data Packet 3");

            // Processing the buffered data
            Console.WriteLine("\nProcessing buffered data:");
            while (dataBuffer.Count > 0)
            {
                string data = dataBuffer.Dequeue();
                Console.WriteLine($"Processing {data}");
            }

            Console.WriteLine("\nBuffer empty.");
        
    }
}
