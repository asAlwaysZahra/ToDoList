namespace ToDoList.Models.DataStructures;

public abstract class BinaryHeap<T> where T : IComparable<T>
{
    protected IList<T> heap;

    public BinaryHeap(T[]? elements = null)
    {
        if (elements != null)
        {
            heap = new List<T>(elements);
            for (int i = elements.Length / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }
        else
        {
            heap = new List<T>();
        }
    }

    public int Count
    {
        get
        {
            return heap.Count;
        }
    }

    public T Extract()
    {
        var max = heap[0];
        heap[0] = heap[Count - 1];
        heap.RemoveAt(Count - 1);

        if (Count > 0)
        {
            HeapifyDown(0);
        }

        return max;
    }

    public T Peek()
    {
        var max = heap[0];

        return max;
    }

    public void Insert(T node)
    {
        heap.Add(node);

        HeapifyUp(Count - 1);
    }

    protected abstract void HeapifyDown(int i);

    protected abstract void HeapifyUp(int i);
}