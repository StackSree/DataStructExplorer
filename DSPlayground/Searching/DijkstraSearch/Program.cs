namespace DijkstraSearch;

internal class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        // Add edges: graph.AddEdge(from, to, weight);
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 2, 1);
        graph.AddEdge(2, 1, 2);
        graph.AddEdge(1, 3, 1);
        graph.AddEdge(2, 3, 5);

        Console.WriteLine("Dijkstra's Algorithm:");
        graph.Dijkstra(0);
    }

}

class Graph
{
    private Dictionary<int, List<(int neighbor, int weight)>> adjList;

    public Graph()
    {
        adjList = new Dictionary<int, List<(int, int)>>();
    }

    public void AddEdge(int u, int v, int weight)
    {
        if (!adjList.ContainsKey(u))
            adjList[u] = new List<(int, int)>();

        adjList[u].Add((v, weight));

        // Ensure the target node exists in the adjacency list
        if (!adjList.ContainsKey(v))
            adjList[v] = new List<(int, int)>();

        // Uncomment for undirected graph
        // if (!adjList.ContainsKey(v))
        //     adjList[v] = new List<(int, int)>();
        // adjList[v].Add((u, weight));
    }

    public void Dijkstra(int start)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new SortedSet<(int distance, int node)>();
        var visited = new HashSet<int>();

        // Initialize distances to infinity
        foreach (var key in adjList.Keys)
            distances[key] = int.MaxValue;

        // Distance to the source is 0
        distances[start] = 0;
        priorityQueue.Add((0, start));

        while (priorityQueue.Count > 0)
        {
            // Extract node with the smallest distance
            var (currentDistance, currentNode) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            // Skip if already visited
            if (visited.Contains(currentNode))
                continue;

            visited.Add(currentNode);

            // Process all neighbors
            foreach (var (neighbor, weight) in adjList[currentNode])
            {
                int newDistance = currentDistance + weight;

                // Update the distance if a shorter path is found
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    priorityQueue.Add((newDistance, neighbor));
                }
            }
        }

        // Print the shortest distances
        foreach (var kvp in distances)
            Console.WriteLine($"Distance from {start} to {kvp.Key}: {kvp.Value}");
    }   
}
