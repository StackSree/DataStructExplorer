namespace WildcardSearchTrie;

internal class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();
        string[] words = { "apple", "ape", "apex", "bat", "bath", "batman" };

        Console.WriteLine("Inserting words into Trie...");
        foreach (string word in words)
        {
            trie.Insert(word);
        }

        string[] patterns = { "a?e", "ba*", "b?th", "*man", "appl?", "b*t" };

        Console.WriteLine("\nWildcard Searches:");
        foreach (string pattern in patterns)
        {
            Console.WriteLine($"Pattern: \"{pattern}\" -> Found: {trie.Search(pattern)}");
        }
    }
}

public class Trie
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord;
    }

    private readonly TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    // Insert a word into the Trie
    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char ch in word)
        {
            if (!node.Children.ContainsKey(ch))
                node.Children[ch] = new TrieNode();
            node = node.Children[ch];
        }
        node.IsEndOfWord = true;
    }

    // Wildcard search
    public bool Search(string pattern)
    {
        return SearchHelper(pattern, 0, root);
    }

    private bool SearchHelper(string pattern, int index, TrieNode node)
    {
        if (node == null)
            return false;

        if (index == pattern.Length)
            return node.IsEndOfWord;

        char ch = pattern[index];

        if (ch == '?') // Match any single character
        {
            foreach (var child in node.Children.Values)
            {
                if (SearchHelper(pattern, index + 1, child))
                    return true;
            }
        }
        else if (ch == '*') // Match zero or more characters
        {
            // Try skipping '*' (move forward) or consuming a character (try all children)
            if (SearchHelper(pattern, index + 1, node))
                return true;

            foreach (var child in node.Children.Values)
            {
                if (SearchHelper(pattern, index, child)) // Keep '*' and explore deeper
                    return true;
            }
        }
        else // Match exact character
        {
            if (node.Children.ContainsKey(ch))
                return SearchHelper(pattern, index + 1, node.Children[ch]);
        }

        return false;
    }
}
