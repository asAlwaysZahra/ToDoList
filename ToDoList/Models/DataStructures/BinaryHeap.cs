namespace ToDoList.Models.DataStructures;

public abstract class BinaryHeap<T>
{
    protected IList<T> heap;
    protected IComparer<T> comp;

    public BinaryHeap(IComparer<T> comp, T[]? elements = null)
    {
        this.comp = comp;
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

    public void Sort()
    {
        int n = Count;

        // Heapify (rearrange) the array
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            HeapifyDown(i);
        }

        // One by one extract an element from the heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move the current root to the end
            T temp = heap[0];
            heap[0] = heap[i];
            heap[i] = temp;

            // call max heapify on the reduced heap
            HeapifyDown(i);
        }
    }


    protected abstract void HeapifyDown(int i);

    protected abstract void HeapifyUp(int i);
}