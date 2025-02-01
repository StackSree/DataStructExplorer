# C# Search Algorithms Collection

A collection of various search algorithms implemented in C# for educational purposes and practical usage.

## 🚀 Algorithms Included

- **Tree-Based Searches**
  - 2-3 Trees Search
  - AVL Tree Search
  - B-Trees Search
  - Cartesian Tree Search
  - Patricia Trie Search
  - Red-Black Tree Search
  - Segment Tree Search
  - Skip Lists Search
  - Sparse Table Search

- **Graph-Based Searches**
  - Bellman-Ford Algorithm Search
  - Dijkstra's Algorithm Search

- **String Matching Algorithms**
  - Aho-Corasick Search
  - Boyer-Moore Search
  - KMP Algorithm Search
  - Rabin-Karp Search

- **Bitwise & Hashing-Based Searches**
  - Bitwise Trie Search
  - Bitwise Trie XOR Maximization Search
  - Cuckoo Hashing Search
  - Dictionary Search
  - Hash Table Search

- **Array-Based Searches**
  - Binary Search (Built-in, Recursive, Iterative, First & Last Occurrence)
  - Exponential Search
  - Fibonacci Search
  - Jump Search
  - Linear Search (Array, List, Recursive, Generic)
  - Ternary Search (Unimodal Functions)

## 🛠 Usage

Each algorithm is implemented as a separate class and can be used as follows:

```csharp
using SearchAlgorithms;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        int target = 5;
        int index = BinarySearchIterative.Search(arr, target);
        Console.WriteLine($"Element found at index: {index}");
    }
}
```

## 🤝 Contributing

1. Fork the repository
2. Create a new branch (`feature-branch`)
3. Commit your changes
4. Push to the branch and create a pull request

## 📄 License

This project is licensed under the MIT License.

---

🔥 Happy Coding! 🚀

