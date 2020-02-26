using System;

namespace Lab10
{
    class Program
    {
        private static Goods[] CreateArray()
        {
            string[] titles = { "Монополия", "Домик", "Простоквашино", "Ряженка", "Маска", "Матроскин" };
            string[] manufs = { "Nestle", "BMW", "Pepsi Co.", "Coca Cola Co.", "Нытвенский молзавод", "Hasbro", "Lego", "Asus" };

            int N = 25;
            Goods[] goods = new Goods[N];

            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
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
                            goods[i] = item;
                            break;
                        }
                    case 2:
                        {
                            string[] types = { "Мягкая игрушка", "Настольная игра", "Конструктор" };
                            string type = types[rand.Next(types.Length)];
                            int age = rand.Next(19);

                            Toys item = new Toys(title, manuf, price, quantity, age, type);
                            goods[i] = item;
                            break;
                        }
                    case 3:
                        {
                            DateTime manufactured = DateTime.Now - (new TimeSpan(rand.Next(1, 10), 12, 30, 0));
                            int lifeSpan = rand.Next(1, 8) * 24;

                            FoodProduct item = new FoodProduct(title, manuf, price, quantity, manufactured, lifeSpan);
                            goods[i] = item;
                            break;
                        }
                    case 4:
                        {
                            DateTime manufactured = DateTime.Now - (new TimeSpan(rand.Next(1, 10), 12, 30, 0));
                            int lifeSpan = rand.Next(1, 8) * 24;
                            string[] types = { "Молоко", "Творог", "Сыр", "Кефир" };
                            string type = types[rand.Next(types.Length)];
                            double weight = rand.Next(5, 20) / 10.0;

                            MilkProduct item = new MilkProduct(title, manuf, price, quantity, manufactured, lifeSpan, type, weight);
                            goods[i] = item;
                            break;
                        }
                }
            }

            return goods;
        }

        private static void Menu()
        {
            Console.WriteLine("Выбор запроса:");
            Console.WriteLine("1: Общая стоимость товара определенного производителя");
            Console.WriteLine("2: Все игрушки на складе для возрастов больше определенного");
            Console.WriteLine("3: Количество на складе молочных товаров определенного типа");
            Console.WriteLine("0: Завершение работы программы");
        }

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

            return number;
        }

        static void Part1()
        {
            Goods[] goods = {
                new MilkProduct("Домик в деревне", "Nestle", 50, 150, new DateTime(2020, 02, 20, 8, 0, 0), 48, "молоко", 1.0),
                new Toys("Монополия", "Hasbro", 6, "настольные"),
                new Goods(),
                new Toys("Мягкая ворона", "Мягкие игрушки детям"),
                new FoodProduct("Lipton tea","Pepsi Co."),
                new MilkProduct(),
                new MilkProduct("Кефир", "Нытвенский молзавод")
            };

            Console.WriteLine("Virtual one's:");
            foreach (Goods x in goods)
            {
                x.Show();
            }

            Console.WriteLine("\n\nNon-virtual one's:");
            foreach (Goods good in goods)
            {
                good.NonVirtualShow();
            }
        }

        static void Part2()
        {
            Goods[] goods = CreateArray();

            int userChoise;
            bool finish = false;

            Console.WriteLine("На складе следующие товары:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < goods.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {goods[i]}");
                //Console.WriteLine($"{goods[i].Title} : {goods[i].Manufacturer}");
            }
            Console.ResetColor();
            Console.WriteLine("\n\n");

            do
            {
                Menu();
                userChoise = ReadInteger("Выбор опции:", 0, 3);
                int count = 0;
                switch (userChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите название производителя: ");
                            string manuf = Console.ReadLine();

                            int sum = 0;
                            foreach (Goods good in goods)
                            {
                                if (good.Manufacturer == manuf)
                                {
                                    count++;
                                    sum += good.TotalRevenue();
                                }
                            }

                            if (count > 0)
                                Console.WriteLine($"Общася стоимость товаров, произведенных {manuf} = {sum} за {count} товаров");

                            break;
                        }
                    case 2:
                        {
                            int age = ReadInteger("Введите нижнюю возрастную границу: ", 0, 18);

                            foreach (Goods good in goods)
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

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите интересующий молочный тип товара: ");
                            string type = Console.ReadLine();

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

                            break;
                        }
                    default:
                        {
                            finish = true;
                            break;
                        }
                }

                if (count == 0) Console.WriteLine("По запросу ничего не найдено\n");
            } while (!finish);

        }

        static void Part3()
        {
            IExecutable[] goods = CreateArray();
            IExecutable[] goodsSort = new IExecutable[goods.Length];

            for (int i = 0; i < goods.Length; i++) goodsSort[i] = (Goods)goods[i].Clone();

            foreach (IExecutable good in goods)
            {
                Console.WriteLine($"{good.Title()} : Price = {good.Price()}, Quantity = {good.Quantity()}, TR = {good.TotalRevenue()}");
            }

            Console.WriteLine("\nСортировка #1:");
            Array.Sort(goods);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (IExecutable good in goods)
            {
                Console.WriteLine($"{good.Title()} : Price = {good.Price()}, Quantity = {good.Quantity()}, TR = {good.TotalRevenue()}");
            }


            Array.Sort(goodsSort, new AscendingSortBeyRevenue());
            Console.ResetColor();
            Console.WriteLine("\nСортировка #2:");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (IExecutable good in goodsSort)
            {
                Console.WriteLine($"{good.Title()} : Price = {good.Price()}, Quantity = {good.Quantity()}, TR = {good.TotalRevenue()}");
            }

            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            IExecutable based = new Goods("Образец", "Монополисты");
            IExecutable copied = based;
            IExecutable cloned = (Goods)based.Clone();

            Console.WriteLine($"Базовый: {based.ToString()}");
            Console.WriteLine($"Поверхностное копирование: {copied.ToString()}");
            Console.WriteLine($"Полное копирование: {cloned.ToString()}");

            based.Rename("Новое название");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Базовый: {based.ToString()}");
            Console.WriteLine($"Поверхностное копирование: {copied.ToString()}");
            Console.WriteLine($"Полное копирование: {cloned.ToString()}");
        }

        static void Main(string[] args)
        {
            Part1();
            //Part2();
            //Part3();            
        }
    }
}