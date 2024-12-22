namespace TreeSort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 3, 7, 2, 8, 1, 6 };

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        var treeSort = new TreeSorter();
        treeSort.Sort(array);

        Console.WriteLine("\nSorted array:");
        Console.WriteLine(string.Join(" ", array));
    }
}

class TreeSorter
{
    private TreeNode root;

    // Insert a value into the BST
    private void Insert(int value)
    {
        root = InsertRecursive(root, value);
    }

    private TreeNode InsertRecursive(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }

    // Perform in-order traversal to retrieve sorted elements
    private void InOrderTraversal(TreeNode node, int[] sortedArray, ref int index)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, sortedArray, ref index);
            sortedArray[index++] = node.Value;
            InOrderTraversal(node.Right, sortedArray, ref index);
        }
    }

    public void Sort(int[] array)
    {
        // Build the BST
        foreach (int value in array)
        {
            Insert(value);
        }

        // Retrieve sorted elements using in-order traversal
        int index = 0;
        InOrderTraversal(root, array, ref index);
    }

    class TreeNode
    {
        public int Value;
        public TreeNode Left, Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }
}
