using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Algorithm
{
    public class PriorityQueue<T>
    {
        private List<T> heap;
        private IComparer<T> comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            this.heap = new List<T>();
            this.comparer = comparer;
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = heap.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparer.Compare(heap[parent], heap[i]) <= 0)
                    break;
                T temp = heap[parent];
                heap[parent] = heap[i];
                heap[i] = temp;
                i = parent;
            }
        }

        public T Dequeue()
        {
            int last = heap.Count - 1;
            T frontItem = heap[0];
            heap[0] = heap[last];
            heap.RemoveAt(last);

            last--;
            int i = 0;
            while (true)
            {
                int left = i * 2 + 1;
                int right = i * 2 + 2;
                if (left > last)
                    break;
                int j = left;
                if (right <= last && comparer.Compare(heap[right], heap[left]) < 0)
                    j = right;
                if (comparer.Compare(heap[i], heap[j]) <= 0)
                    break;
                T temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
                i = j;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = heap[0];
            return frontItem;
        }

        public int Count
        {
            get { return heap.Count; }
        }
        public void PrintSorted()
        {
            PriorityQueue<T> copy = new PriorityQueue<T>(comparer);
            foreach (T item in heap)
            {
                copy.Enqueue(item);
            }
            while (copy.Count > 0)
            {
                Console.WriteLine(copy.Dequeue());
            }
        }
    }
}
