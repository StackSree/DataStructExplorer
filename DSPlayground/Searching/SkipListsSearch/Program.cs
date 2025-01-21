namespace SkipListsSearch;

internal class Program
{
    static void Main(string[] args)
    {
        var skipList = new SkipList<int>();

        skipList.Insert(3);
        skipList.Insert(6);
        skipList.Insert(7);
        skipList.Insert(9);
        skipList.Insert(12);
        skipList.Insert(19);
        skipList.Insert(17);

        Console.WriteLine("Skip List:");
        skipList.PrintList();

        Console.WriteLine("\nSearching for 7:");
        Console.WriteLine(skipList.Search(7) ? "Found" : "Not Found");

        Console.WriteLine("\nDeleting 7:");
        skipList.Delete(7);
        skipList.PrintList();

        Console.WriteLine("\nSearching for 7:");
        Console.WriteLine(skipList.Search(7) ? "Found" : "Not Found");
    }
}

class SkipListNode<T> where T : IComparable
{
    public T Value;
    public List<SkipListNode<T>> Forward;

    public SkipListNode(T value, int level)
    {
        Value = value;
        Forward = new List<SkipListNode<T>>(new SkipListNode<T>[level + 1]);
    }
}

class SkipList<T> where T : IComparable
{
    private const double Probability = 0.5; // Probability for level increase
    private const int MaxLevel = 16;        // Maximum levels allowed

    private SkipListNode<T> Head;
    private int CurrentLevel;

    public SkipList()
    {
        Head = new SkipListNode<T>(default(T), MaxLevel);
        CurrentLevel = 0;
    }

    private int RandomLevel()
    {
        int level = 0;
        Random rand = new Random();
        while (rand.NextDouble() < Probability && level < MaxLevel)
        {
            level++;
        }
        return level;
    }

    public void Insert(T value)
    {
        var update = new SkipListNode<T>[MaxLevel + 1];
        var current = Head;

        for (int i = CurrentLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
            update[i] = current;
        }

        current = current.Forward[0];

        if (current == null || !current.Value.Equals(value))
        {
            int newLevel = RandomLevel();
            if (newLevel > CurrentLevel)
            {
                for (int i = CurrentLevel + 1; i <= newLevel; i++)
                {
                    update[i] = Head;
                }
                CurrentLevel = newLevel;
            }

            var newNode = new SkipListNode<T>(value, newLevel);
            for (int i = 0; i <= newLevel; i++)
            {
                newNode.Forward[i] = update[i].Forward[i];
                update[i].Forward[i] = newNode;
            }
        }
    }

    public bool Search(T value)
    {
        var current = Head;
        for (int i = CurrentLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
        }

        current = current.Forward[0];
        return current != null && current.Value.Equals(value);
    }

    public void Delete(T value)
    {
        var update = new SkipListNode<T>[MaxLevel + 1];
        var current = Head;

        for (int i = CurrentLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
            update[i] = current;
        }

        current = current.Forward[0];

        if (current != null && current.Value.Equals(value))
        {
            for (int i = 0; i <= CurrentLevel; i++)
            {
                if (update[i].Forward[i] != current)
                {
                    break;
                }
                update[i].Forward[i] = current.Forward[i];
            }

            while (CurrentLevel > 0 && Head.Forward[CurrentLevel] == null)
            {
                CurrentLevel--;
            }
        }
    }

    public void PrintList()
    {
        for (int i = 0; i <= CurrentLevel; i++)
        {
            var node = Head.Forward[i];
            Console.Write($"Level {i}: ");
            while (node != null)
            {
                Console.Write($"{node.Value} ");
                node = node.Forward[i];
            }
            Console.WriteLine();
        }
    }
}

