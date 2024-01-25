namespace ToDoList.Models
{
    internal class ToDoList
    {
        protected static int _counter = 0;
        public int Id { get; set; }
        public List<Task> Tasks { get; set; }

        public ToDoList()
        {
            Id = _counter++;
            Tasks = new List<Task>();
        }

        public void AddTask(Task task) => Tasks.Add(task);

        public void RemoveTask(Task task) => Tasks.Remove(task);

        public List<Task> SortTasks()
        {
            List<Task> sorted = new List<Task>();
            sorted.Sort();
            return sorted;
        }
    }
}
