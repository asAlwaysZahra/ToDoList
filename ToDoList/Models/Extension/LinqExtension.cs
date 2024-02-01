using ToDoList.Models.DataStructures;

namespace ToDoList.Models.Extension;

public static class LinqExtension
{
    public static Heap<T> ToHeap<T>(this IEnumerable<T> collection, IComparer<T> comparer)
    {
        Heap<T> heap = new Heap<T>(comparer);
        heap.Insert(collection);
        return heap;
    }
}
