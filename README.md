# ToDoList

A simple **To-Do list application** built as an internship project in C#.  
It demonstrates the fundamentals of **task management, data persistence, and clean architecture**.

---

## 📌 Overview

This project was developed as part of my internship to practice real-world software development.  
The **ToDoList** app allows you to **add, edit, delete, and mark tasks as complete**.  
It focuses on learning how to structure applications properly and apply key programming concepts.

---

## ✨ Key Features

- **Task CRUD**: create, read, update, delete tasks  
- **Mark complete/incomplete**: toggle task status  
- **Persistence**: tasks stored locally (file/DB depending on implementation)  
- **Layered design**: separation of UI, business logic, and data layer  
- **Learning project**: built to strengthen C# and .NET development skills  

---

## 🏗️ Concepts Learned

- Object-Oriented Programming (OOP) in practice  
- Repository / data access patterns  
- Handling user input and validations  
- Project structure and clean code principles  
- Basics of persistence (saving tasks for later use)  

---

## ⚙️ Getting Started

### Prerequisites
- .NET SDK (6.0 / 7.0 / 8.0 depending on your environment)  
- Visual Studio or VS Code  

### Run
1. Clone this repo:
   ```bash
   git clone https://github.com/asAlwaysZahra/ToDoList.git
   ````

2. Open solution in Visual Studio
3. Build and run

---

## 📂 Typical Structure

```
ToDoList/
├─ ToDoList/          # Main app (UI + logic)
├─ ToDoList.Core/     # Domain models & interfaces
├─ ToDoList.Data/     # Persistence layer
└─ README.md
```

---

## 🔮 Possible Improvements

* Add task deadlines & priorities
* Filtering & search (by status or date)
* GUI instead of console (WPF/WinUI/Blazor)
* Unit testing

