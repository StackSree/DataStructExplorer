namespace PatriciaTrieSearch;

internal class Program
{
    static void Main(string[] args)
    {
        PatriciaTrie trie = new PatriciaTrie();

        // Insert key-value pairs
        trie.Insert("apple", "A fruit");
        trie.Insert("app", "Short for application");
        trie.Insert("apricot", "Another fruit");
        trie.Insert("banana", "A yellow fruit");

        // Display the Patricia Trie structure
        Console.WriteLine("Patricia Trie structure:");
        trie.Display();

        // Search for keys
        string[] keysToSearch = { "apple", "app", "apricot", "banana", "grape" };

        foreach (string key in keysToSearch)
        {
            string result = trie.Search(key);
            Console.WriteLine(result != null
                ? $"Key \"{key}\" found with value: \"{result}\""
                : $"Key \"{key}\" not found.");
        }
    }
}

internal class PatriciaTrie
{
    // Trie Node structure
    class Node
    {
        public string Prefix; // The prefix stored at this node
        public Dictionary<char, Node> Children = new Dictionary<char, Node>();
        public string Value; // Value associated with a complete key (optional for prefix nodes)

        public Node(string prefix)
        {
            Prefix = prefix;
        }
    }

    private Node root;

    public PatriciaTrie()
    {
        root = new Node(string.Empty); // Root node has an empty prefix
    }

    // Insert a key-value pair into the Patricia Trie
    public void Insert(string key, string value)
    {
        Node current = root;

        while (true)
        {
            int commonPrefixLength = GetCommonPrefixLength(key, current.Prefix);

            // If the prefix matches exactly
            if (commonPrefixLength == current.Prefix.Length)
            {
                string remainingKey = key.Substring(commonPrefixLength);

                if (remainingKey == string.Empty)
                {
                    // Exact match: store the value at this node
                    current.Value = value;
                    return;
                }

                // Follow or create a child for the remaining key
                char nextChar = remainingKey[0];
                if (!current.Children.ContainsKey(nextChar))
                {
                    current.Children[nextChar] = new Node(remainingKey);
                    current.Children[nextChar].Value = value;
                    return;
                }

                // Move to the next child node
                current = current.Children[nextChar];
                key = remainingKey;
            }
            else
            {
                // Split the current node if needed
                string remainingPrefix = current.Prefix.Substring(commonPrefixLength);
                Node newChild = new Node(remainingPrefix)
                {
                    Children = current.Children,
                    Value = current.Value
                };

                // Update the current node
                current.Prefix = current.Prefix.Substring(0, commonPrefixLength);
                current.Children = new Dictionary<char, Node>();
                current.Children[remainingPrefix[0]] = newChild;
                current.Value = null;

                // Add the new key as a child node
                string remainingKey = key.Substring(commonPrefixLength);
                current.Children[remainingKey[0]] = new Node(remainingKey);
                current.Children[remainingKey[0]].Value = value;
                return;
            }
        }
    }

    // Search for a key in the Patricia Trie
    public string Search(string key)
    {
        Node current = root;

        while (current != null)
        {
            int commonPrefixLength = GetCommonPrefixLength(key, current.Prefix);

            // If the prefix does not match, the search fails
            if (commonPrefixLength == 0)
                return null;

            // If the prefix matches completely
            if (commonPrefixLength == current.Prefix.Length)
            {
                string remainingKey = key.Substring(commonPrefixLength);

                if (remainingKey == string.Empty)
                {
                    // Exact match
                    return current.Value;
                }

                // Continue searching in the appropriate child
                char nextChar = remainingKey[0];
                current = current.Children.ContainsKey(nextChar) ? current.Children[nextChar] : null;
                key = remainingKey;
            }
            else
            {
                // Partial match but key doesn't fully match this node's prefix
                return null;
            }
        }

        // Key not found
        return null;
    }

    // Utility function to find the length of the common prefix between two strings
    private int GetCommonPrefixLength(string str1, string str2)
    {
        int i = 0;
        while (i < str1.Length && i < str2.Length && str1[i] == str2[i])
        {
            i++;
        }
        return i;
    }

    // Display the Patricia Trie (for testing)
    public void Display()
    {
        DisplayNode(root, "");
    }

    private void DisplayNode(Node node, string indent)
    {
        Console.WriteLine($"{indent}Node(Prefix: \"{node.Prefix}\", Value: \"{node.Value}\")");

        foreach (var child in node.Children)
        {
            DisplayNode(child.Value, indent + "  ");
        }
    }
}