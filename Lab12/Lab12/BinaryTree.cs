using System;
using GoodsTypes;

namespace Lab12
{
    public class BinaryTree
    {
        private Random rand = new Random();
        
        private Goods RandGoods()
        {
            string[] titles = { "Капуста" , "Лук" , "Морковь", "Огурцы", "Свёкла", "Томаты", "Репа", "Тыква", "Редис", "Картошка", "Редька", "Сельдерей", "Горох", "Кукуруза", "Спаржа", "Банан", "Баклажан" };

            return new Goods(titles[rand.Next(titles.Length)], "Овощи", rand.Next(10, 1500), rand.Next(4, 25) * 250);
        }

        private class Node
        {
            public Goods Data;
            public Node Left;
            public Node Right;

            public Node(Goods item)
            {
                Data = item;
                Left = null;
                Right = null;
            }
        }

        public int Count { get; set; }
        private Node root;

        public BinaryTree(int size)
        {
            root = null;
            Count = size;

            root = AVLTree(root, size);
        }

        private Node AVLTree(Node root, int size)
        {
            Node node = null;
            if (size == 0) return null;

            int left = size / 2;
            int right = size - left - 1;
            Goods item = RandGoods();

            node = new Node(item);
            node.Left = AVLTree(node.Left, left);
            node.Right = AVLTree(node.Right, right);
            return node;
        }

        public void Show()
        {
            ShowRun(root, 0);
        }

        private void ShowRun(Node node, int l)
        {
            if (node != null)
            {
                ShowRun(node.Left, l + 4);                                        
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(node.Data);
                ShowRun(node.Right, l + 4);
            }
        }

        public void Task()
        {
            Console.WriteLine("Задание: найти количество элементов дерева, название которых начинается с заданного символа");
            Console.WriteLine("Введите символ для проверки:");
            char let = Console.ReadLine()[0];

            int answer = 0;
            Task(root, ref let, ref answer);

            Console.WriteLine($"Искомый символ: {let}\nКоличество элементов: {answer}");
        }

        private void Task(Node node, ref char let, ref int count)
        {
            if (node != null)
            {
                if (node.Data.Title[0] == let) count++;
                Task(node.Left, ref let, ref count);
                Task(node.Right, ref let, ref count);
            }
        }

        public void TurnSearchTree()
        {
            Goods[] arr = new Goods[Count];
            ToArray(root, 0, Count, ref arr);

            ClearRun(root);
            root = null;
            foreach (Goods item in arr) root = Insert(root, item);
        }

        private Node Insert(Node root, Goods item)
        {
            if (root == null) return new Node(item);

            if (item.Price < root.Data.Price)
                root.Left = Insert(root.Left, item);
            else root.Right = Insert(root.Right, item);

            return root;
        }

        public Goods[] ToArray()
        {
            Goods[] arr = new Goods[Count];
            ToArray(root, 0, Count, ref arr);
            return arr;
        }

        private void ToArray(Node node, int index, int size, ref Goods[] array)
        {
            if (node == null) return;

            array[index] = (Goods)node.Data.Clone();
            ToArray(node.Left, index + 1, size / 2, ref array);
            ToArray(node.Right, index + size / 2 + 1, size - size / 2 - 1, ref array);
        }
        
        public void ClearMemory()
        {
            Console.WriteLine("Memory used before clear: {0}", GC.GetTotalMemory(false));
            ClearRun(root);
            root = null;
            Console.WriteLine("Memory used after clear: {0}", GC.GetTotalMemory(true));
        }

        private void ClearRun(Node node)
        {
            if (node == null) return;

            ClearRun(node.Left);
            ClearRun(node.Right);
            node = null;
        }
    }
}
