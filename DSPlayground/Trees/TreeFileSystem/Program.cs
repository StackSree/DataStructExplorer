using System.IO;

namespace TreeFileSystem;

internal class Program
{
    static void Main(string[] args)
    {
        FileNode root = new FileNode("root", true);
        FileNode folder1 = new FileNode("Folder1", true);
        FileNode file1 = new FileNode("File1.txt", false);

        root.AddChild(folder1);
        folder1.AddChild(file1);

        PrintFileSystem(root, 0);
    }

    static void PrintFileSystem(FileNode node, int depth)
    {
        Console.WriteLine(new string('-', depth) + (node.IsDirectory ? "[D] " : "[F] ") + node.Name);
        foreach (var child in node.Children)
        {
            PrintFileSystem(child, depth + 1);
        }
    }
}

public class FileNode
{
    public string Name { get; set; }
    public bool IsDirectory { get; set; }
    public List<FileNode> Children { get; set; }

    public FileNode(string name, bool isDirectory)
    {
        Name = name;
        IsDirectory = isDirectory;
        Children = new List<FileNode>();
    }

    public void AddChild(FileNode child)
    {
        if (IsDirectory)
            Children.Add(child);
        else
            throw new InvalidOperationException("Cannot add children to a file.");
    }
}
