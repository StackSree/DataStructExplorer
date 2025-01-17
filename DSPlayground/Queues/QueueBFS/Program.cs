namespace QueueBFS;

internal class Program
{
    static void Main(string[] args)
    {
        // Representing a graph as an adjacency list
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            { 0, new List<int> { 1, 2 } },
            { 1, new List<int> { 3, 4 } },
            { 2, new List<int> { 5 } },
            { 3, new List<int>() },
            { 4, new List<int>() },
            { 5, new List<int>() }
        };

        // Perform BFS starting from node 0
        Console.WriteLine("Breadth-First Search (BFS):");
        BFS(graph, 0);
    }

    static void BFS(Dictionary<int, List<int>> graph, int start)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.WriteLine(node);

            foreach (int neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }
    }
}