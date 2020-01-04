using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Task1()
        {
            double x; int n, m;
            Console.WriteLine("Введите целое число n");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Ошибка: введите целое число!");
            }
            Console.WriteLine("Введите целое число m");
            while (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Ошибка: введите целое число!");
            }
            Console.WriteLine("Введите вещественное число x");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка: введите вещественное число!");
            }

            int res1 = m + --n;
            Console.WriteLine($"n = {n}, m = {m}, m + --n = {res1}");
            bool res2 = m++ < --n;
            Console.WriteLine($"n = {n}, m = {m}, m++<--n = {res2}");
            bool res3 = --m > n--;
            Console.WriteLine($"n = {n}, m = {m}, --m>n-- = {res3}");

            if (x == 0) Console.WriteLine("Ошибка: нельзя вычислить!");
            else
            {
                double res4 = Math.Pow(Math.Pow(x, 3) + Math.Pow(x, 4), 0.2) + 1.0 / Math.Tan(Math.Atan(Math.Pow(x, 2)));
                Console.WriteLine($"x = {x}, (x^3 + x^4)^0.2 + ctg(arctg(x^2)) = {res4}");
            }
        }

        static void Task2()
        {
            double x, y;
            Console.WriteLine("Введите координату x точки");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка: введите вещественное число!");
            }
            Console.WriteLine("Введите координату y точки");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Ошибка: введите вещественное число!");
            }

            bool inArea = (x * x + y * y <= 4) && (y >= -Math.Abs(x) + 2 || y <= Math.Abs(x) - 2);
            Console.WriteLine($"Точка принадлежит = {inArea}");
        }

        #region Task3
        static float floatSolve()
        {
            float a = 10000, b = 0.00001f;

            float exp1 = (float)Math.Pow(a - b, 3);
            float exp2 = (float)Math.Pow(a, 3);
            float exp3 = (float)Math.Pow(b, 3);
            float exp4 = 3 * a * (float)Math.Pow(b, 2);
            float exp5 = 3 * (float)Math.Pow(a, 2) * b;

            float res = (exp1 - exp2) / (-exp3 + exp4 - exp5);

            return res;
        }

        static double doubleSolve()
        {
            double a = 10000, b = 0.00001;

            double exp1 = Math.Pow(a - b, 3);
            double exp2 = Math.Pow(a, 3);
            double exp3 = Math.Pow(b, 3);
            double exp4 = 3 * a * Math.Pow(b, 2);
            double exp5 = 3 * Math.Pow(a, 2) * b;

            double res = (exp1 - exp2) / (-exp3 + exp4 - exp5);
            return res;
        }
        
        static void Task3()
        {
            Console.WriteLine($"Result with double = {doubleSolve()}");
            Console.WriteLine($"Result with float = {floatSolve()}");
        }

        #endregion

        static void Main(string[] args)
        {

            Task1();

            //Task2();

            //Task3();
        }
    }
}
