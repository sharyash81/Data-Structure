using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace A9
{
    public class Program
    {
        public static void Main()
        {
            string[] s = Console.ReadLine().Split();
            long THREAD_COUNT = long.Parse(s[0]);
            long NUMBER_OF_JOBS = long.Parse(s[1]);
            long[] jD = new long[NUMBER_OF_JOBS];
            string[] s1 = Console.ReadLine().Split();
            for (int i = 0; i < NUMBER_OF_JOBS; i++)
            {
                jD[i] = long.Parse(s1[i]);
            }
            Tuple<long, long>[] ans = Solve(THREAD_COUNT, jD);
            foreach (var i in ans)
            {
                Console.WriteLine(i.Item1 + " " + i.Item2);
            }
        }
        public static Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            int j = 0;
            int Count = jobDuration.Length;
            Tuple<long, long>[] ans = new Tuple<long, long>[Count];
            Thread[] threads = new Thread[threadCount];
            BinaryMinHeap_Array heap = new BinaryMinHeap_Array((int)threadCount);
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(i);
                heap.Insert(threads[i]);
            }
            for (int i = 0; i < Count; i++)
            {
                Thread worker = heap.ExtractMin();
                ans[j] = new Tuple<long, long>(worker.id, worker.release);
                j++;
                worker.release += jobDuration[i];
                heap.Insert(worker);
            }
            return ans;
        }
    }
    public class BinaryMinHeap_Array
    {
        public int size;
        public int MaxSize;
        public Thread[] heap;
        public BinaryMinHeap_Array(int Max)
        {
            this.MaxSize = Max;
            size = 0;
            heap = new Thread[MaxSize];
        }
        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private int LeftChild(int index)
        {
            return 2 * index + 1;
        }
        private int RightChild(int index)
        {
            return 2 * (index + 1);
        }
        public Thread GetMin()
        {
            if (size > 0) return heap[0];
            else throw new Exception("Heap is empty");
        }
        public void Insert(Thread key)
        {
            if (size > MaxSize - 1)
            {
                throw new Exception("Heap is full");
            }
            heap[size] = key;
            SiftUp(size);
            size++;
        }
        private void Swap(int i, int j)
        {
            Thread temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        private void SiftUp(int index)
        {
            while (index > 0 && heap[Parent(index)].CompareTo(heap[index]) > 0)
            {
                Swap(Parent(index), index);
                index = Parent(index);
            }
        }
        private void SiftDown(int index)
        {
            int maxindex = index;
            int l = LeftChild(index);
            if (l <= size && heap[l].CompareTo(heap[maxindex]) < 0)
            {
                maxindex = l;
            }
            int r = RightChild(index);
            if (r <= size && heap[r].CompareTo(heap[maxindex]) < 0)
            {
                maxindex = r;
            }
            if (index != maxindex)
            {
                Swap(index, maxindex);
                SiftDown(maxindex);
            }
        }
        public Thread ExtractMin()
        {
            Thread min = heap[0];
            heap[0] = heap[size - 1];
            size--;
            SiftDown(0);
            return min;
        }
        public void ChangePriority(int index, Thread newVal)
        {
            Thread oldvalue = heap[index];
            heap[index] = newVal;
            if (newVal.CompareTo(oldvalue) > 0)
            {
                SiftDown(index);
            }
            else
            {
                SiftUp(index);
            }
        }
    }
    public class Thread
    {
        public int id;
        public long release;
        public Thread(int id, int release = 0)
        {
            this.id = id;
            this.release = release;
        }
        public int CompareTo(Thread other)
        {
            if (this.release < other.release) return -1;
            if (this.release > other.release) return 1;
            if (this.id < other.id) return -1;
            return 1;

        }
    }


}
