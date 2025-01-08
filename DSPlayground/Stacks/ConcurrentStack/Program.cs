using System.Collections.Concurrent;

namespace ConcurrentStack;

internal class Program
{
    static void Main(string[] args)
    {
        // Create a ConcurrentStack to hold tasks
        var taskStack = new ConcurrentStack<string>();

        // Add initial tasks to the stack
        taskStack.Push("Task 1");
        taskStack.Push("Task 2");
        taskStack.Push("Task 3");

        Console.WriteLine("Initial tasks added to the stack.");

        // Create multiple threads to work with the stack
        Task[] workers = new Task[3];

        for (int i = 0; i < workers.Length; i++)
        {
            int workerId = i + 1; // Worker ID for display
            workers[i] = Task.Run(() =>
            {
                while (!taskStack.IsEmpty)
                {
                    // Try to pop a task from the stack
                    if (taskStack.TryPop(out string task))
                    {
                        Console.WriteLine($"Worker {workerId} processing {task}");
                        Thread.Sleep(1000); // Simulate task processing
                    }
                    else
                    {
                        Console.WriteLine($"Worker {workerId} found no task to process.");
                    }
                }
            });
        }

        // Wait for all workers to complete
        Task.WaitAll(workers);

        Console.WriteLine("All tasks processed.");
    }
}