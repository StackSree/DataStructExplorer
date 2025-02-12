# Efficient File Processing in C# with Span<T> and Memory<T>

## 🚀 Overview
This project demonstrates **efficient file processing in C#** using `ReadOnlySpan<T>` and `ReadOnlyMemory<T>` to minimize **heap allocations and improve performance**.

### **Why use `Span<T>` and `Memory<T>`?**
✅ **Avoid unnecessary heap allocations** (better performance)  
✅ **Fast memory access for large files**  
✅ **Ideal for high-performance scenarios like log processing**  

---

## 📜 Features
- **Zero Heap Allocations:** Uses `Span<T>` for in-memory operations.
- **Async-Compatible:** Uses `Memory<T>` for efficient async file reading.
- **Optimized Processing:** Processes lines without unnecessary copies.

---

## 📊 Performance Comparison
| **Method** | **Heap Allocation?** | **Use Case** |
|------------|----------------|----------------------|
| `string.Substring()` | ✅ Allocates memory | Traditional string processing |
| `ReadOnlySpan<T>` | ❌ No allocation | High-performance in-memory processing |
| `ReadOnlyMemory<T>` | ✅ Minimal allocation | Works with async and collections |

---

## ⚡ Benefits
- **🚀 High-speed text processing** without memory overhead.
- **🔥 Ideal for log processing, streaming, and real-time data handling.**
- **🔧 Reduced Garbage Collection (GC) pressure**.

---

## 🏗️ Contributing
Feel free to submit issues or pull requests to improve this project!

---

## 📜 License
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

