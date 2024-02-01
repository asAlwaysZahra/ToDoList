using System.Text.Json.Serialization;
using ToDoList.Models.Enums;

namespace ToDoList.Models;
public class Task : IComparable<Task>
{
    protected static int _counter = 1;
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime Deadline { get; set; }
    public Priority Priority { get; set; }
    public bool Done { get; set; }
    public DateTime DoneAt { get; set; }

    [JsonConstructor]
    public Task(int id, string title, string description, DateTime creationDate, 
        DateTime deadline, Priority priority, bool done, DateTime doneAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CreationDate = creationDate;
        Deadline = deadline;
        Priority = priority;
        Done = done;
        DoneAt = doneAt;
    }

    public Task(string title, string description, DateTime deadline, Priority priority)
    {
        Id = _counter++;
        Title = title;
        Description = description;
        CreationDate = DateTime.Now;
        Deadline = deadline;
        Priority = priority;
        Done = false;
    }

    public int CompareTo(Task? other)
    {
        if (other == null)
            throw new ArgumentNullException("other task is null!");

        if (!Deadline.ToString().Equals(other.Deadline.ToString()))
            return Deadline.CompareTo(other.Deadline);

        if (!Priority.Equals(other.Priority))
            return Priority.CompareTo(other.Priority);

        // the one that has been created earlier, has more priority
        return CreationDate.CompareTo(other.CreationDate);
    }

    public override string ToString()
        => $"{Id} | {Priority} | {Title} | Due: {Deadline}\n  - {Description}\n    Created at: {CreationDate}";
}
