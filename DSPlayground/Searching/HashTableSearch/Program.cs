using System.Collections;

namespace HashTableSearch;

internal class Program
{
    static void Main(string[] args)
    {
        static void Main()
        {
            Hashtable hashtable = new Hashtable();

            // Adding key-value pairs
            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add(3, "Cherry");

            // Searching for a key
            if (hashtable.ContainsKey(2))
                Console.WriteLine($"Key 2 found with value: {hashtable[2]}");

            // Searching for a value
            if (hashtable.ContainsValue("Cherry"))
                Console.WriteLine("Value 'Cherry' found!");

            // Iterating through the Hashtable
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }
    }
}
