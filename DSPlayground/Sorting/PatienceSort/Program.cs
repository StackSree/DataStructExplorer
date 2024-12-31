namespace PatienceSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 7, 3, 8, 4, 2, 6, 1, 5 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        List<int> sortedArray = PatienceSortMain(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", sortedArray));
    }
    public static List<int> PatienceSortMain(int[] array)
    {
        // Step 1: Create the piles
        List<Stack<int>> piles = new List<Stack<int>>();

        foreach (var num in array)
        {
            bool placed = false;

            // Try to place the number on an existing pile
            foreach (var pile in piles)
            {
                if (pile.Peek() >= num)
                {
                    pile.Push(num);
                    placed = true;
                    break;
                }
            }

            // If not placed, start a new pile
            if (!placed)
            {
                Stack<int> newPile = new Stack<int>();
                newPile.Push(num);
                piles.Add(newPile);
            }
        }

        // Step 2: Merge the piles using a priority queue (min-heap)
        List<int> sortedList = new List<int>();
        PriorityQueue<(int Value, Stack<int> Pile)> pq = new PriorityQueue<(int, Stack<int>)>();

        // Initialize the priority queue with the top of each pile
        foreach (var pile in piles)
        {
            pq.Enqueue((pile.Pop(), pile));
        }

        // Extract from the priority queue to create the sorted list
        while (pq.Count > 0)
        {
            var (value, pile) = pq.Dequeue();
            sortedList.Add(value);

            if (pile.Count > 0)
            {
                pq.Enqueue((pile.Pop(), pile));
            }
        }

        return sortedList;
    }

}
public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly List<T> heap = new List<T>();

    public int Count => heap.Count;

    public void Enqueue(T item)
    {
        heap.Add(item);
        int i = heap.Count - 1;

        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (heap[i].CompareTo(heap[parent]) >= 0) break;

            (heap[i], heap[parent]) = (heap[parent], heap[i]);
            i = parent;
        }
    }

    public T Dequeue()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Queue is empty.");

        T root = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);

        int i = 0;
        while (true)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;

            if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest == i) break;

            (heap[i], heap[smallest]) = (heap[smallest], heap[i]);
            i = smallest;
        }

        return root;
    }
}
