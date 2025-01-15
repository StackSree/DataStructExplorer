namespace Tree_DFS;

internal class Program
{
    static void Main(string[] args)
    {
        // Create a tree
        TreeNode<string> root = new TreeNode<string>("Root");
        TreeNode<string> child1 = new TreeNode<string>("Child 1");
        TreeNode<string> child2 = new TreeNode<string>("Child 2");
        root.AddChild(child1);
        root.AddChild(child2);
        child1.AddChild(new TreeNode<string>("Child 1.1"));
        child1.AddChild(new TreeNode<string>("Child 1.2"));
        child2.AddChild(new TreeNode<string>("Child 2.1"));

        // Perform DFS
        Console.WriteLine("Recursive DFS:");
        RecursiveDFS(root);
    }

    static void RecursiveDFS(TreeNode<string> node)
    {
        if (node == null)
            return;

        // Process the current node
        Console.WriteLine(node.Data);

        // Recursively call DFS for each child
        foreach (var child in node.Children)
        {
            RecursiveDFS(child);
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

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }
}
