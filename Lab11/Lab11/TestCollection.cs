using System;
using System.Collections.Generic;
using System.Diagnostics;
using GoodsTypes;

namespace Lab11
{
    class TestCollection
    {
        private LinkedList<Goods> listKey;
        private LinkedList<string> listString;
        private Dictionary<Goods, Toys> dictTypes;
        private Dictionary<string, Toys> dictString;
        private Goods[] arr;
        private Toys[] mas;

        private string[] titles = { "Монополия", "Домик", "Простоквашино", "Ряженка", "Маска", "Матроскин", "Яблоки", "Куб", "Треугольник", "Пакет", "Калька", "Чудо", "Языки", "Пластик" };
        private string[] manufs = { "Nestle", "BMW", "Pepsi Co.", "Coca Cola Co.", "Нытвенский молзавод", "Hasbro", "Lego", "Asus" };
        private static Random rand = new Random();

        public int Size { get; private set; }

        public Toys RandomItem()
        {
            string title = titles[rand.Next(titles.Length)];
            string manuf = manufs[rand.Next(manufs.Length)];
            int price = rand.Next(49, 2000);
            int quantity = rand.Next(4, 51) * 200;
            string[] types = { "Мягкая игрушка", "Настольная игра", "Конструктор" };
            string type = types[rand.Next(types.Length)];
            int age = rand.Next(19);
            Toys toys = new Toys(title, manuf, price, quantity, age, type);
            Goods tmp = toys.BaseGoods;

            return toys;
        }

        public TestCollection(int size)
        {
            listKey = new LinkedList<Goods>();
            listString = new LinkedList<string>();

            dictTypes = new Dictionary<Goods, Toys>(size);
            dictString = new Dictionary<string, Toys>(size);

            arr = new Goods[size];
            mas = new Toys[size];
            Size = size;

            for (int i = 0; i < size; i++)
            {   
                Toys toy = RandomItem();

                arr[i] = toy.BaseGoods;
                mas[i] = toy;

                listKey.AddLast(toy.BaseGoods);
                listString.AddLast(toy.BaseGoods.ToString());

                dictTypes.Add(toy.BaseGoods, toy);
                dictString.Add(toy.BaseGoods.ToString(), toy);
            }
        }

        public void AddItem(Goods good, Toys toy)
        {
            if(dictTypes.ContainsKey((Goods)good.Clone()) || dictTypes.ContainsValue((Toys)toy.Clone()))
            {
                Console.WriteLine("Такой элемент уже существуют");
                return;
            }

            listKey.AddLast((Goods)good.Clone());
            listString.AddLast(good.ToString());

            dictTypes.Add((Goods)good.Clone(), (Toys)toy.Clone());
            dictString.Add(good.ToString(), (Toys)toy.Clone());

            Size = listString.Count;
        }

        public void RemoveItem(Goods good)
        {
            if (!dictTypes.ContainsKey((Goods)good.Clone()))
            {
                Console.WriteLine("Такого ключа изначально не существует");
                return;
            }

            listKey.Remove((Goods)good.Clone());
            listString.Remove(good.ToString());

            dictTypes.Remove((Goods)good.Clone());
            dictString.Remove(good.ToString());

            Size = listString.Count;
        }

        public void ContainsTime()
        {
            // 0 - Constains по listKey
            // 1 - Contains по listString
            // 2 - ContainsKey по dictTypes
            // 3 - ContainsKey по dictString
            // 4 - ContainsValue по dictTypes
            Stopwatch[,] times = new Stopwatch[5, 4];
            bool[,] found = new bool[5, 4];

            Goods[] search = { (Goods)arr[0].Clone() , (Goods)arr[Size / 2].Clone(), (Goods)arr[Size - 1].Clone(), new Goods("Маски", "Медицинские",10,1000) };
            Toys[] toys = { (Toys)mas[0].Clone(), (Toys)mas[Size/2].Clone(), (Toys)mas[Size-1].Clone(), new Toys("Маски", "Медицинские", 10, 1000, 3, "Обучающие") }; 

            // 0
            for(int i = 0; i < search.Length; i++)
            {
                times[0, i] = new Stopwatch();
                times[0, i].Start();

                found[0, i] = listKey.Contains(search[i]);
                times[0, i].Stop();
            }

            // 1
            for (int i = 0; i < search.Length; i++)
            {
                times[1, i] = new Stopwatch();
                times[1, i].Start();

                found[1, i] = listString.Contains(search[i].ToString());
                times[1, i].Stop();
            }

            // 2
            for (int i = 0; i < search.Length; i++)
            {
                times[2, i] = new Stopwatch();
                times[2, i].Start();

                found[2, i] = dictTypes.ContainsKey(search[i]);
                times[2, i].Stop();
            }

            // 3
            for (int i = 0; i < search.Length; i++)
            {
                times[3, i] = new Stopwatch();
                times[3, i].Start();

                found[3, i] = dictString.ContainsKey(search[i].ToString());
                times[3, i].Stop();
            }

            // 4
            for (int i = 0; i < search.Length; i++)
            {
                times[4, i] = new Stopwatch();
                times[4, i].Start();

                found[4, i] = dictTypes.ContainsValue(toys[i]);
                times[4, i].Stop();
            }

            PrintResults(ref times, ref found);
        }

        private void PrintResults(ref Stopwatch[,] times, ref bool[,] found)
        {
            Console.WriteLine("Коллекция1: LinkedList; Коллекция2: Dictionary\nTKey: Goods; TValue: Toys\n");
            string[] collNames = { "Коллекция1<TKey>", "Коллекция1<string>", "Коллекция2<TKey, TValue>", "Коллекция2<string, TValue>", "Коллекция2<TKey, TValue>" };
            string[] funcName = { "Contains", "Contains", "ContainsKey", "ContainsKey", "ContainsValue" };

            Console.WriteLine($"Размер массива: {Size}\n");
            for(int i = 0; i<times.GetLength(0); i++)
            {
                Console.WriteLine($"{collNames[i]}, метод: {funcName[i]}");
                for (int j = 0; j < times.GetLength(1); j++)
                {
                    string ans = found[i, j] ? "Да" : "Нет";
                    Console.WriteLine($"\t{times[i,j].Elapsed} мс. Найдено: {ans}");
                }
                Console.WriteLine();
            }
        }

        public void PrintAllItems()
        {
            Console.WriteLine("Сгенерированные объекты:");
            for(int i = 0; i<arr.Length; i++)
            {
                Console.WriteLine($"{i}:\nБазовый:\t{arr[i]}\nПроизводный:\t{mas[i]}");
            }
            Console.WriteLine("\n");
        }
    }
}
