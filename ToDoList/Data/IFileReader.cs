namespace ToDoList.Data;

public interface IFileReader<T>
{
    List<T> ReadFile(string filePath);
}
