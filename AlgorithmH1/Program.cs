using System;
using System.Diagnostics;

namespace AlgorithmH1
{
    internal class CustomQueue
    {
        private int[] queueArray;
        private int front;
        private int rear;
        private int count;
        private int capacity;
      
        public CustomQueue(int size)
        {
            capacity = size;
            queueArray = new int[capacity];
            front = 0;
            rear = -1;
            count = 0;
        }
        public void Enqueue(int item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Queue is full.");
            }

            rear = (rear + 1) % capacity;
            queueArray[rear] = item;
            count++;
        }
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            int item = queueArray[front];
            front = (front + 1) % capacity;
            count--;
            return item;
        }
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return queueArray[front];
        }
        public bool IsEmpty()
        {
            return count == 0;
        }
        public bool IsFull()
        {
            return count == capacity;
        }
        public int Count()
        {
            return count;
        }
    }
    internal class Program
    {
       static void recursiveInsertionSort(int[]_arr,int n)
        {
            if (n <= 1)
                return;

            recursiveInsertionSort(_arr, n - 1);

            int lastElement = _arr[n - 1];
            int j = n - 2;

            while (j >= 0 && _arr[j] > lastElement)
            {
                _arr[j + 1] = _arr[j];
                j--;
            }
            _arr[j + 1] = lastElement;
        }
        static void printSort(int []_arr,int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(_arr[i]+" | ");
        }
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue(5);

            queue.Enqueue(10);
            queue.Enqueue(-10);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());

            int[] arr = { 1, 2, 10, 0, -10, 2, 5, 2 };
            int size = arr.Length;
            recursiveInsertionSort(arr, size);

            printSort(arr,size);
            Console.ReadLine();

        }
    }
}
