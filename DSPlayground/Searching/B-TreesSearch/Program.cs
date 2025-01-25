namespace B_TreesSearch;

internal class Program
{
    static void Main(string[] args)
    {
        BTree tree = new BTree(3); // Degree of the B-Tree

        // Insert values
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(5);
        tree.Insert(6);
        tree.Insert(12);
        tree.Insert(30);
        tree.Insert(7);
        tree.Insert(17);

        // Display the tree in sorted order
        Console.WriteLine("In-order traversal of the B-Tree:");
        tree.InOrderTraversal();

        // Search for a value
        int target = 12;
        Console.WriteLine(tree.Search(target) ? $"Element {target} found in the B-Tree." : $"Element {target} not found in the B-Tree.");
    }
}
class BTree
{
    // B-Tree Node structure
    public class BTreeNode
    {
        public int[] Keys; // Array of keys
        public BTreeNode[] Children; // Array of child pointers
        public int KeyCount; // Current number of keys
        public bool IsLeaf; // True if the node is a leaf

        public BTreeNode(int degree, bool isLeaf)
        {
            Keys = new int[2 * degree - 1]; // Maximum keys = 2*degree - 1
            Children = new BTreeNode[2 * degree]; // Maximum children = 2*degree
            KeyCount = 0;
            IsLeaf = isLeaf;
        }
    }

    private readonly int degree; // Minimum degree (defines the range of keys in a node)
    private BTreeNode root;

    public BTree(int degree)
    {
        this.degree = degree;
        root = null;
    }

    // Search for a key in the B-Tree
    public bool Search(int key)
    {
        return root != null && SearchKey(root, key) != null;
    }

    private BTreeNode SearchKey(BTreeNode node, int key)
    {
        int i = 0;

        // Find the first key greater than or equal to the target key
        while (i < node.KeyCount && key > node.Keys[i])
            i++;

        // If the key is found, return the node
        if (i < node.KeyCount && node.Keys[i] == key)
            return node;

        // If the node is a leaf, the key is not present
        if (node.IsLeaf)
            return null;

        // Otherwise, recurse into the appropriate child
        return SearchKey(node.Children[i], key);
    }

    // Insert a new key into the B-Tree
    public void Insert(int key)
    {
        if (root == null)
        {
            // Create a new root if the tree is empty
            root = new BTreeNode(degree, true);
            root.Keys[0] = key;
            root.KeyCount = 1;
        }
        else
        {
            // If the root is full, grow the tree by splitting
            if (root.KeyCount == 2 * degree - 1)
            {
                BTreeNode newRoot = new BTreeNode(degree, false);

                // Make the old root a child of the new root
                newRoot.Children[0] = root;

                // Split the old root and move a key to the new root
                SplitChild(newRoot, 0, root);

                // Update the root
                root = newRoot;
            }

            // Insert the key into the non-full root
            InsertNonFull(root, key);
        }
    }

    // Insert a key into a non-full node
    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.KeyCount - 1;

        if (node.IsLeaf)
        {
            // Shift keys to make space for the new key
            while (i >= 0 && key < node.Keys[i])
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }

            // Insert the new key
            node.Keys[i + 1] = key;
            node.KeyCount++;
        }
        else
        {
            // Find the child where the key should be inserted
            while (i >= 0 && key < node.Keys[i])
                i--;

            i++;

            // If the child is full, split it
            if (node.Children[i].KeyCount == 2 * degree - 1)
            {
                SplitChild(node, i, node.Children[i]);

                // After splitting, the middle key goes up, so decide which child to insert into
                if (key > node.Keys[i])
                    i++;
            }

            // Recur into the appropriate child
            InsertNonFull(node.Children[i], key);
        }
    }

    // Split a full child node
    private void SplitChild(BTreeNode parent, int index, BTreeNode child)
    {
        BTreeNode newChild = new BTreeNode(degree, child.IsLeaf);
        newChild.KeyCount = degree - 1;

        // Copy the last (degree - 1) keys of the child to the new child
        for (int j = 0; j < degree - 1; j++)
            newChild.Keys[j] = child.Keys[j + degree];

        // Copy the last (degree) children of the child to the new child
        if (!child.IsLeaf)
        {
            for (int j = 0; j < degree; j++)
                newChild.Children[j] = child.Children[j + degree];
        }

        child.KeyCount = degree - 1;

        // Shift children of the parent to make space for the new child
        for (int j = parent.KeyCount; j >= index + 1; j--)
            parent.Children[j + 1] = parent.Children[j];

        // Link the new child to the parent
        parent.Children[index + 1] = newChild;

        // Shift keys of the parent to make space for the new key
        for (int j = parent.KeyCount - 1; j >= index; j--)
            parent.Keys[j + 1] = parent.Keys[j];

        // Move the middle key of the child to the parent
        parent.Keys[index] = child.Keys[degree - 1];
        parent.KeyCount++;
    }

    // In-order traversal for testing
    public void InOrderTraversal()
    {
        if (root != null)
            InOrderTraversal(root);
        Console.WriteLine();
    }

    private void InOrderTraversal(BTreeNode node)
    {
        for (int i = 0; i < node.KeyCount; i++)
        {
            if (!node.IsLeaf)
                InOrderTraversal(node.Children[i]);
            Console.Write(node.Keys[i] + " ");
        }

        if (!node.IsLeaf)
            InOrderTraversal(node.Children[node.KeyCount]);
    }
}


