using System;
using System.Collections;
using System.Collections.Generic;
using GoodsTypes;

namespace Lab12
{
    public class MyQueue<T> : ICloneable, IEnumerable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                Data = item;
                Next = null;
            }
        }

        private readonly int basicCapacity = 4;
        public int Capacity { get; private set; } // At least 1, Grow 2x
        public int Count { get; private set; }

        private Node head;
        private Node tail;
        private IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
        
        public MyQueue()
        {
            Capacity = basicCapacity;
            Count = 0;
            head = null;
        }

        public MyQueue(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException("capacity", "Ёмкость коллекции должна выражаться положительным числом");
            Capacity = capacity;
            Count = 0;        
            head = null;
        }

        public MyQueue(MyQueue<T> queue)
        {
            Capacity = queue.Capacity;
            Node node = queue.head;

            while(node != null)
            {
                Enqueue(node.Data);
                node = node.Next;
            }
        }

        public void Enqueue(T item)
        {
            Node node = new Node(item);

            if(head == null)
            {
                head = node;
                tail = node;
                Count++;
                return;
            }

            Count++;
            if (Count == Capacity) Capacity *= 2;
            tail.Next = node;
            tail = node;            
        }

        public T Dequeue()
        {
            if (head == null) throw new NullReferenceException("Очередь пуста");

            T item = head.Data;
            head = head.Next;
            Count--;

            return item;
        }

        public T Peek()
        {
            if (head == null) throw new NullReferenceException("Очередь пуста");

            T item = head.Data;
            return item;
        }

        public bool Contains(T item)
        {
            if (item == null) throw new NullReferenceException();

            bool ok = false;
            Node look = head;

            while(look != null && !ok)
            {
                ok = comparer.Equals(look.Data, item);
                look = look.Next;
            }

            return ok;
        }

        public object Clone()
        {
            return new MyQueue<T>(this);
        }

        public MyQueue<T> SurfaceClone()
        {
            return this;
        }

        public void Clean()
        {
            Node node = head;

            while (node != null)
            {
                Node prev = node;
                node = node.Next;
                prev.Next = null;
            }

            head = null;
            tail = null;
            Count = 0;
            Capacity = basicCapacity;

            GC.Collect();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        class Enumerator : IEnumerator<T>
        {
            private Node head;
            private Node curr;

            public Enumerator(MyQueue<T> queue)
            {
                head = queue.head;
                curr = null;
            }

            public T Current 
            {
                get 
                {
                    if (curr != null) return curr.Data;
                    throw new InvalidOperationException();
                } 
            }

            object IEnumerator.Current
            {
                get
                {
                    if (curr == null) throw new InvalidOperationException();
                    return new Node(curr.Data);
                }
            }

            public bool MoveNext()
            {
                if (curr == null)
                {
                    curr = head;
                    return true;
                }

                if(curr.Next != null)
                {
                    curr = curr.Next;
                    return true;
                } 
                else
                {
                    Reset();
                    return false;
                }
            }

            public void Reset()
            {
                curr = null;
            }

            public void Dispose() { }
        }
    }
}