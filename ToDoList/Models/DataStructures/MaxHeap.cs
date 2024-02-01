namespace ToDoList.Models.DataStructures;

public class MaxHeap<T> : BinaryHeap<T> where T : IComparable<T>
{
    protected override void HeapifyDown(int i)
    {
        var leftChild = (i * 2) + 1;
        var rightChild = (i * 2) + 2;
        var biggest = i;

        if (leftChild < Count && heap[leftChild].CompareTo(heap[biggest]) < 0)
        {
            biggest = leftChild;
        }

        if (rightChild < Count && heap[rightChild].CompareTo(heap[biggest]) < 0)
        {
            biggest = rightChild;
        }

        if (biggest != i)
        {
            // swap them
            (heap[biggest], heap[i]) = (heap[i], heap[biggest]);

            HeapifyDown(biggest);
        }
    }

    protected override void HeapifyUp(int i)
    {
        // first non-leaf node
        var parent = (i - 1) / 2;

        while (i > 0 && heap[i].CompareTo(heap[parent]) < 0)
        {
            // swap
            (heap[i], heap[parent]) = (heap[parent], heap[i]);

            i = parent;

            parent = (i - 1) / 2;
        }
    }
}
