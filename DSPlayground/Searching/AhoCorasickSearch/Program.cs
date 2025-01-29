namespace AhoCorasickSearch;

internal class Program
{
    static void Main(string[] args)
    {
        AhoCorasick ahoCorasick = new AhoCorasick();

        // Insert multiple patterns
        string[] patterns = { "he", "she", "his", "hers" };
        foreach (var pattern in patterns)
        {
            ahoCorasick.InsertPattern(pattern);
        }

        // Build failure links for efficient searching
        ahoCorasick.BuildFailureLinks();

        // Text to search in
        string text = "ahishers";

        Console.WriteLine($"Text: \"{text}\"");
        Console.WriteLine("Searching for patterns using Aho-Corasick Algorithm...");
        ahoCorasick.Search(text);
    }
}
public class AhoCorasick
{
    // Trie node structure
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public TrieNode FailureLink = null;
        public List<string> Patterns = new List<string>(); // Stores matched patterns at this node
    }

    private TrieNode root;

    public AhoCorasick()
    {
        root = new TrieNode();
    }

    // Insert a pattern into the Trie
    public void InsertPattern(string pattern)
    {
        TrieNode current = root;

        foreach (char ch in pattern)
        {
            if (!current.Children.ContainsKey(ch))
            {
                current.Children[ch] = new TrieNode();
            }
            current = current.Children[ch];
        }

        current.Patterns.Add(pattern); // Mark end of pattern
    }

    // Build failure links using BFS
    public void BuildFailureLinks()
    {
        Queue<TrieNode> queue = new Queue<TrieNode>();

        // Set failure links for depth-1 nodes to root
        foreach (var pair in root.Children)
        {
            pair.Value.FailureLink = root;
            queue.Enqueue(pair.Value);
        }

        while (queue.Count > 0)
        {
            TrieNode current = queue.Dequeue();

            foreach (var pair in current.Children)
            {
                char ch = pair.Key;
                TrieNode child = pair.Value;
                TrieNode failure = current.FailureLink;

                // Traverse failure links until we find a node that has this character as a child
                while (failure != null && !failure.Children.ContainsKey(ch))
                {
                    failure = failure.FailureLink;
                }

                // If found, set failure link
                child.FailureLink = (failure != null) ? failure.Children[ch] : root;

                // Append matched patterns from failure link to allow multi-pattern matching
                if (child.FailureLink != null)
                {
                    child.Patterns.AddRange(child.FailureLink.Patterns);
                }

                queue.Enqueue(child);
            }
        }
    }

    // Search for patterns in a given text
    public void Search(string text)
    {
        TrieNode current = root;

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            // Follow failure links until we find a matching child or reach root
            while (current != null && !current.Children.ContainsKey(ch))
            {
                current = current.FailureLink;
            }

            // If we find a match, move to that node
            if (current != null)
            {
                current = current.Children[ch];
            }
            else
            {
                current = root; // Reset to root if no match is found
            }

            // If the current node has patterns, print their occurrences
            foreach (string pattern in current.Patterns)
            {
                Console.WriteLine($"Pattern \"{pattern}\" found at index {i - pattern.Length + 1}");
            }
        }
    }
}

