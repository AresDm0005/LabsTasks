using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsTypes;

namespace Lab12
{
    class Program
    {
        static void ListOne()
        {
            Console.WriteLine("Однонаправленный список:\n");
            OneWayList list = new OneWayList();

            list.AddLast(new Goods("Маски", "Медицинские", 10, 1000));
            list.AddLast(new Goods("Маски", "Медицинские", 120, 900));
            list.AddLast(new Goods("Маски", "Медицинские", 130, 800));
            list.AddLast(new Goods("Маски", "Медицинские", 40, 700));
            list.AddLast(new Goods("Маски", "Медицинские", 150, 600));
            list.AddLast(new Goods("Маски", "Медицинские", 160, 500));
            list.AddLast(new Goods("Маски", "Медицинские", 170, 400));
            list.AddLast(new Goods("Маски", "Медицинские", 180, 300));
            list.AddLast(new Goods("Маски", "Медицинские", 190, 200));
            list.AddLast(new Goods("Маски", "Медицинские", 10, 100));

            list.Show();
            Console.WriteLine("\n");
                        
            list.Task();

            Console.WriteLine($"\n\nЗанимаемая память до удаления: {GC.GetTotalMemory(false)}");
            list.DeleteList();
            Console.WriteLine($"Занимаемая память после удаления: {GC.GetTotalMemory(true)}");
        }

        static void ListTwo()
        {
            Console.WriteLine("Двунаправленный список:\n");
            TwoWayList list = new TwoWayList();

            list.AddLast(new Goods("Маски", "Медицинские", 33, 1000));
            list.AddLast(new Goods("Маски", "Медицинские", 47, 900));
            list.AddLast(new Goods("Маски", "Медицинские", 133, 800));
            list.AddLast(new Goods("Маски", "Медицинские", 95, 700));
            list.AddLast(new Goods("Маски", "Медицинские", 46, 600));
            list.AddLast(new Goods("Маски", "Медицинские", 32, 500));
            list.AddLast(new Goods("Маски", "Медицинские", 19, 400));
            list.AddLast(new Goods("Маски", "Медицинские", 66, 300));
            list.AddLast(new Goods("Маски", "Медицинские", 19, 200));
            list.AddLast(new Goods("Маски", "Медицинские", 31, 100));

            list.ShowBackward();
            Console.WriteLine("\n");

            list.Task();

            Console.WriteLine($"\n\nЗанимаемая память до удаления: {GC.GetTotalMemory(false)}");
            list.DeleteList();
            Console.WriteLine($"Занимаемая память после удаления: {GC.GetTotalMemory(true)}");
        }

        static void Tree()
        {
            BinaryTree tree = new BinaryTree(10);
            tree.Show();
            Console.WriteLine();            
            tree.Task();
            Console.WriteLine();
            tree.TurnSearchTree();
            tree.Show();
            Console.WriteLine();
            tree.ClearMemory();
        }

        static void Part2()
        {
            MyQueue<Goods> goods = new MyQueue<Goods>();
            Console.WriteLine("Создан экземпляр очереди (пустой конструктор), вместимость: goods.Capacity: {0}", goods.Capacity);

            goods.Enqueue(new Goods("Маски", "Подводные", 1000, 200));
            goods.Enqueue(new Goods("Маски", "Медицинские", 10, 50000));
            goods.Enqueue(new Goods("Маски", "Карнавальные", 50, 6000));
            goods.Enqueue(new Goods("Маски", "Рисованые", 30, 400));

            Console.WriteLine("Добавлены 4 элемента, вместимость: goods.Capacity: {0}\n", goods.Capacity);
            Console.WriteLine("Вывод с помощью foreach:");
            foreach(Goods good in goods)
            {
                Console.WriteLine(good);
            }

            bool ok1, ok2;
            ok1 = goods.Contains(new Goods("Маски", "Карнавальные", 50, 6000));
            ok2 = goods.Contains(new Goods("Маски", "Тканевые", 100, 9000));
                        
            Console.WriteLine("Существующий элемент: {0}", ok1?"Найден":"Не найден");
            Console.WriteLine("Не существующий элемент: {0}\n", ok2 ? "Найден" : "Не найден");
            
            Console.WriteLine("\nCloning:");
            MyQueue<Goods> clone = (MyQueue<Goods>)goods.Clone();

            goods.Dequeue();
            goods.Dequeue();

            Console.WriteLine("Goods dequeue x2; clone none:  .Peek:");
            Console.WriteLine("goods: {0}", goods.Peek());
            Console.WriteLine("clone: {0}\n", clone.Peek());


            Console.WriteLine("Dequeue on clone:");
            while (clone.Count > 0)
            {
                Goods item = clone.Dequeue();
                Console.WriteLine($"Dequeue: {item.Manufacturer} = {item.TotalRevenue()} руб.");
            }

            Console.WriteLine("\nMemory usage before clean: {0}", GC.GetTotalMemory(false));
            goods.Clean();
            clone.Clean();
            Console.WriteLine("\nMemory usage after clean: {0}", GC.GetTotalMemory(false));
        }

        static void Menu()
        {
            Console.WriteLine("\n\nЗадания:");
            Console.WriteLine("1: Задания по однонаправленному списку");
            Console.WriteLine("2: Задания по двунаправленному списку");
            Console.WriteLine("3: Задания по дереву");
            Console.WriteLine("4: Задания по MyQueue");
            Console.WriteLine("0: Завершить работу");
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

        static void Main(string[] args)
        {
            Console.SetWindowSize(200, 50);
            bool finish = false;
            do
            {                
                Menu();
                int userChoise = ReadInteger("Выбранная опция: ", 0, 4);
                Console.Clear();
                switch (userChoise)
                {
                    case 1:
                        {
                            ListOne();
                            break;
                        }
                    case 2:
                        {
                            ListTwo();
                            break;
                        }
                    case 3:
                        {
                            Tree();
                            break;
                        }
                    case 4:
                        {
                            Part2();
                            break;
                        }
                    default:
                        {
                            finish = true;
                            break;
                        }
                }
            } while (!finish);
        }
    }
}
