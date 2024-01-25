using ToDoList.Models.Enums;

namespace ToDoList.Models
{
    public class Task : IComparable<Task>
    {
        protected static int _counter = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }

        public Task(string title, string description, DateTime creationDate, DateTime deadline, Priority priority)
        {
            Id = _counter++;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Deadline = deadline;
            Priority = priority;
        }

        public int CompareTo(Task? other)
        {
            if (other == null)
                throw new ArgumentNullException("other task is null!");

            if (Deadline != other.Deadline) 
                return Deadline.CompareTo(other.Deadline);

            return other.Priority.CompareTo(Priority);
        }
    }
}
