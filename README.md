# ToDoList

A simple **To-Do list console application** built in C# (.NET) as part of my internship.  
This project demonstrates **task modeling, data persistence with JSON, and a custom Heap data structure** for task prioritization.

---

## 📌 Overview
The app allows you to manage tasks (**add, update, delete, mark complete**) while practicing core software engineering concepts:
- **OOP principles** (classes, interfaces, encapsulation)
- **Generics & Data Structures** (Heap implementation)
- **LINQ extensions** for easier query building
- **JSON file I/O** for persistence
- **Clean, layered code organization**

---

## ✨ Key Features
- CRUD operations on tasks  
- Mark tasks as complete / incomplete  
- Prioritization: compare tasks by **deadline → priority → creation date**  
- Data stored in **JSON file** (`tasksss.json`)  
- **Generic Heap** with custom `IComparer<T>` (max-heap or min-heap)  
- Extension method `ToHeap()` to build a heap from any sequence  

---

## 🏗️ Project Structure
```

ToDoList/
├─ ToDoList.sln
├─ ToDoList/
│  ├─ Program.cs              # Entry point with test methods
│  ├─ tasksss.json            # Sample task data
│  ├─ Data/
│  │  ├─ IFileReader.cs       # File reading interface
│  │  └─ JsonFileReader.cs    # JSON implementation
│  └─ Models/
│     ├─ Task.cs              # Task entity with CompareTo
│     ├─ TheList.cs           # Wrapper around list of tasks
│     ├─ Enums/Priority.cs    # Priority levels
│     ├─ DataStructures/Heap.cs
│     └─ Extension/LinqExtension.cs

````

---

## 🚀 Getting Started
### Prerequisites
- .NET SDK (6.0+ recommended)
- Visual Studio or VS Code

### Run
1. Clone this repo:
   ```bash
   git clone https://github.com/asAlwaysZahra/ToDoList.git
   ````

2. Open solution in Visual Studio
3. Build & run the **ToDoList** project
4. Ensure `tasksss.json` is in the output directory (or adjust path in `Program.cs`)

---

## 🔮 Learning Outcomes

This project was created during my **internship** to strengthen:

* C# and .NET fundamentals
* Data structures (Heap) and algorithms
* JSON serialization/deserialization
* Clean code and project structuring

