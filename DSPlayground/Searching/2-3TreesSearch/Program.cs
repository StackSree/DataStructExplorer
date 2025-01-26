namespace _2_3TreesSearch;

internal class Program
{
    static void Main(string[] args)
    {
        TwoThreeTree tree = new TwoThreeTree();

        // Insert values into the 2-3 Tree
        tree.Insert(10);
        tree.Insert(20);
        //tree.Insert(5);
        //tree.Insert(15);
        //tree.Insert(25);
        //tree.Insert(30);
        //tree.Insert(2);

        // Display the tree in sorted order
        Console.WriteLine("In-order traversal of the 2-3 Tree:");
        tree.InOrderTraversal();

        // Search for values in the tree
        int target = 15;
        Console.WriteLine(tree.Search(target) ? $"Element {target} found in the 2-3 Tree." : $"Element {target} not found in the 2-3 Tree.");

        target = 50;
        Console.WriteLine(tree.Search(target) ? $"Element {target} found in the 2-3 Tree." : $"Element {target} not found in the 2-3 Tree.");
    }
}

internal class TwoThreeTree
{
    class Node
    {
        public int[] Keys = new int[10]; // Max 2 keys
        public Node[] Children = new Node[3]; // Max 3 children
        public int KeyCount = 0; // Current number of keys

        public bool IsLeaf => Children[0] == null; // Check if the node is a leaf
    }

    private Node root;

    // Search for a value in the 2-3 Tree
    public bool Search(int value)
    {
        return SearchNode(root, value);
    }

    private bool SearchNode(Node node, int value)
    {
        if (node == null)
            return false;

        // Traverse the keys in the current node
        for (int i = 0; i < node.KeyCount; i++)
        {
            if (value == node.Keys[i]) // Found the value
                return true;
            else if (value < node.Keys[i]) // Move to the left or middle child
                return SearchNode(node.Children[i], value);
        }

        // If value is greater than all keys, go to the rightmost child
        return SearchNode(node.Children[node.KeyCount], value);
    }

    // Insert a value into the 2-3 Tree
    public void Insert(int value)
    {
        if (root == null)
        {
            root = new Node();
            root.Keys[0] = value;
            root.KeyCount = 1;
        }
        else
        {
            Node newChild = InsertNode(root, value);

            // If the root splits, create a new root
            if (newChild != null)
            {
                Node newRoot = new Node();
                newRoot.Keys[0] = root.Keys[1];
                newRoot.Children[0] = root;
                newRoot.Children[1] = newChild;
                newRoot.KeyCount = 1;
                root = newRoot;
            }
        }
    }

    private Node InsertNode(Node node, int value)
    {
        if (node.IsLeaf)
        {
            // Add value to the node and sort keys
            InsertKeyIntoNode(node, value);
            return node.KeyCount == 3 ? SplitNode(node) : null;
        }

        // Determine which child to traverse
        int i;
        for (i = 0; i < node.KeyCount; i++)
        {
            if (value < node.Keys[i])
                break;
        }

        // Recursively insert into the appropriate child
        Node newChild = InsertNode(node.Children[i], value);

        // If a child split, handle it
        if (newChild != null)
        {
            InsertKeyIntoNode(node, node.Children[i].Keys[1]);
            node.Children[i].KeyCount = 1; // Keep only the first key
            node.Children[i + 1] = newChild; // Link the new child
        }

        return node.KeyCount == 3 ? SplitNode(node) : null;
    }

    // Insert a key into a node in sorted order
    private void InsertKeyIntoNode(Node node, int value)
    {
        int i = node.KeyCount - 1;
        while (i >= 0 && node.Keys[i] > value)
        {
            node.Keys[i + 1] = node.Keys[i];
            i--;
        }
        node.Keys[i + 1] = value;
        node.KeyCount++;
    }

    // Split a node into two nodes
    private Node SplitNode(Node node)
    {
        Node newNode = new Node();
        newNode.Keys[0] = node.Keys[2];
        newNode.Children[0] = node.Children[2];
        newNode.Children[1] = node.Children[3];
        newNode.KeyCount = 1;

        node.KeyCount = 1; // Keep only the first key

        return newNode;
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
            for (int i = 0; i < node.KeyCount; i++)
            {
                InOrderTraversal(node.Children[i]);
                Console.Write(node.Keys[i] + " ");
            }
            InOrderTraversal(node.Children[node.KeyCount]);
        }
    }
}