namespace TreesDefault;

internal class Program
{
    static void Main(string[] args)
    {
        // Create nodes
        TreeNode<string> root = new TreeNode<string>("Root");
        TreeNode<string> child1 = new TreeNode<string>("Child 1");
        TreeNode<string> child2 = new TreeNode<string>("Child 2");

        // Build the tree
        root.AddChild(child1);
        root.AddChild(child2);
        child1.AddChild(new TreeNode<string>("Child 1.1"));
        child1.AddChild(new TreeNode<string>("Child 1.2"));

        // Traverse the tree
        PrintTree(root, 0);
    }

    static void PrintTree(TreeNode<string> node, int depth)
    {
        Console.WriteLine(new string('-', depth) + node.Data);
        foreach (var child in node.Children)
        {
            PrintTree(child, depth + 1);
        }
    }
}
public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }

    // Add a child to the node
    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }
}
