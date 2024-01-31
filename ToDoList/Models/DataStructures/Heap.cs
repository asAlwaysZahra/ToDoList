using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private IList<T> _heap;

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

    private void HeapifyDown(int i)
    {
        var leftChild = (i * 2) + 1;
        var rightChild = (i * 2) + 2;
        var biggest = i;

        if (leftChild < Count && _heap[leftChild].CompareTo(_heap[biggest]) > 0)
        {
            biggest = leftChild;
        }

        if (rightChild < Count && _heap[rightChild].CompareTo(_heap[biggest]) > 0)
        {
            biggest = rightChild;
        }

        if (biggest != i)
        {
            // swap them
            (_heap[biggest], _heap[i]) = (_heap[i], _heap[biggest]);

            HeapifyDown(biggest);
        }
    }

    private void HeapifyUp(int i)
    {
        // first non-leaf node
        var parent = (i - 1) / 2;

        while (i > 0 && _heap[i].CompareTo(_heap[parent]) > 0)
        {
            // swap
            (_heap[i], _heap[parent]) = (_heap[parent], _heap[i]);

            i = parent;

            parent = (i - 1) / 2;
        }
    }
}