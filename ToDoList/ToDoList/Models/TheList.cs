using System.Text;

namespace ToDoList.Models
{
    internal class TheList
    {
        protected static int _counter = 1;
        public int Id { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Task> Done { get; set; }

        public TheList()
        {
            Id = _counter++;
            Tasks = new List<Task>();
            Done = new List<Task>();
        }

        public void AddTask(Task task) => Tasks.Add(task);

        public void RemoveTask(Task task) => Tasks.Remove(task);

        public void DoTask(Task task)
        {
            Tasks.Remove(task);
            Done.Add(task);
        }

        public List<Task> SortTasks()
        {
            List<Task> sorted = new List<Task>(Tasks);
            sorted.Sort();
            return sorted;
        }

        public string GetSortedString()
        {
            List<Task> sorted = SortTasks();
            StringBuilder sb = new StringBuilder();

            foreach (var task in sorted)
            {
                sb.Append(task.ToString()).Append("\n============\n");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var task in Tasks)
            {
                sb.Append(task.ToString()).Append("\n============\n");
            }

            return sb.ToString();
        }
    }
}
