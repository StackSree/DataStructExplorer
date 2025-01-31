namespace CartesianTreeSearch;

internal class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 5, 10, 40, 30, 28 };
        CartesianTree tree = new CartesianTree();
        tree.ConstructTree(arr);

        Console.WriteLine("Inorder Traversal (should match original array):");
        tree.PrintInOrder(tree.Root);
        Console.WriteLine();

        // Search in Cartesian Tree
        int searchValue = 30;
        Console.WriteLine($"Searching for {searchValue}: " + (tree.Search(tree.Root, searchValue) ? "Found" : "Not Found"));

    }
}
public class CartesianTree
{
    public class Node
    {
        public int Value;
        public Node Left, Right;

        public Node(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }

    public Node Root;

    // Construct Cartesian Tree (Recursive Approach)
    private Node BuildCartesianTree(int[] arr, int start, int end)
    {
        if (start > end)
            return null;

        // Find the minimum value index
        int minIndex = start;
        for (int i = start + 1; i <= end; i++)
        {
            if (arr[i] < arr[minIndex])
                minIndex = i;
        }

        // Create node with the minimum value
        Node node = new Node(arr[minIndex]);

        // Recursively construct left and right subtrees
        node.Left = BuildCartesianTree(arr, start, minIndex - 1);
        node.Right = BuildCartesianTree(arr, minIndex + 1, end);

        return node;
    }

    public void ConstructTree(int[] arr)
    {
        Root = BuildCartesianTree(arr, 0, arr.Length - 1);
    }

    // Search function in Cartesian Tree
    public bool Search(Node node, int key)
    {
        if (node == null)
            return false;

        if (node.Value == key)
            return true;

        // Search in left and right subtrees
        return Search(node.Left, key) || Search(node.Right, key);
    }

    public void PrintInOrder(Node node)
    {
        if (node == null)
            return;

        PrintInOrder(node.Left);
        Console.Write(node.Value + " ");
        PrintInOrder(node.Right);
    }
}
