namespace TreeDFSIterative;

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
        Console.WriteLine("Iterative DFS:");
        IterativeDFS(root);
    }

    static void IterativeDFS(TreeNode<string> root)
    {
        if (root == null)
            return;

        // Stack to hold nodes to visit
        var stack = new Stack<TreeNode<string>>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            // Process the current node
            Console.WriteLine(current.Data);

            // Push children to the stack (reverse order to process leftmost first)
            for (int i = current.Children.Count - 1; i >= 0; i--)
            {
                stack.Push(current.Children[i]);
            }
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
