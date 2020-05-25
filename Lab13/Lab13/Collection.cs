using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Collection<T> : IEnumerable<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                Data = item;
                Next = null;
            }
        }

        public int Length { get; protected set; }
        protected Node head;
        protected Node tail;

        public Collection()
        {
            Length = 0;
            head = null;
            tail = null;
        }

        public Collection(T[] arr)
        {
            head = null;
            tail = null;
            for (int i = 0; i < arr.Length; i++) 
                Add(arr[i]);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Length) throw new IndexOutOfRangeException();
                return FindNode(index).Next.Data;
            }

            set
            {
                if (index < 0 || index > Length) throw new IndexOutOfRangeException();

                Node node = FindNode(index).Next;
                node.Data = value;
            }
        }

        protected Node FindNode(int index)
        {
            Node find = head;

            // Для вставки & удаления нам нужен узел за 1 до индекса
            index--;

            int ind = 0;
            while (ind < index)
            {
                find = find.Next;
                ind++;
            }

            return find;
        }

        public void Add(T item)
        {
            Node node = new Node(item);

            if (head == null) head = node;
            else tail.Next = node;

            Length++;
            tail = node;
        }

        public void Remove(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Индекс", "Индекс должен быть выражен неотрицательным числом");
            if (index > Length) throw new ArgumentOutOfRangeException("Индекс", "Индекс должен быть меньше или равно числу элементов в листе");

            if (index == 0) head = head.Next;
            else
            {
                Node node = FindNode(index);
                node.Next = node.Next.Next;
            }

            Length--;
        }

        public void Sort(IComparer<T> comparer)
        {
            T[] array = new T[Length];

            Node node = head;
            int index = 0;
            while (node != null)
            {
                array[index++] = node.Data;
                node = node.Next;
            }

            Array.Sort(array, comparer);
            Clear();

            for (int i = 0; i < array.Length; i++)
                Add(array[i]);
        }

        public void Clear()
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
            Length = 0; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
