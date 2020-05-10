using System;
using GoodsTypes;

namespace Lab12
{
    public class OneWayList
    {
        private class Node
        {
            public Goods Data { get; set; }
            public Node Next { get; set; }

            public Node(Goods item)
            {
                Data = item;
                Next = null;
            }
        }

        public int Count { get; private set; }
        private Node head;
        private Node tail;

        public OneWayList()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        public void AddFirst(Goods item)
        {
            Node node = new Node(item);

            if (head != null) node.Next = head;
            else tail = node;

            head = node;
            Count++;
        }

        public void AddLast(Goods item)
        {
            Node node = new Node(item);

            if (head == null) head = node;
            else
            {
                tail.Next = node;
            }

            tail = node;
            Count++;
        }

        public void AddAt(int index, Goods item)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Index", "Index must be non negative number");
            if (index > Count) throw new ArgumentOutOfRangeException("Index", "Index must be less than or equal to size of the list");
                       

            if (index == 0) AddFirst(item);
            else if (index == Count) AddLast(item);
            else
            {
                Node find = head;                

                int ind = 0;
                while (ind + 1 < index)
                {
                    find = find.Next;
                    ind++;
                }

                Node node = new Node(item);
                node.Next = find.Next;
                find.Next = node;
                Count++;
            }
        }

        public int PriceOf(int index)
        {
            if (head == null) return -1;
            else if (index > Count || index < 0) return -1;
            else
            {
                Node node = head;
                int i = 0;

                while (node != null & i < index)
                {
                    node = node.Next;
                    i++;
                }

                return (node != null) ? node.Data.Price : -1;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Index", "Index must be non negative number");
            if (index > Count) throw new ArgumentOutOfRangeException("Index", "Index must be less than size of the list");

            if(index == 0)
            {
                head = head.Next;
                Count--;
                return;
            }

            Node find = head;
            int ind = 0;
            while(ind + 1 < index)
            {
                find = find.Next;
                ind++;
            }

            find.Next = find.Next.Next;
            if(index == Count - 1)
            {
                tail = find;
            }

            Count--;
        }

        public void Remove(Goods item)
        {
            if (head == null) throw new ArgumentException();
            Node find = head;
            Node prev = null;

            if(head.Data.Equals(item))
            {
                head = head.Next;
                Count--;
                return;
            }

            while (find != null)
            {
                if (find.Data.Equals(item)) break;
                prev = find;
                find = find.Next;
            }

            if (find == null) Console.WriteLine("Такой элемент не найден. Ничего не было удалено");
            else
            {
                prev.Next = find.Next;                                

                if(tail == find)
                {
                    tail = prev;
                }
                Count--;
            }
        }

        public void Show()
        {
            if (Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Node node = head;
            int index = 0;

            while(node != null)
            {
                Console.WriteLine($"{index} : {node.Data}");
                index++;
                node = node.Next;
            }            
        }

        public void Task()
        {
            Console.WriteLine("Задание:\nДобавить в список после каждого элемента с \'отрицательным\' " +
                "(с ценой < 100) информационным полем элемент с информационным полем равным 0\n");

            Node node = head;
            while(node != null)
            {                
                if (node.Data.Price < 100)
                {
                    Count++;
                    Node add = new Node(new Goods("Элемент", "Задания", 0, 0));
                    add.Next = node.Next;
                    node.Next = add;

                    node = add.Next;
                } else node = node.Next;
            }

            Show();
        }

        public void DeleteList()
        {
            Node node = head;
            while (node != null)
            {
                Node cur = node;
                node = node.Next;
                cur.Next = null;
            }

            head = null;
            tail = null;
        }
    }
}
