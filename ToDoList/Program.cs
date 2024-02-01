using ToDoList.Models;
using ToDoList.Models.Enums;
using ToDoList.Models.DataStructures;
using Task = ToDoList.Models.Task;
using ToDoList.Data;
using ToDoList.Models.Extension;


// test main functionality - E01 ------------------------
//TheList lst = Test();


// test reading from file - E01 -------------------------
TheList list = TestReadingFile("./tasksss.json");
Console.WriteLine(list);


// get all tasks sorted - E01 ---------------------------
TheList sortedList = new TheList() { Tasks = list.SortAllTasks() };
Console.WriteLine("\n------ Sorted List ------\n");
Console.WriteLine(sortedList);


// E02: Comment these lines one by one to see the result :)

// test linq - E02 --------------------------------------
//TestLinq();


// test heap extension method on int data - E02 ---------
//TestHeapOnIntData();


// create heap and sort tasks using heap sort - E02 -----
//TestHeapOnTasks(list);


static TheList SampleTasks()
{
    Task task1 = new("AA task", "a task with same deadline and priority as task 2 and different creation date", DateTime.Now.AddDays(2), Priority.LowPriority);
    Task task2 = new("A task", "another task with same deadline as task 3 and less priority", DateTime.Now.AddDays(2), Priority.LowPriority);
    Task task3 = new("Clean your laptop", "its about 1 month you have not cleaned your laptop!", DateTime.Now.AddDays(2), Priority.HighPriority);
    Task task4 = new("Go to the dentist", "your theeth need to be checked", DateTime.Now.AddDays(7), Priority.LowPriority);
    Task task5 = new("DB homework", "the final project, phase 2", DateTime.Now.AddDays(3), Priority.Neutral);
    Task task6 = new("Reconcile eith your friend", "you know the right thing to do", DateTime.Now.AddDays(1), Priority.Critical);
    task1.CreationDate = DateTime.Now.AddDays(-1);

    TheList myList = new();
    myList.AddTask(task1);
    myList.AddTask(task2);
    myList.AddTask(task3);
    myList.AddTask(task4);
    myList.AddTask(task5);
    myList.AddTask(task6);

    return myList;
}

static TheList TestReadingFile(string path)
{
    IFileReader<Task> reader = new JsonFileReader<Task>();

    List<Task> tasks = reader.ReadFile(path);
    TheList myList = new();

    // add new tasks that has been read from file
    foreach (Task task in tasks)
        myList.AddTask(task);

    return myList;
}

static TheList Test()
{
    TheList myList = SampleTasks();

    Console.WriteLine(myList.ToString());

    Console.WriteLine("After Sorting:\n");

    Console.WriteLine(myList.GetSortedString());

    // test methods
    myList.DoTask(myList.Tasks[1]);
    myList.RemoveTask(myList.Tasks[2]);

    return myList;
}

static TheList GetFileList(string relativePath)
{
    string currentDirectory = Directory.GetCurrentDirectory();

    string fullPath = Path.Combine(currentDirectory, relativePath);

    JsonFileReader<Task> reader = new JsonFileReader<Task>();
    List<Task> tasks = reader.ReadFile(fullPath);

    TheList list = new TheList();

    for (int i = 0; i < tasks.Count; i++)
        list.AddTask(tasks[i]);

    return list;
}

static void TestLinq()
{
    TheList list = GetFileList("tasksss.json");

    // Q1
    Console.WriteLine("--Q1: " + list.Tasks.Count());

    // Q2
    Console.WriteLine("--Q2: " + list.Tasks.Where(t => t.Done).Count());

    // Q3
    DateTime t1 = DateTime.Parse("2024-08-01T00:00:00");
    DateTime t2 = DateTime.Parse("2024-10-01T00:00:00");
    // ans: 16 - 1
    Console.WriteLine("--Q3: " + list.Tasks.Where(t => t.DoneAt.CompareTo(t1) > 0 && t.DoneAt.CompareTo(t2) < 0).Count());

    // Q4
    Console.WriteLine("--Q4: " + list.Tasks.Where(t => t.Done == false).Count());

    // Q5
    Console.WriteLine("--Q5: " + list.Tasks.Where(t => t.Deadline.CompareTo(DateTime.Now) < 0).Count());

    // Q6
    Console.Write("--Q6: ");
    List<int> res = list.Tasks.Where(t => (DateTime.Now - t.CreationDate).TotalDays > 5 && !t.Done)
                          .OrderByDescending(t => t.CreationDate)
                          .Select(t => t.Id)
                          .ToList();
    for (int i = 0; i < Math.Min(3, res.Count); i++) Console.Write(res[i] + " - ");
    Console.WriteLine();

    // Q7
    Console.Write("--Q7: ");
    res = list.Tasks.Where(t => (t.DoneAt.DayOfYear == t.CreationDate.DayOfYear && t.Done))
                          .OrderByDescending(t => t.CreationDate)
                          .Select(t => t.Id)
                          .ToList();
    for (int i = 0; i < Math.Min(3, res.Count); i++) Console.Write(res[i] + " - ");
    Console.WriteLine();

    // Q8
    Console.WriteLine("--Q8: ");
    foreach (Priority pr in Enum.GetValues<Priority>())
    {
        Console.WriteLine("      " + pr.ToString() + " -> " + list.Tasks.Where(t => t.Priority == pr && !t.Done).Count());
    }

    Console.WriteLine("\n-------------------------\n");
}

static void TestHeapOnIntData()
{
    List<int> data = new List<int>() { 1, 2, 5, 3, 4, 6, 9, 7, 8 };

    Heap<int> intMaxHeap = data.ToHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    Heap<int> intMinHeap = data.ToHeap<int>(Comparer<int>.Default);

    Console.WriteLine("- max of integer data: " + intMaxHeap.ExtractRoot());
    Console.WriteLine("- min of integer data: " + intMinHeap.ExtractRoot());
    Console.WriteLine("\n-------------------------\n");
}

static void TestHeapOnTasks(TheList list)
{
    Heap<Task> maxHeap = list.Tasks.ToHeap<Task>(Comparer<Task>.Create((a, b) => a.CompareTo(b)));
    Heap<Task> minHeap = list.Tasks.ToHeap<Task>(Comparer<Task>.Create((a, b) => b.CompareTo(a)));

    List<Task> sorted = maxHeap.HeapSort();
    Console.WriteLine("---- after heap sort ----");
    foreach (var item in sorted)
        Console.WriteLine(item);


    // test get most important tasks - E02 ---------------
    Console.WriteLine("--- most important task ---\n" + maxHeap.Peek());
    Console.WriteLine("--- least important task ---\n" + minHeap.Peek());
}