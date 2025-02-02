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

## Search Algorithms - Time Complexity & Use Cases

### Tree-Based Searches
| Algorithm                | Time Complexity (Best, Avg, Worst) | Use Cases |
|--------------------------|----------------------------------|-----------|
| **2-3 Trees Search**    | O(log N), O(log N), O(log N)   | Database indexing, file systems |
| **AVL Tree Search**     | O(log N), O(log N), O(log N)   | Self-balancing BST, fast lookups |
| **B-Trees Search**      | O(log N), O(log N), O(log N)   | Databases, large file systems |
| **Cartesian Tree Search** | O(log N), O(log N), O(N)  | Priority queues, range queries |
| **Patricia Trie Search** | O(M), O(M), O(M) (M = key length) | IP routing, string searches |
| **Red-Black Tree Search** | O(log N), O(log N), O(log N) | Balanced tree operations, associative arrays |
| **Segment Tree Search**  | O(1), O(log N), O(log N)      | Range queries, competitive programming |
| **Skip Lists Search**    | O(log N), O(log N), O(N)      | Alternative to balanced trees |
| **Sparse Table Search**  | O(1), O(1), O(1) (preprocessed) | Static range queries |

### Graph-Based Searches
| Algorithm                | Time Complexity | Use Cases |
|--------------------------|----------------|-----------|
| **Bellman-Ford Algorithm** | O(VE)         | Shortest path in graphs with negative weights |
| **Dijkstra's Algorithm**  | O((V+E) log V) | Shortest path in graphs with non-negative weights |

### String Matching Algorithms
| Algorithm                | Time Complexity | Use Cases |
|--------------------------|----------------|-----------|
| **Aho-Corasick Search**  | O(M + N + Z)   | Multi-pattern matching (e.g., spam filters) |
| **Boyer-Moore Search**   | O(N/M), O(N), O(MN) | Efficient substring search |
| **KMP Algorithm Search** | O(M + N)       | Pattern matching with partial matches |
| **Rabin-Karp Search**    | O(M + N), O(MN) | Fast substring search using hashing |

### Bitwise & Hashing-Based Searches
| Algorithm                      | Time Complexity | Use Cases |
|--------------------------------|----------------|-----------|
| **Bitwise Trie Search**        | O(1), O(1), O(1) | Fast integer lookups |
| **Bitwise Trie XOR Maximization Search** | O(1), O(1), O(1) | Maximum XOR queries |
| **Cuckoo Hashing Search**      | O(1), O(1), O(N) | Fast and collision-free hashing |
| **Dictionary Search**          | O(1) (avg), O(N) (worst) | Key-value storage |
| **Hash Table Search**          | O(1) (avg), O(N) (worst) | Fast lookups in hash tables |

### Array-Based Searches
| Algorithm                | Time Complexity | Use Cases |
|--------------------------|----------------|-----------|
| **Binary Search**        | O(1), O(log N), O(log N) | Sorted array search |
| **Exponential Search**   | O(1), O(log N), O(log N) | Unknown boundary searches |
| **Fibonacci Search**     | O(1), O(log N), O(log N) | Numerical optimizations |
| **Jump Search**          | O(1), O(√N), O(√N) | Sorted lists, efficient skipping |
| **Linear Search**        | O(1), O(N), O(N) | Unsorted lists |
| **Ternary Search**       | O(1), O(log N), O(log N) | Unimodal function searches |

**Note:**
- `N` = number of elements, `M` = pattern length, `V` = vertices, `E` = edges.
- Best case often assumes an early match or already sorted data.
- Worst case typically assumes worst input conditions (e.g., not found, heavy collisions in hashing).

This README provides a structured comparison of search algorithms for reference in C# implementations.

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






