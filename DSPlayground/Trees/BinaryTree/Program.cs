namespace BinaryTree;

internal class Program
{
    static void Main(string[] args)
    {
        // Create a binary search tree
        var bst = new BinaryTreeNode<int>(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(60);
        bst.Insert(80);

        // Search for a value
        Console.WriteLine(bst.Search(40) ? "Found 40" : "40 not found");

        // Print the tree in sorted order
        Console.WriteLine("In-order Traversal:");
        bst.InOrderTraversal();

        // Print the tree in sorted order
        Console.WriteLine("Pre-order Traversal:");
        bst.PreOrderTraversal();
    }
}
public class BinaryTreeNode<T> where T : IComparable<T>
{
    public T Data { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }

    public BinaryTreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public void Insert(T value)
    {
        if (value.CompareTo(Data) < 0)
        {
            if (Left == null)
                Left = new BinaryTreeNode<T>(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new BinaryTreeNode<T>(value);
            else
                Right.Insert(value);
        }
    }

    public bool Search(T value)
    {
        if (Data.Equals(value))
            return true;

        if (value.CompareTo(Data) < 0)
            return Left?.Search(value) ?? false;

        return Right?.Search(value) ?? false;
    }

    public void InOrderTraversal()
    {
        Left?.InOrderTraversal();
        Console.WriteLine(Data);
        Right?.InOrderTraversal();
    }

    public void PreOrderTraversal()
    {
        Console.WriteLine(Data);
        Left?.PreOrderTraversal();
        Right?.PreOrderTraversal();
    }
}
