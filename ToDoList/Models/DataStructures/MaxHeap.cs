namespace ToDoList.Models.DataStructures;

public class MaxHeap<T> : BinaryHeap<T>
{
    public MaxHeap(IComparer<T> comp, T[]? elements = null) : base(comp, elements)
    {
    }

    protected override void HeapifyDown(int i)
    {
        var leftChild = (i * 2) + 1;
        var rightChild = (i * 2) + 2;
        var biggest = i;

        if (leftChild < Count && comp.Compare(heap[leftChild], heap[biggest]) < 0)
        {
            biggest = leftChild;
        }

        if (rightChild < Count && comp.Compare(heap[rightChild], heap[biggest]) < 0)
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

        while (i > 0 && comp.Compare(heap[i], heap[parent]) < 0)
        {
            // swap
            (heap[i], heap[parent]) = (heap[parent], heap[i]);

            i = parent;

            parent = (i - 1) / 2;
        }
    }
}
