namespace BitwiseTrieXORMaximizationSearch;

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

        int query = 5;
        int maxXor = trie.MaximizeXOR(query);
        Console.WriteLine($"\nMaximum XOR for {query}: {maxXor}");
    }
}
public class BitwiseTrie
{
    private class TrieNode
    {
        public TrieNode[] Children = new TrieNode[2]; // Two children: 0 and 1
    }

    private readonly TrieNode root;

    public BitwiseTrie()
    {
        root = new TrieNode();
    }

    // Insert a number into the trie
    public void Insert(int num)
    {
        TrieNode node = root;
        for (int i = 31; i >= 0; i--) // Traverse bits from MSB to LSB
        {
            int bit = (num >> i) & 1; // Extract the i-th bit
            if (node.Children[bit] == null)
                node.Children[bit] = new TrieNode();
            node = node.Children[bit];
        }
    }

    // Find the maximum XOR pair for a given number
    public int MaximizeXOR(int num)
    {
        TrieNode node = root;
        int maxXor = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            int oppositeBit = 1 - bit; // Try to find the opposite bit

            if (node.Children[oppositeBit] != null)
            {
                maxXor |= (1 << i); // Set the bit in maxXor
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

