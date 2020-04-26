using System;
using System.Collections.Generic;
using GoodsTypes;

namespace Lab11
{
    class Program
    {
        #region support_methods
        private static Random rand = new Random();
        private static string[] names;
        private static string[] manufacturers;
        private static string[] milkTypes;

        private static int ReadInteger(string userInstruction, int lowerBound, int upperBound)
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

            Console.WriteLine();
            return number;
        }

        private static Goods RandomItem()
        {
            string[] titles = { "Монополия", "Домик", "Простоквашино", "Ряженка", "Маска", "Матроскин", "Яблоки", "Куб", "Треугольник", "Пакет", "Калька", "Чудо", "Языки", "Пластик" };
            string[] manufs = { "Nestle", "BMW", "Pepsi Co.", "Coca Cola Co.", "Нытвенский молзавод", "Hasbro", "Lego", "Asus" };
            manufacturers = manufs;
            names = titles;

            string title = titles[rand.Next(titles.Length)];
            string manuf = manufs[rand.Next(manufs.Length)];
            int price = rand.Next(49, 200);
            int quantity = rand.Next(4, 21) * 200;

            int typeChoise = rand.Next(0, 100);
            int itemType;   // 19% - 27% - 27% - 27%                
            if (typeChoise >= 0 && typeChoise <= 18) itemType = 1;
            else if (typeChoise >= 19 && typeChoise <= 45) itemType = 2;
            else if (typeChoise >= 46 && typeChoise <= 71) itemType = 3;
            else itemType = 4;

            switch (itemType)
            {
                case 1:
                    {
                        Goods item = new Goods(title, manuf, price, quantity);
                        return item;
                    }
                case 2:
                    {
                        string[] types = { "Мягкая игрушка", "Настольная игра", "Конструктор" };
                        string type = types[rand.Next(types.Length)];
                        int age = rand.Next(19);

                        Toys item = new Toys(title, manuf, price, quantity, age, type);
                        return item;
                    }
                case 3:
                    {
                        DateTime manufactured = DateTime.Now - (new TimeSpan(rand.Next(1, 10), 12, 30, 0));
                        int lifeSpan = rand.Next(1, 8) * 24;

                        FoodProduct item = new FoodProduct(title, manuf, price, quantity, manufactured, lifeSpan);
                        return item;
                    }
                case 4:
                    {
                        DateTime manufactured = DateTime.Now - (new TimeSpan(rand.Next(1, 10), 12, 30, 0));
                        int lifeSpan = rand.Next(1, 8) * 24;
                        string[] types = { "Молоко", "Творог", "Сыр", "Кефир" };
                        milkTypes = types;
                        string type = types[rand.Next(types.Length)];
                        double weight = rand.Next(5, 20) / 10.0;

                        MilkProduct item = new MilkProduct(title, manuf, price, quantity, manufactured, lifeSpan, type, weight);
                        return item;
                    }
                default: return new Goods();
            }
        }

        private static void PartsMenu()
        {
            Console.WriteLine("Выберите опцию меню:");
            Console.WriteLine("1: Добавить новый элемент");
            Console.WriteLine("2: Удалить последний элемент");
            Console.WriteLine("3: Запрос 1 - Общая стоимость товара определенного производителя");
            Console.WriteLine("4: Запрос 2 - Все игрушки на складе для возрастов больше определенного");
            Console.WriteLine("5: Запрос 3 - Количество на складе молочных товаров определенного типа");
            Console.WriteLine("6: Сортировка массива");
            Console.WriteLine("7: Клонирование коллекции");
            Console.WriteLine("0: Завершение работы программы\n");
        }

        private static Stack<Goods> MakeStack(int size)
        {
            Stack<Goods> goods = new Stack<Goods>();

            for (int i = 0; i < size; i++) goods.Push(RandomItem());

            return goods;
        }

