namespace CuckooHashingSearch;

internal class Program
{
    static void Main(string[] args)
    {
        CuckooHashTable hashTable = new CuckooHashTable(11);

        // Insert keys
        int[] keys = { 10, 22, 31, 4, 15, 28, 17, 88, 59 };
        foreach (var key in keys)
        {
            hashTable.Insert(key);
        }

        // Display the tables
        hashTable.Display();

        // Search for keys
        int[] keysToSearch = { 31, 88, 10, 100 };
        foreach (var key in keysToSearch)
        {
            Console.WriteLine($"Key {key} is {(hashTable.Search(key) ? "found" : "not found")}.");
        }
    }
}

public class CuckooHashTable
{
    private int[] table1;
    private int[] table2;
    private int size;
    private const int Empty = -1; // Marker for empty slots
    private const int MaxRehashAttempts = 10; // Limit to prevent infinite loops

    public CuckooHashTable(int size)
    {
        this.size = size;
        table1 = new int[size];
        table2 = new int[size];

        // Initialize both tables to empty
        for (int i = 0; i < size; i++)
        {
            table1[i] = Empty;
            table2[i] = Empty;
        }
    }

    // Hash function 1
    private int Hash1(int key)
    {
        return key % size;
    }

    // Hash function 2
    private int Hash2(int key)
    {
        return (key / size) % size;
    }

    // Insert a key into the Cuckoo Hash Table
    public void Insert(int key)
    {
        int attempt = 0;
        int currentKey = key;
        int position;

        while (attempt < MaxRehashAttempts)
        {
            // Try to place in table1
            position = Hash1(currentKey);
            if (table1[position] == Empty)
            {
                table1[position] = currentKey;
                return;
            }

            // Evict the existing key from table1
            int displacedKey = table1[position];
            table1[position] = currentKey;
            currentKey = displacedKey;

            // Try to place in table2
            position = Hash2(currentKey);
            if (table2[position] == Empty)
            {
                table2[position] = currentKey;
                return;
            }

            // Evict the existing key from table2
            displacedKey = table2[position];
            table2[position] = currentKey;
            currentKey = displacedKey;

            attempt++;
        }

        // Rehash if we exceed the max attempts
        Console.WriteLine("Rehashing required. Table is too full or contains a cycle.");
        Rehash();
        Insert(currentKey); // Retry the insertion after rehashing
    }

    // Search for a key in the Cuckoo Hash Table
    public bool Search(int key)
    {
        int position1 = Hash1(key);
        int position2 = Hash2(key);

        // Check both hash tables
        if (table1[position1] == key || table2[position2] == key)
        {
            return true;
        }

        return false;
    }

    // Rehash the table with new hash functions
    private void Rehash()
    {
        Console.WriteLine("Rehashing...");
        size *= 2; // Double the table size
        int[] oldTable1 = table1;
        int[] oldTable2 = table2;

        // Initialize new tables
        table1 = new int[size];
        table2 = new int[size];
        for (int i = 0; i < size; i++)
        {
            table1[i] = Empty;
            table2[i] = Empty;
        }

        // Reinsert all elements into the new tables
        foreach (int key in oldTable1)
        {
            if (key != Empty)
            {
                Insert(key);
            }
        }
        foreach (int key in oldTable2)
        {
            if (key != Empty)
            {
                Insert(key);
            }
        }
    }

    // Display the contents of both tables
    public void Display()
    {
        Console.WriteLine("Table 1:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Index {i}: {table1[i]}");
        }

        Console.WriteLine("\nTable 2:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Index {i}: {table2[i]}");
        }
    }
}
