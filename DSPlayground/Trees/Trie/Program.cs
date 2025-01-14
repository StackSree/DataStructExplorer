namespace Trie;

internal class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();

        // Insert words
        trie.Insert("apple");
        trie.Insert("app");
        trie.Insert("bat");

        // Search words
        Console.WriteLine(trie.Search("app")); // True
        Console.WriteLine(trie.Search("appl")); // False
        Console.WriteLine(trie.StartsWith("ap")); // True
        Console.WriteLine(trie.StartsWith("bat")); // True
    }
}

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        var current = _root;
        foreach (var ch in word)
        {
            if (!current.Children.ContainsKey(ch))
                current.Children[ch] = new TrieNode();

            current = current.Children[ch];
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var current = _root;
        foreach (var ch in word)
        {
            if (!current.Children.ContainsKey(ch))
                return false;

            current = current.Children[ch];
        }
        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = _root;
        foreach (var ch in prefix)
        {
            if (!current.Children.ContainsKey(ch))
                return false;

            current = current.Children[ch];
        }
        return true;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}
