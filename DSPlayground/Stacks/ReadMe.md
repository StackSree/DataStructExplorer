# Stack Operations in C#

## Overview
A stack is a collection where elements are added and removed only from the **top** of the stack. The primary operations are:

- **Push**: Add an element to the top of the stack.
- **Pop**: Remove and return the top element of the stack.
- **Peek**: View the top element without removing it.

---

## Key Operations

| Operation   | Description                   | Method in `Stack<T>`      |
|-------------|-------------------------------|----------------------------|
| Push        | Adds an item to the stack     | `Push(item)`               |
| Pop         | Removes the top item         | `Pop()`                    |
| Peek        | Retrieves the top item       | `Peek()`                   |
| Count       | Returns the number of items  | `Count` (property)         |
| Contains    | Checks if an item exists     | `Contains(item)`           |
| Clear       | Removes all items            | `Clear()`                  |

---

## Use Cases

### Expression Evaluation
- **Converting infix to postfix**
- **Evaluating postfix expressions**

### Backtracking
- **Navigating browser history**
- **Undo operations in editors**

### Recursive Function Simulation
- **Using stacks to replace recursion**

### Sorting Algorithms
- **Auxiliary data structures in algorithms like QuickSort**

