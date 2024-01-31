namespace ToDoList.Models.DataStructures;

public abstract class BinaryHeap<T> where T : IComparable<T>
{
    protected IList<T> _heap;

    public BinaryHeap(T[]? elements = null)
    {
        if (elements != null)
        {
            _heap = new List<T>(elements);
            for (int i = elements.Length / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }
        else
        {
            _heap = new List<T>();
        }
    }

    public int Count
    {
        get
        {
            return _heap.Count;
        }
    }

    public T ExtractMax()
    {
        var max = _heap[0];
        _heap[0] = _heap[Count - 1];
        _heap.RemoveAt(Count - 1);

        if (Count > 0)
        {
            HeapifyDown(0);
        }

        return max;
    }

    public T PeekMax()
    {
        var max = _heap[0];

        return max;
    }

    public void Insert(T node)
    {
        _heap.Add(node);

        HeapifyUp(Count - 1);
    }

    protected abstract void HeapifyDown(int i);

    protected abstract void HeapifyUp(int i);
}