        private static void ShowCollection(string message, ref Stack<Goods> goods)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            foreach (Goods good in goods.ToArray()) good.Show();
            Console.ResetColor();
        }

        private static List<Goods> MakeList(int size)
        {
            List<Goods> goods = new List<Goods>();

            for (int i = 0; i < size; i++) goods.Add(RandomItem());

            return goods;
        }

        private static void ShowCollection(string message, ref List<Goods> goods)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            foreach (Goods good in goods) good.Show();
            Console.ResetColor();
        }

        #endregion

        public static void Part1()
        {
            Console.WriteLine("Создание коллекции:");
            int size = ReadInteger("Введите размер коллекции: ", 1, 25);
                        
            Stack<Goods> goods = MakeStack(size);
            ShowCollection("Созданная коллекция:", ref goods);

            bool finish = false;
            do
            {
                PartsMenu();
                int userChoise = ReadInteger("Опция: ", 0, 7);

                switch (userChoise)
                {
                    case 1:
                        {
                            goods.Push(RandomItem());
                            Console.WriteLine("Новый элемент:");
                            goods.Peek().Show();
                            break;
                        }
                    case 2:
                        {
                            Goods item = goods.Pop();
                            Console.WriteLine($"Элемент {item.Title} удален\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Возможные производители:");
                            foreach (string txt in manufacturers) Console.Write(txt + " ");

                            Console.Write("\nВведите название интересующего производителя: ");
                            string manuf = Console.ReadLine();

                            int sum = 0, count = 0;
                            foreach (Goods good in goods)
                            {
                                if (good.Manufacturer == manuf)
                                {
                                    sum += good.TotalRevenue();
                                    count++;
                                }
                            }

                            if (count == 0) Console.WriteLine($"Товаров производителя {manuf} не найдено");
                            else Console.WriteLine($"Общая стоимость товаров, произведенных {manuf} = {sum} за {count} товаров");
                            break;
                        }
                    case 4:
                        {
                            int age = ReadInteger("Введите нижнюю возрастную границу: ", 0, 18);

                            int count = 0;
                            foreach (Goods good in goods.ToArray())
                            {
                                if (good is Toys)
                                {
                                    Toys item = good as Toys;
                                    if (item.AgeRestriction >= age)
                                    {
                                        count++;
                                        Console.WriteLine($"Игрушка {item.Title}, производителя {item.Manufacturer}, имеет ограничение {item.AgeRestriction}+");
                                    }
                                }
                            }

                            if (count == 0) Console.WriteLine("Игрушек с таким ограничением не найдено");
                            break;
                        }
                    case 5:
                        {
                            if (milkTypes == null) Console.WriteLine("Молочных продуктов не найдено");
                            else
                            {
                                Console.WriteLine("Возможные молочные продукты:");
                                foreach (string txt in milkTypes) Console.Write(txt + " ");

                                Console.Write("\nВведите интересующий молочный тип товара: ");
                                string type = Console.ReadLine();
                                Console.WriteLine();

                                int count = 0;
                                foreach (Goods good in goods)
                                {
                                    if (good is MilkProduct)
                                    {
                                        MilkProduct item = (MilkProduct)good;
                                        if (item.Type == type)
                                        {
                                            count++;
                                            Console.WriteLine($"На складе есть {item.Quantity} штук {item.Type} {item.Title}");
                                        }
                                    }
                                }

                                if (count == 0) Console.WriteLine($"Молочных продуктов типа {type} не найдено");
                            }

                            break;
                        }
                    case 6:
                        {
                            Goods[] tmpGoods = goods.ToArray();
                            Array.Sort(tmpGoods, new DescendingSortByRevenue());

                            goods = new Stack<Goods>();
                            foreach (Goods good in tmpGoods) goods.Push(good);

                            ShowCollection("Отсортированная коллекция:", ref goods);
                            break;
                        }
                    case 7:
                        {
                            Stack<Goods> items = new Stack<Goods>();

                            foreach (Goods good in goods.ToArray()) items.Push((Goods)good.Clone());

                            int quantity = goods.Peek().Quantity;

                            goods.Peek().DeliverMade(100000);

                            Console.WriteLine("Goods: " + goods.Peek().Quantity);
                            Console.WriteLine("Cloned: " + items.Peek().Quantity);

                            goods.Peek().DeliverMade(quantity);
                            break;
                        }
                    default:
                        {
                            finish = true;
                            break;
                        }
                }
                Console.WriteLine();
            } while (!finish);


        }

        public static void Part2()
        {
            Console.WriteLine("Создание коллекции:");
            int size = ReadInteger("Введите размер коллекции: ", 1, 25);

            List<Goods> goods = MakeList(size);
            ShowCollection("Созданная коллекция:", ref goods);

            bool finish = false;
            do
            {
                PartsMenu();
                int userChoise = ReadInteger("Опция: ", 0, 7);

                switch (userChoise)
                {
                    case 1:
                        {
                            goods.Add(RandomItem());
                            Console.WriteLine("Новый элемент:");
                            goods[goods.Count - 1].Show();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Элемент {goods[goods.Count - 1].Title} удален\n");
                            goods.RemoveAt(goods.Count - 1);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Возможные производители:");
                            foreach (string txt in manufacturers) Console.Write(txt + " ");

                            Console.Write("\nВведите название интересующего производителя: ");
                            string manuf = Console.ReadLine();

                            int sum = 0, count = 0;
                            foreach (Goods good in goods)
                            {
                                if (good.Manufacturer == manuf)
                                {
                                    sum += good.TotalRevenue();
                                    count++;
                                }
                            }

                            if (count == 0) Console.WriteLine($"Товаров производителя {manuf} не найдено");
                            else Console.WriteLine($"Общая стоимость товаров, произведенных {manuf} = {sum} за {count} товаров");
                            break;
                        }
                    case 4:
                        {
                            int age = ReadInteger("Введите нижнюю возрастную границу: ", 0, 18);

                            int count = 0;
                            foreach (Goods good in goods.ToArray())
                            {
                                if (good is Toys)
                                {
                                    Toys item = good as Toys;
                                    if (item.AgeRestriction >= age)
                                    {
                                        count++;
                                        Console.WriteLine($"Игрушка {item.Title}, производителя {item.Manufacturer}, имеет ограничение {item.AgeRestriction}+");
                                    }
                                }
                            }

                            if (count == 0) Console.WriteLine("Игрушек с таким ограничением не найдено");
                            break;
                        }
                    case 5:
                        {
                            if (milkTypes == null) Console.WriteLine("Молочных продуктов не найдено");
                            else
                            {
                                Console.WriteLine("Возможные молочные продукты:");
                                foreach (string txt in milkTypes) Console.Write(txt + " ");

                                Console.Write("\nВведите интересующий молочный тип товара: ");
                                string type = Console.ReadLine();
                                Console.WriteLine();

                                int count = 0;
                                foreach (Goods good in goods)
                                {
                                    if (good is MilkProduct)
                                    {
                                        MilkProduct item = (MilkProduct)good;
                                        if (item.Type == type)
                                        {
                                            count++;
                                            Console.WriteLine($"На складе есть {item.Quantity} штук {item.Type} {item.Title}");
                                        }
                                    }
                                }

                                if (count == 0) Console.WriteLine($"Молочных продуктов типа {type} не найдено");
                            }

                            break;
                        }
                    case 6:
                        {
                            Goods[] tmpGoods = goods.ToArray();
                            Array.Sort(tmpGoods, new DescendingSortByRevenue());

                            goods = new List<Goods>();
                            foreach (Goods good in tmpGoods) goods.Add(good);

                            ShowCollection("Отсортированная коллекция:", ref goods);
                            break;
                        }
                    case 7:
                        {
                            List<Goods> items = new List<Goods>();

                            int i = 0;
                            foreach (Goods good in goods) items.Add((Goods)good.Clone());

                            int quantity = goods[goods.Count - 1].Quantity;

                            goods[goods.Count - 1].DeliverMade(100000);

                            Console.WriteLine("Goods: " + goods[goods.Count - 1].Quantity);
                            Console.WriteLine("Cloned: " + items[goods.Count - 1].Quantity);

                            goods[goods.Count - 1].DeliverMade(quantity);
                            break;
                        }
                    default:
                        {
                            finish = true;
                            break;
                        }
                }
                Console.WriteLine();
            } while (!finish);
        }

        public static void Part3()
        {
            TestCollection test = new TestCollection(1000);        
            test.ContainsTime();
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(200, 60);
            //Part1();
            //Part2();
            Part3();
        }
    }
}
