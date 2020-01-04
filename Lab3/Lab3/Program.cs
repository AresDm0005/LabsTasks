using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int X = 10; X <= 100; X += 9)
            {
                double x = X / 100.0; //Для решения проблемы со сложением вещественных чисел
                double Sn = 1, Se = 1, Y = Math.Cos(x); // Sn = a0, Se = a0

                //Для заданного N = 10
                double a = 1;
                for (int n = 1; n <= 10; n++)
                {
                    a *= -(x * x / ((2 * n - 1) * 2 * n));
                    Sn += a;
                }

                double eps = 0.0001, tmp;
                int t = 1;
                a = 1;

                do
                {
                    tmp = Se;
                    a *= -(x * x / ((2 * t - 1) * 2 * t));
                    t++;
                    Se += a;
                } while (Math.Abs(tmp - Se) > eps);

                Console.SetWindowSize(90, 15);
                Console.WriteLine($"X = {x}, SN = {Sn}, SE = {Se}, Y = {Y}");
            }
        }
    }
}
