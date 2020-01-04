using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Bonus
{
    class Program
    {
        static void InsertionSort(ref int[] arr, int left, int d)
        {
            for (int i = left; i < arr.Length - 1; i += d)
            {
                for (int j = Math.Min(i + d, arr.Length - 1); j - d >= 0; j -= d)
                {
                    if (arr[j - d] > arr[j])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j - d];
                        arr[j - d] = tmp;
                    }
                    else break;
                }
            }
        }

        static int[] GenerateDist(int N)
        {
            int k = 1, t = 1; // k is powers of 2, t is powers of 3
            int[] arr = new int[N];
            int ind = 0;
            int term = N / 2;

            for (; t * k <= term; k *= 2)
            {
                for (; t * k <= term; t *= 3)
                {
                    arr[ind++] = t * k;
                }
                t = 1;
            }

            Array.Resize(ref arr, ind);
            Array.Sort(arr);

            return arr;
        }

        static void ShellSort(ref int[] arr)
        {
            int[] d = GenerateDist(arr.Length);

            for (int k = d.Length - 1; k >= 0; k--)
            {
                int i = d[k];
                for (int j = 0; j < i; j++)
                {
                    InsertionSort(ref arr, j, i);
                }
            }
        }

        static void ArraySort(ref int[] arr)
        {
            //Console.WriteLine("Simple Started");
            int sizeOfArray = arr.Length;
            for (int i = 1; i < sizeOfArray; i++)
            {
                if (i % 20000 == 0) Console.WriteLine(i);
                for (int j = sizeOfArray - 1; j >= i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = tmp;
                    }
                }
            }
        }

        static int[] CreateRandomArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];
            Random rand = new Random();

            for (int i = 0; i < sizeOfArray; i++)
            {
                arr[i] = rand.Next(0, 10 * sizeOfArray);
            }
            return arr;
        }

        static void ArrayPrint(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static bool IsArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] < arr[i]) return false;
            }
            return true;
        }

        static bool isEqual(ref int[] A, ref int[] B)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int N = 10000;
            int[] A = CreateRandomArray(N);
            int[] B = new int[N];

            for (int i = 0; i < N; i++)
            {
                B[i] = A[i];
            }

            Stopwatch timeShell = new Stopwatch();

            timeShell.Start();
            ShellSort(ref B);
            timeShell.Stop();

            Console.WriteLine($"ShellSort Time: {timeShell.Elapsed}");

            Stopwatch timeBasic = new Stopwatch();

            timeBasic.Start();
            ArraySort(ref A);
            timeBasic.Stop();

            Console.WriteLine($"SimpleSwapSort Time: {timeBasic.Elapsed}");

            Console.WriteLine((isEqual(ref A, ref B)) ? "Массивы одинаковы" : "Массивы разные");
            Console.WriteLine((IsArraySorted(A)) ? "Массив А отсортирован" : "Массив A не отсортирован");

        }
    }
}
