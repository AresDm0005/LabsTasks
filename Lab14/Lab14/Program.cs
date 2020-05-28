using System;
using System.Collections.Generic;
using System.Linq;
using GoodsTypes;

namespace Lab14
{
    class Program
    {
        private static Random rnd = new Random();
        private static int N = 10;
        private static int deps = 4;

        static List<Goods> CompileList(int size)
        {
            List<Goods> list = new List<Goods>(size);

            for (int j = 0; j < N; j++)
            {
                int type = rnd.Next(4);

                if (type == 0)
                    list.Add(new Goods(rnd));
                else if (type == 1)
                    list.Add(new Toys(rnd));
                else if (type == 2)
                    list.Add(new FoodProduct(rnd));
                else
                    list.Add(new MilkProduct(rnd));
            }

            return list;
        }

        #region queries
        static void ShowResults (IEnumerable<string> list1, IEnumerable<string> list2)
        {
            int index = 0;
            List<string> txt = new List<string>();


            foreach(var item in list1)            
                txt.Add($"{index++} : {item} : ");

            index = 0;
            foreach (var item in list2)
                if (index < txt.Count) txt[index++] += $"{item}";
                else txt.Add($"{index++} : NaN : {item}");

            if (txt.Count == 0) Console.WriteLine("Ничего не найдено по обоим запросам");
            else foreach (var str in txt) Console.WriteLine(str);
        }

        static void Query1Sample(ref List<List<Goods>> shop)
        {
            var query1linq = (from depart in shop from good in depart where good.Title == "Мишки" select good.ToString());
            var query1exp = shop.SelectMany(items => items).Where(item => item.Title == "Мишки").Select(item => item.ToString());

            Console.WriteLine("\nЗапрос #1 (выборка): Товары с названием \"Мишки\"\n# : Linq : Exp");
            ShowResults(query1linq, query1exp);
        }

        static void Query2Counter(ref List<List<Goods>> shop)
        {
            var query2linq = (from depart in shop from good in depart where good.Price > 1001 select good);
            var query2exp = shop.SelectMany(items => items).Where(item => item.Price > 1001);

            Console.WriteLine("\nСчетчик: Запрос #2: Количество товаров, с ценой > 1001:\nLinq : Exp");
            Console.WriteLine($"{query2linq.Count()} : {query2exp.Count()}");
            //Console.WriteLine("# : Linq : Exp");
            //ShowResults(query2linq.Select(item => item.ToString()), query2exp.Select(item => item.ToString()));
        }

        static void Query3Aggregate(ref List<List<Goods>> shop)
        {
            var query3linq = (from depart in shop from good in depart where good.Manufacturer == "Hasbro" select good.Quantity);
            var query3exp = shop.SelectMany(items => items).Where(item => item.Manufacturer == "Hasbro").Select(item => item.Quantity);

            Console.WriteLine("\nАггрегация: Запрос #3: Количество (в шт.) товаров, производителя Hasbro:\nLinq : Exp");
            Console.WriteLine($"{query3linq.Sum()} : {query3exp.Sum()}");
            //Console.WriteLine("# : Linq : Exp");
            //ShowResults(query3linq.Select(item => item.ToString()), query3exp.Select(item => item.ToString()));
        }

        static void Query4SetsExcept(ref List<List<Goods>> shop)
        {
            var query4linq = (from depart in shop from good in depart where good.Price < 100 select good).
                Except(from depart in shop from good in depart where good.Quantity <= 1000 select good);
            var query4exp = shop.SelectMany(items => items).Where(item => item.Price < 100).
                Except(shop.SelectMany(items => items).Where(item => item.Quantity <= 1000));

            Console.WriteLine("\nРазность множеств: Запрос #4: A - B: A = Товары с ценой < 100; B = количество на складе <= 1000;\n# : Linq : Exp");
            ShowResults(query4linq.Select(item => item.ToString()), query4exp.Select(item => item.ToString()));
        }

        static void Query5SetsIntersect(ref List<List<Goods>> shop)
        {
            var query5linq = (from depart in shop from good in depart select good);
            query5linq = (from good in query5linq where good is Toys select good).
                Intersect(from good in query5linq where good.TotalRevenue() < 50000 select good);

            var query5exp = shop.SelectMany(items => items);
            query5exp = query5exp.Where(item => item is Toys).Intersect(query5exp.Where(item => item.TotalRevenue() < 50000));

            Console.WriteLine("\nПересечение множеств: Запрос #5: A перес. B: A = Игрушки; B = Товары с ожид. выручкой < 50000;\n# : Linq : Exp");
            ShowResults(query5linq.Select(item => item.ToString()), query5exp.Select(item => item.ToString()));
        }

        static void Query6SetsUnion(ref List<List<Goods>> shop)
        {
            var query6linq = (from depart in shop from good in depart select good);
            query6linq = (from good in query6linq where good is MilkProduct select good).
                Union(from good in query6linq where good is Toys && (good as Toys).AgeRestriction >= 12 select good);

            var query6exp = shop.SelectMany(items => items);
            query6exp = query6exp.Where(item => item is MilkProduct).
                Union(query6exp.Where(item => item is Toys && (item as Toys).AgeRestriction >= 12));

            Console.WriteLine("\nОбъединение множеств: Запрос #6: A + B: A = Молочные товары; B = Игрушки с ограничениями от 12 лет;\n# : Linq : Exp");
            ShowResults(query6linq.Select(item => item.ToString()), query6exp.Select(item => item.ToString()));
        }
        #endregion

        #region interface
        static void ShowMenu()
        {
            Console.WriteLine("\n\n-------------------------------------------------------\n");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1: Выборка");
            Console.WriteLine("2: Счетчик");
            Console.WriteLine("3: Агрегатор");
            Console.WriteLine("4: Множества - вычитание");
            Console.WriteLine("5: Множества - пересечение");
            Console.WriteLine("6: Множества - объединение");
            Console.WriteLine("0: Завершить работу программы\n");
        }

        static int ReadInteger(string userInstruction, int lowerBound, int upperBound)
        {
            int number = 0;
            bool ok = false;
            do
            {
                try
                {
                    Console.Write(userInstruction);
                    string input = Console.ReadLine();
                    number = int.Parse(input);
                    if (number >= lowerBound && number <= upperBound) ok = true;
                    else
                    {
                        Console.WriteLine($"Ошибка: введите число из промежутка от {lowerBound} до {upperBound}!");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число!");
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: введено слишком большое (маленькое) число!");
                    ok = false;
                }
            } while (!ok);

            return number;
        }
        #endregion

        static void Main(string[] args)
        {
            List<List<Goods>> shop = new List<List<Goods>>();

            for (int i = 0; i < deps; i++)
                shop.Add(CompileList(N));

            int index = 0;
            foreach (var list in shop)
                foreach (var item in list)
                    Console.WriteLine($"{index++} : {item}");

            bool finish = false;
            bool fl = false;
            do
            {   
                ShowMenu();
                int userChoise = ReadInteger("Выбранная опция : ", 0, 6);

                if (userChoise == 1)
                    Query1Sample(ref shop);
                else if (userChoise == 2)
                    Query2Counter(ref shop);
                else if (userChoise == 3)
                    Query3Aggregate(ref shop);
                else if (userChoise == 4)
                    Query4SetsExcept(ref shop);
                else if (userChoise == 5)
                    Query5SetsIntersect(ref shop);
                else if (userChoise == 6)
                    Query6SetsUnion(ref shop);
                else
                    finish = true;

                
            } while (!finish);
        }
    }
}
