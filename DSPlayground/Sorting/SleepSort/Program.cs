namespace SleepSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 3, 9, 1, 4 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        Console.WriteLine("\nSorted output:");
        PerformSleepSort(array);
    }

    // Method to perform Sleep Sort
    public static void PerformSleepSort(int[] array)
    {
        List<Thread> threads = new List<Thread>();

        foreach (int number in array)
        {
            // Create a new thread for each number
            Thread thread = new Thread(() => SleepAndPrint(number));
            threads.Add(thread);
            thread.Start();
        }

        // Wait for all threads to complete
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

    // Method to simulate "sleep" and print the number
    private static void SleepAndPrint(int number)
    {
        // Sleep for a duration proportional to the number
        Thread.Sleep(number * 10); // Adjust multiplier to handle larger numbers
        Console.WriteLine(number);
    }
}
