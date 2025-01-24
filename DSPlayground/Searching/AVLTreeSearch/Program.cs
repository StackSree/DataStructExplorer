namespace AVLTreeSearch;

internal class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();

        // Insert values into the AVL tree
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
        tree.Insert(40);
        tree.Insert(50);
        tree.Insert(25);

        // Display the AVL tree in sorted order
        Console.WriteLine("In-order traversal of the AVL tree:");
        tree.InOrderTraversal();

        // Search for a value in the AVL tree
        int target = 25;
        Console.WriteLine(tree.Search(target) ? $"Element {target} found in the AVL tree." : $"Element {target} not found in the AVL tree.");
    }
}

public class AVLTree
{
    // Node structure
    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public int Height;

        public Node(int value)
        {
            Value = value;
            Height = 1;
        }
    }

    private Node root;

    // Utility function to get the height of a node
    private int GetHeight(Node node)
    {
        return node == null ? 0 : node.Height;
    }

    // Utility function to get the balance factor of a node
    private int GetBalanceFactor(Node node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    // Rotate right
    private Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        // Perform rotation
        x.Right = y;
        y.Left = T2;

        // Update heights
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    // Rotate left
    private Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        // Perform rotation
        y.Left = x;
        x.Right = T2;

        // Update heights
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    // Insert a value into the AVL tree
    public void Insert(int value)
    {
        root = InsertNode(root, value);
    }

    private Node InsertNode(Node node, int value)
    {
        // Standard BST insertion
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = InsertNode(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertNode(node.Right, value);
        else
            return node; // Duplicate values are not allowed

        // Update height of the ancestor node
        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

        // Get the balance factor to check whether this node is unbalanced
        int balance = GetBalanceFactor(node);

        // Left Left Case
        if (balance > 1 && value < node.Left.Value)
            return RotateRight(node);

        // Right Right Case
        if (balance < -1 && value > node.Right.Value)
            return RotateLeft(node);

        // Left Right Case
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        // Right Left Case
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    // Search for a value in the AVL tree
    public bool Search(int value)
    {
        return SearchNode(root, value) != null;
    }

    private Node SearchNode(Node node, int value)
    {
        if (node == null || node.Value == value)
            return node;

        if (value < node.Value)
            return SearchNode(node.Left, value);

        return SearchNode(node.Right, value);
    }

    // In-order traversal for testing
    public void InOrderTraversal()
    {
        InOrderTraversal(root);
        Console.WriteLine();
    }

    private void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }
}
