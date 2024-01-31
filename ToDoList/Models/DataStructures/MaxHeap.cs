namespace ToDoList.Models.DataStructures;

public class MaxHeap<T> : BinaryHeap<T> where T : IComparable<T>
{
    protected override void HeapifyDown(int i)
    {
        var leftChild = (i * 2) + 1;
        var rightChild = (i * 2) + 2;
        var biggest = i;

        if (leftChild < Count && _heap[leftChild].CompareTo(_heap[biggest]) < 0)
        {
            biggest = leftChild;
        }

        if (rightChild < Count && _heap[rightChild].CompareTo(_heap[biggest]) < 0)
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

    protected override void HeapifyUp(int i)
    {
        // first non-leaf node
        var parent = (i - 1) / 2;

        while (i > 0 && _heap[i].CompareTo(_heap[parent]) < 0)
        {
            // swap
            (_heap[i], _heap[parent]) = (_heap[parent], _heap[i]);

            i = parent;

            parent = (i - 1) / 2;
        }
    }
}
