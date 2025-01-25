namespace RedBlackTreeSearch;

internal class Program
{
    static void Main(string[] args)
    {
        RedBlackTree tree = new RedBlackTree();

        // Insert values
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
        tree.Insert(40);
        tree.Insert(50);
        tree.Insert(25);

        // Display the tree in sorted order
        Console.WriteLine("In-order traversal of the Red-Black Tree:");
        tree.InOrderTraversal();

        // Search for a value
        int target = 25;
        Console.WriteLine(tree.Search(target) ? $"Element {target} found in the Red-Black Tree." : $"Element {target} not found in the Red-Black Tree.");
    }

    class RedBlackTree
    {
        // Node structure
        class Node
        {
            public int Value;
            public Node Left, Right, Parent;
            public bool IsRed; // True for Red, False for Black

            public Node(int value)
            {
                Value = value;
                IsRed = true; // New nodes are red by default
            }
        }

        private Node root;

        // Function to perform a search in the Red-Black Tree
        public bool Search(int value)
        {
            Node result = SearchNode(root, value);
            return result != null;
        }

        private Node SearchNode(Node node, int value)
        {
            if (node == null || node.Value == value)
                return node;

            if (value < node.Value)
                return SearchNode(node.Left, value);

            return SearchNode(node.Right, value);
        }

        // Insert a value into the Red-Black Tree
        public void Insert(int value)
        {
            Node newNode = new Node(value);
            root = BSTInsert(root, newNode);
            FixInsert(newNode);
        }

        // Standard BST insert
        private Node BSTInsert(Node root, Node newNode)
        {
            if (root == null)
                return newNode;

            if (newNode.Value < root.Value)
            {
                root.Left = BSTInsert(root.Left, newNode);
                root.Left.Parent = root;
            }
            else if (newNode.Value > root.Value)
            {
                root.Right = BSTInsert(root.Right, newNode);
                root.Right.Parent = root;
            }

            return root;
        }

        // Fix Red-Black Tree properties after insertion
        private void FixInsert(Node node)
        {
            while (node != root && node.Parent.IsRed)
            {
                Node grandparent = node.Parent.Parent;

                if (node.Parent == grandparent.Left)
                {
                    Node uncle = grandparent.Right;

                    // Case 1: Uncle is red
                    if (uncle != null && uncle.IsRed)
                    {
                        node.Parent.IsRed = false;
                        uncle.IsRed = false;
                        grandparent.IsRed = true;
                        node = grandparent;
                    }
                    else
                    {
                        // Case 2: Node is right child
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        // Case 3: Node is left child
                        node.Parent.IsRed = false;
                        grandparent.IsRed = true;
                        RotateRight(grandparent);
                    }
                }
                else
                {
                    Node uncle = grandparent.Left;

                    // Mirror cases for the right side
                    if (uncle != null && uncle.IsRed)
                    {
                        node.Parent.IsRed = false;
                        uncle.IsRed = false;
                        grandparent.IsRed = true;
                        node = grandparent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.IsRed = false;
                        grandparent.IsRed = true;
                        RotateLeft(grandparent);
                    }
                }
            }

            root.IsRed = false; // Root must always be black
        }

        // Left rotation
        private void RotateLeft(Node node)
        {
            Node rightNode = node.Right;
            node.Right = rightNode.Left;

            if (rightNode.Left != null)
                rightNode.Left.Parent = node;

            rightNode.Parent = node.Parent;

            if (node.Parent == null)
                root = rightNode;
            else if (node == node.Parent.Left)
                node.Parent.Left = rightNode;
            else
                node.Parent.Right = rightNode;

            rightNode.Left = node;
            node.Parent = rightNode;
        }

        // Right rotation
        private void RotateRight(Node node)
        {
            Node leftNode = node.Left;
            node.Left = leftNode.Right;

            if (leftNode.Right != null)
                leftNode.Right.Parent = node;

            leftNode.Parent = node.Parent;

            if (node.Parent == null)
                root = leftNode;
            else if (node == node.Parent.Left)
                node.Parent.Left = leftNode;
            else
                node.Parent.Right = leftNode;

            leftNode.Right = node;
            node.Parent = leftNode;
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
}
