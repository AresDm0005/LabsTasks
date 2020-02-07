using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        public static void Part1()
        {
            int h1 = int.Parse(Console.ReadLine()), m1 = int.Parse(Console.ReadLine());
            int h2 = int.Parse(Console.ReadLine()), m2 = int.Parse(Console.ReadLine());

            Time t1 = new Time(h1, m1);
            Time t2 = new Time(h2, m2);


            Time t3 = Time.DeductTime(t1, t2);
            Time t4 = t1.DeductTime(t2);

            Console.WriteLine(t3.ToString());
            Console.WriteLine(t4.ToString());
        }

        public static void Part2()
        {
            int h1 = int.Parse(Console.ReadLine()), m1 = int.Parse(Console.ReadLine());
            int h2 = int.Parse(Console.ReadLine()), m2 = int.Parse(Console.ReadLine());

            Time t1 = new Time(h1, m1);
            Time t2 = new Time(h2, m2);

            t1--;
            t2++;

            t1.Show();
            t2.Show();

            Console.WriteLine((bool)t1);
            Console.WriteLine($"{t1 - 10}");

            if (t1 > t2) Console.WriteLine($"{t1.ToString()}  > {t2.ToString()}");
            else Console.WriteLine($"{t2.ToString()}  >= {t1.ToString()}");
        }

        static void Main(string[] args)
        {
            //Part1();
            Part2();

        }
    }
}
