namespace BellmanFordAlgoSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int vertices = 5; // Number of vertices in the graph
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, -1),
            new Edge(0, 2, 4),
            new Edge(1, 2, 3),
            new Edge(1, 3, 2),
            new Edge(1, 4, 2),
            new Edge(3, 2, 5),
            new Edge(3, 1, 1),
            new Edge(4, 3, -3)
        };

        int source = 0; // Source vertex

        Console.WriteLine("Running Bellman-Ford Algorithm:");
        BellmanFord(edges, vertices, source);
    }

    public static void BellmanFord(List<Edge> edges, int vertices, int source)
    {
        // Step 1: Initialize distances from source to all vertices as infinity
        int[] distance = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            distance[i] = int.MaxValue;
        }
        distance[source] = 0;

        // Step 2: Relax all edges |V| - 1 times
        for (int i = 1; i < vertices; i++)
        {
            foreach (var edge in edges)
            {
                if (distance[edge.Source] != int.MaxValue &&
                    distance[edge.Source] + edge.Weight < distance[edge.Destination])
                {
                    distance[edge.Destination] = distance[edge.Source] + edge.Weight;
                }
            }
        }

        // Step 3: Check for negative-weight cycles
        foreach (var edge in edges)
        {
            if (distance[edge.Source] != int.MaxValue &&
                distance[edge.Source] + edge.Weight < distance[edge.Destination])
            {
                Console.WriteLine("Graph contains a negative weight cycle.");
                return;
            }
        }

        // Step 4: Print the distances
        PrintSolution(distance, vertices);
    }

    // Function to print the distances
    private static void PrintSolution(int[] distance, int vertices)
    {
        Console.WriteLine("Vertex\tDistance from Source");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine($"{i}\t{(distance[i] == int.MaxValue ? "INF" : distance[i].ToString())}");
        }
    }
}
public class Edge
{
    public int Source, Destination, Weight;

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }
}

// Function to find the shortest path using Bellman-Ford

