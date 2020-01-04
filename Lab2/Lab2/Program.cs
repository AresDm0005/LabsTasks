using System;

namespace Lab2
{
    class Program
    {
        //функция ввода целого числа
        static int ReadInteger()
        {
            int num;
            bool done;
            do
            {
                done = int.TryParse(Console.ReadLine(), out num);
                if (!done) Console.WriteLine("Ошибка: введите целое число!");
            } while (!done);

            return num;
        }

        //Task 1 - index of MAX element
        static void Task1()
        {
            int size; // длина последовательности
            bool ok;
            Console.WriteLine("Введите длину последовательности.");

            //Ввод длины последовательности
            do
            {
                size = ReadInteger();
                if (size < 0)
                {
                    ok = false;
                    Console.WriteLine("Ошибка: длина должна быть выражена целым положительным числом или 0. Введите длину заного:");
                }
                else ok = true;
            } while (!ok);

            if (size == 0) Console.WriteLine("Введенная последовательность пуста.");
            else
            {
                Console.WriteLine("Введите элементы последовательности по одному на строчку:");

                int max = ReadInteger(); //значение максимального элемента
                int posMax = 1; //позиция последнего встретившегося макс. элемента
                int maxAmount = 1; //количество элементов равных максимальному

                for (int i = 2; i <= size; i++)
                {
                    int temp = ReadInteger(); //ввод следующего элемента
                    if (temp > max)
                    {
                        posMax = i;
                        max = temp;
                        maxAmount = 1;
                    }
                    else if (temp == max)
                    {
                        maxAmount++;
                        posMax = i;
                    }
                }

                if (maxAmount == 1) Console.WriteLine($"Номер максимального числа в последовательности - {posMax}");
                else Console.WriteLine($"В последовательности встретилось несколько элементов равных максимальному. Номер последнего максимального числа в последовательности - {posMax}");
            }
        }

        //Task 2 - difference btw MIN and MAX elem
        static void Task2()
        {
            Console.WriteLine("Введите элементы последовательности по одному на строчку");
            int temp = ReadInteger(); //следующий элемент
            int min = temp, max = temp; //значение минимального и максимального элементов послед.

            if (temp == 0)
            {
                Console.WriteLine("Введенная последовательность пуста.");
            }
            else
            {
                temp = ReadInteger();
                while (temp != 0)
                {
                    max = Math.Max(max, temp);
                    min = Math.Min(min, temp);
                    temp = ReadInteger();
                }
                Console.WriteLine($"Разность минимального и максимального чисел в последовательности = {min - max}");
            }
        }

        //Task 3 - S = sqrt(3 + sqrt(6 + sqrt(... + sqrt(99))))
        static void Task3()
        {
            int k = 99; //Значение подкоренного выраж. самого вложенного корня
            double res = 0; //значение выражения

            while (k >= 3)
            {
                res = Math.Sqrt(k + res);
                k -= 3;
            }

            Console.WriteLine($"S = {res}");
            // ans = 2.4699257167975133
            // S =   2,4699257167975133
        }


        static void Main(string[] args)
        {

            Task1();

            //Task2();

            //Task3();

        }
    }
}