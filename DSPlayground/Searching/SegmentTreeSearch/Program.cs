namespace SegmentTreeSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        SegmentTree segTree = new SegmentTree(arr);

        Console.WriteLine("Sum of range [1, 4]: " + segTree.Query(1, 4)); // Output: 3+5+7+9 = 24

        segTree.Update(2, 6); // Change arr[2] from 5 to 6

        Console.WriteLine("Sum of range [1, 4] after update: " + segTree.Query(1, 4)); // Output: 3+6+7+9 = 25
    }
}
public class SegmentTree
{
    private int[] tree;
    private int n;

    public SegmentTree(int[] arr)
    {
        n = arr.Length;
        tree = new int[4 * n]; // Allocating space for segment tree
        Build(arr, 0, 0, n - 1);
    }

    // Build the Segment Tree
    private void Build(int[] arr, int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = arr[start]; // Leaf node
        }
        else
        {
            int mid = (start + end) / 2;
            Build(arr, 2 * node + 1, start, mid);
            Build(arr, 2 * node + 2, mid + 1, end);
            tree[node] = tree[2 * node + 1] + tree[2 * node + 2]; // Sum of child nodes
        }
    }

    // Range Sum Query
    public int Query(int left, int right)
    {
        return QueryHelper(0, 0, n - 1, left, right);
    }

    private int QueryHelper(int node, int start, int end, int left, int right)
    {
        if (right < start || left > end) return 0; // Out of range
        if (left <= start && end <= right) return tree[node]; // Fully within range

        int mid = (start + end) / 2;
        int leftSum = QueryHelper(2 * node + 1, start, mid, left, right);
        int rightSum = QueryHelper(2 * node + 2, mid + 1, end, left, right);

        return leftSum + rightSum;
    }

    // Point Update
    public void Update(int index, int newValue)
    {
        UpdateHelper(0, 0, n - 1, index, newValue);
    }

    private void UpdateHelper(int node, int start, int end, int index, int newValue)
    {
        if (start == end)
        {
            tree[node] = newValue; // Update leaf node
        }
        else
        {
            int mid = (start + end) / 2;
            if (index <= mid)
                UpdateHelper(2 * node + 1, start, mid, index, newValue);
            else
                UpdateHelper(2 * node + 2, mid + 1, end, index, newValue);

            tree[node] = tree[2 * node + 1] + tree[2 * node + 2]; // Update parent nodes
        }
    }

    // Print the segment tree for debugging
    public void PrintTree()
    {
        Console.WriteLine(string.Join(", ", tree));
    }
}
