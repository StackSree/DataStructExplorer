namespace DictionarySearch;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        // Adding key-value pairs
        dictionary.Add(1, "Apple");
        dictionary.Add(2, "Banana");
        dictionary.Add(3, "Cherry");

        // Accessing values by key
        Console.WriteLine($"Key 1 has value: {dictionary[1]}");

        // Searching for a key
        if (dictionary.ContainsKey(2))
            Console.WriteLine($"Key 2 found with value: {dictionary[2]}");

        // Searching for a value
        if (dictionary.ContainsValue("Cherry"))
            Console.WriteLine("Value 'Cherry' found!");

        // Iterating through the Dictionary
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        // Removing a key-value pair
        dictionary.Remove(2);
        Console.WriteLine("Key 2 removed.");
    }
}
