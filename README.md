# ToDoList

A small C#/.NET console project that demonstrates **task modeling**, **JSON-based data loading**, and a generic **Heap** data structure for prioritizing tasks.

## 📌 Overview
This app defines a `Task` domain model (comparable by **deadline → priority → creation date**), reads tasks from a JSON file via a simple file-reader abstraction, and shows how to rank/sort tasks using a **generic Heap** with pluggable comparers. It also includes a minimal LINQ helper to convert sequences into a heap.

## ✨ Key Features
- **Task model (`Models/Task.cs`)**
  - Properties: `Id`, `Title`, `Description`, `CreationDate`, `Deadline`, `Priority`, `Done`, `DoneAt`, `Category`
  - Implements `IComparable<Task>`:
    - Comparison order: earlier **Deadline** first → higher **Priority** first → earlier **CreationDate** first  
    - `ToString()` prints a readable, multi-line representation
- **Priority enum (`Models/Enums/Priority.cs`)**
  - `Critical = 1`, `HighPriority`, `Neutral`, `LowPriority`, `Unknown`  
  - Lower numeric value means **more important**
- **Task list container (`Models/TheList.cs`)**
  - Holds `List<Task>` and prints all tasks; (helper methods to add/remove are used in `Program`)
- **Generic Heap (`Models/DataStructures/Heap.cs`)**
  - Works with any `T` using an injected `IComparer<T>`
  - Core ops: `Insert`, `ExtractRoot`, `Peek`, `Count`, plus `HeapSort()` (non-destructive: copies then drains)
  - Supports building from an `IEnumerable<T>` (see extension below)
- **LINQ extension (`Models/Extension/LinqExtension.cs`)**
  - `ToHeap<T>(IEnumerable<T>, IComparer<T>)` to quickly build a heap from a sequence
- **File reading abstraction (`Data/IFileReader.cs`, `Data/JsonFileReader.cs`)**
  - `IFileReader<T>.ReadFile(string path)`
  - `JsonFileReader<T>` uses `System.Text.Json` to deserialize `List<T>`
  - Throws on missing file or null payload
- **Sample data (`ToDoList/tasksss.json`)**
  - A list of task objects with various priorities/dates/categories
- **Program entry (`Program.cs`)**
  - Shows:
    - Reading tasks from JSON (`TestReadingFile`)
    - Running simple LINQ/queries over tasks (`TestLinq`)
    - Building **max/min heaps** for tasks and integers; printing **most/least important** tasks (`TestHeapOnTasks`, `TestHeapOnIntData`)
  - Uses `AppDomain.CurrentDomain.BaseDirectory` to resolve the JSON path at runtime

## 🏗️ How Prioritization Works
`Task.CompareTo(other)`:
1) Compare by **Deadline** (earlier is higher priority)  
2) If tie, compare by **Priority** (numerically smaller enum = more important)  
3) If tie, compare by **CreationDate** (earlier created = more priority)

Using this, you can build:
- **Max-heap** (top = most important task) with `Comparer<Task>.Create((a, b) => a.CompareTo(b))`
- **Min-heap** (top = least important task) with `Comparer<Task>.Create((a, b) => b.CompareTo(a))`

`HeapSort()` drains a copied heap to return a sorted list according to the comparer.

## 🚀 Getting Started
### Prerequisites
- .NET 8 SDK 
- Visual Studio / VS Code

### Run
1. Build the solution.
2. Ensure `tasksss.json` is copied next to the built executable (the code resolves it from the **app’s base directory**).  
   - In this repo it’s at: `ToDoList/tasksss.json`.
3. Run the app. In `Program.cs` you can toggle tests:
   - `TestReadingFile("tasksss.json");`
   - `TestLinq("tasksss.json");`
   - `TestHeapOnTasks(list);` / `TestHeapOnIntData();`

## 📂 Project Layout
```

ToDoList/
├─ ToDoList.sln
├─ ToDoList/
│  ├─ Program.cs
│  ├─ ToDoList.csproj
│  ├─ tasksss.json
│  ├─ Data/
│  │  ├─ IFileReader.cs
│  │  └─ JsonFileReader.cs
│  └─ Models/
│     ├─ Task.cs
│     ├─ TheList.cs
│     ├─ Enums/Priority.cs
│     ├─ DataStructures/Heap.cs
│     └─ Extension/LinqExtension.cs

```

## 🧪 What to Try
- Change `Comparer<Task>` to flip between **max/min** perspective
- Inspect the top element with `Peek()` to see current “most important” task
- Call `HeapSort()` to get a fully ordered task list
