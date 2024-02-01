namespace ToDoList.Models.DataStructures;

public class Heap<T>
{
    private List<T> _data;

    private IComparer<T> comp;

    public Heap(IComparer<T> comparer)
    {
        _data = new List<T>();
        comp = comparer;
    }

    public int Count => _data.Count;

    public void Insert(T item)
    {
        _data.Add(item);
        HeapifyUp();
    }

    public void Insert(IEnumerable<T> en)
    {
        foreach (T item in en)
        {
            _data.Add(item);
            HeapifyUp();
        }
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty");

        return _data[0];
    }

    public T ExtractRoot()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty");

        T root = _data[0];
        int lastIndex = Count - 1;

        _data[0] = _data[lastIndex];
        _data.RemoveAt(lastIndex);

        HeapifyDown();

        return root;
    }

    private void HeapifyUp()
    {
        int index = Count - 1;

        while (index > 0)
        {
            // first non-leaf node
            int parentIndex = (index - 1) / 2;

            if (comp.Compare(_data[index], _data[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyDown()
    {
        int index = 0;

        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallestOrLargestIndex = index;

            if (leftChildIndex < Count && comp.Compare(_data[leftChildIndex], _data[smallestOrLargestIndex]) < 0)
                smallestOrLargestIndex = leftChildIndex;

            if (rightChildIndex < Count && comp.Compare(_data[rightChildIndex], _data[smallestOrLargestIndex]) < 0)
                smallestOrLargestIndex = rightChildIndex;

            if (smallestOrLargestIndex != index)
            {
                Swap(index, smallestOrLargestIndex);
                index = smallestOrLargestIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int i, int j)
    {
        T temp = _data[i];
        _data[i] = _data[j];
        _data[j] = temp;
    }

    public List<T> HeapSort()
    {
        Heap<T> copy = new Heap<T>(comp);
        copy.Insert(_data);

        List<T> sortedList = new List<T>();

        while (copy.Count > 0)
        {
            sortedList.Add(copy.ExtractRoot());
        }

        return sortedList;
    }
}
