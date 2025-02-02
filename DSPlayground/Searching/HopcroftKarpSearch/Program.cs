namespace HopcroftKarpSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int U = 4, V = 4; // Left and right partition sizes
        HopcroftKarp graph = new HopcroftKarp(U, V);

        // Adding edges between left and right partition
        graph.AddEdge(1, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 1);
        graph.AddEdge(3, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(4, 3);

        Console.WriteLine("Maximum Bipartite Matching: " + graph.MaximumMatching());
    }
}

public class HopcroftKarp
{
    private int U, V; // Number of vertices in left and right partitions
    private List<int>[] adj; // Adjacency list
    private int[] pairU, pairV, dist; // Matching pairs and distances

    public HopcroftKarp(int U, int V)
    {
        this.U = U;
        this.V = V;
        adj = new List<int>[U + 1];
        for (int i = 0; i <= U; i++)
        {
            adj[i] = new List<int>();
        }
        pairU = new int[U + 1];
        pairV = new int[V + 1];
        dist = new int[U + 1];
    }

    // Add an edge from left partition (u) to right partition (v)
    public void AddEdge(int u, int v)
    {
        adj[u].Add(v);
    }

    // BFS to find shortest augmenting path
    private bool BFS()
    {
        Queue<int> queue = new Queue<int>();
        for (int u = 1; u <= U; u++)
        {
            if (pairU[u] == 0)
            {
                dist[u] = 0;
                queue.Enqueue(u);
            }
            else
            {
                dist[u] = int.MaxValue;
            }
        }
        dist[0] = int.MaxValue;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            if (dist[u] < dist[0])
            {
                foreach (int v in adj[u])
                {
                    if (dist[pairV[v]] == int.MaxValue)
                    {
                        dist[pairV[v]] = dist[u] + 1;
                        queue.Enqueue(pairV[v]);
                    }
                }
            }
        }
        return dist[0] != int.MaxValue;
    }

    // DFS to find augmenting path
    private bool DFS(int u)
    {
        if (u != 0)
        {
            foreach (int v in adj[u])
            {
                if (dist[pairV[v]] == dist[u] + 1 && DFS(pairV[v]))
                {
                    pairV[v] = u;
                    pairU[u] = v;
                    return true;
                }
            }
            dist[u] = int.MaxValue;
            return false;
        }
        return true;
    }

    // Main function to find maximum matching
    public int MaximumMatching()
    {
        Array.Fill(pairU, 0);
        Array.Fill(pairV, 0);

        int matching = 0;
        while (BFS())
        {
            for (int u = 1; u <= U; u++)
            {
                if (pairU[u] == 0 && DFS(u))
                {
                    matching++;
                }
            }
        }
        return matching;
    }
}
