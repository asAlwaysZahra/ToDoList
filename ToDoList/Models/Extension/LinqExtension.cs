using ToDoList.Models.DataStructures;

namespace ToDoList.Models.Extension;

public static class LinqExtension
{
    public static BinaryHeap<T> ToHeap<T>(this IEnumerable<T> collection, IComparer<T> comp, bool isMax)
    {
        BinaryHeap<T> heap;

        if (isMax)
        {
            heap = new MaxHeap<T>(comp);
        }
        else
        {
            heap = new MinHeap<T>(comp);
        }

        foreach (var item in collection)
        {
            heap.Insert(item);
        }

        return heap;
    }
}
