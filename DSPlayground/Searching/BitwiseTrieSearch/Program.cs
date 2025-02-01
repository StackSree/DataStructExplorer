namespace BitwiseTrieSearch;

internal class Program
{
    static void Main(string[] args)
    {
        BitwiseTrie trie = new BitwiseTrie();
        int[] numbers = { 3, 10, 5, 25, 2, 8 };

        Console.WriteLine("Inserting numbers into the Trie...");
        foreach (int num in numbers)
        {
            trie.Insert(num);
        }

        Console.WriteLine("\nSearching numbers in the Trie:");
        Console.WriteLine($"Is 10 in the Trie? {trie.Search(10)}"); // True
        Console.WriteLine($"Is 7 in the Trie? {trie.Search(7)}");   // False

        Console.WriteLine("\nFinding Max XOR Pair:");
        int query = 5;
        Console.WriteLine($"Max XOR for {query}: {trie.MaxXOR(query)}");
    }
}

public class BitwiseTrie
{
    private class TrieNode
    {
        public TrieNode[] Children = new TrieNode[2]; // Binary trie (0 or 1)
        public bool IsEndOfNumber; // Marks end of a number
    }

    private readonly TrieNode root;

    public BitwiseTrie()
    {
        root = new TrieNode();
    }

    // Insert an integer into the trie
    public void Insert(int num)
    {
        TrieNode node = root;
        for (int i = 31; i >= 0; i--) // Iterate through 32 bits (for int)
        {
            int bit = (num >> i) & 1; // Extract the i-th bit
            if (node.Children[bit] == null)
                node.Children[bit] = new TrieNode();
            node = node.Children[bit];
        }
        node.IsEndOfNumber = true;
    }

    // Search for an exact integer in the trie
    public bool Search(int num)
    {
        TrieNode node = root;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[bit] == null)
                return false;
            node = node.Children[bit];
        }
        return node.IsEndOfNumber;
    }

    // Find the maximum XOR pair for a given number
    public int MaxXOR(int num)
    {
        TrieNode node = root;
        int maxXor = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            int oppositeBit = 1 - bit; // Try to find the opposite bit for max XOR

            if (node.Children[oppositeBit] != null)
            {
                maxXor |= (1 << i); // Set the bit in maxXor result
                node = node.Children[oppositeBit];
            }
            else
            {
                node = node.Children[bit];
            }
        }
        return maxXor;
    }
}
