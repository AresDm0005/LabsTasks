using System;
using GoodsTypes;

namespace Lab12
{
    public class TwoWayList
    {
        private class Node
        {
            public Goods Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(Goods item)
            {
                Data = item;
            }
        }

        public int Count { get; private set; }
        private Node head;
        private Node tail;

        public void AddFirst(Goods item)
        {
            Node node = new Node(item);

            if (head != null)
            {
                node.Prev = null;
                node.Next = head;
                head.Prev = node;
            }
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
                node.Prev = tail;
                node.Next = null;
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

                while (ind < index)
                {
                    find = find.Next;
                    ind++;
                }

                Node node = new Node(item);

                node.Next = find;
                node.Prev = find.Prev;

                find.Prev = node;
                Count++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Index", "Index must be non negative number");
            if (index > Count) throw new ArgumentOutOfRangeException("Index", "Index must be less than size of the list");

            if (index == 0)
            {
                head = head.Next;
                head.Prev = null;
                Count--;
                return;
            }
            
            Node find = head;
            int ind = 0;
            while (ind < index)
            {
                find = find.Next;
                ind++;
            }

            Node prev = find.Prev;
            Node next = find.Next;
                        
            if(find == tail)
            {
                prev.Next = null;
                tail = prev;                
            } else
            {
                prev.Next = next;
                next.Prev = prev;
            }            
            
            Count--;
        }

        public void Remove(Goods item)
        {
            Node find = head;
            Node prev = null;

            if (head.Data.Equals(item))
            {
                head = head.Next;
                head.Prev = null;
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
                Node next = find.Next;

                if (find == tail)
                {
                    prev.Next = null;
                    tail = prev;
                }
                else
                {
                    prev.Next = next;
                    next.Prev = prev;
                }

                Count--;
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

        public void ShowForward()
        {
            if (Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Node node = head;
            int index = 0;

            while (node != null)
            {
                Console.WriteLine($"{index} : {node.Data}");
                index++;
                node = node.Next;
            }
        }

        public void ShowBackward()
        {
            if (Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Node node = tail;
            int index = Count - 1;

            while (node != null)
            {
                Console.WriteLine($"{index} : {node.Data}");
                index--;
                node = node.Prev;
            }
        }

        public void Task()
        {
            Console.WriteLine("Задание:\nУдалить из списка первый элемент с четным " +
                "информационным полем (ценой).\n");

            Node node = head;

            string txt = "Ничего не было удалено";
            while(node != null)
            {
                if (node.Data.Price % 2 == 0) {
                    txt = $"Был удален товар: {node.Data.Title} с ценой {node.Data.Price}";
                    Remove(node.Data);
                    break;
                }
                node = node.Next;
            }

            Console.WriteLine(txt + "\n");
            Console.WriteLine("После выполнения задания список выглядит так:\n");
            ShowForward();
        }

        public void DeleteList()
        {
            Node node = head;
            while (node != null)
            {
                Node cur = node;
                node = node.Next;
                cur.Next = null;
                cur.Prev = null;
            }

            head = null;
            tail = null;
        }
    }
}
