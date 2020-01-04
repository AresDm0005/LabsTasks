using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        const double MIN_ELEM = 0.0;
        const double MAX_ELEM = 1000.0;
        const int MIN_SIZE = 1;
        const int MAX_SIZE = 1000;

        static string[] RND_WORDS = { "Я", "памятник", "себе", "воздвиг", "нерукотворный", "Вознесся", "выше", "он", "главою", "непокорной",
                                "Александрийского", "столпа", "Жив", "будет", "хоть", "один", "пиит", "Веленью", "божию", "муза", "будь", "послушна", "Обиды" };
        static char[] PUNCT = { '.', ',', '!', '?', ':', ';' };
        static string DIVIDER = "\n------------------------------------------------------------\n";

        #region Task1
        static double ReadDouble(string userInstruction, double lowerBound = MIN_ELEM, double upperBound = MAX_ELEM)
        {
            double number = 0;
            bool ok = false;
            do
            {
                try
                {
                    Console.Write(userInstruction);
                    string input = Console.ReadLine();
                    number = Convert.ToDouble(input);

                    if (number >= lowerBound && number <= upperBound) ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка: Введенное число должно попадать в промежуток от {0} до {1}", lowerBound, upperBound);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите вещественное число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: Вещественное число такого порядка не поддерживается!");
                }
            } while (!ok);

            return number;
        }

        static double[] CreateRandomArray(int sizeOfArray)
        {
            double[] arr = new double[sizeOfArray];
            Random random = new Random();

            for (int i = 0; i < sizeOfArray; i++)
            {
                string txt = String.Format("{0:f2}", random.NextDouble() * MAX_ELEM);
                arr[i] = double.Parse(txt);
            }

            return arr;
        }

        static double[] ReadArray(int sizeOfArray)
        {
            double[] arr = new double[sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++)
                arr[i] = ReadDouble($"Введите {i + 1} элемент: ", 0.0, 1000.0);

            return arr;
        }

        static double ArrayFindMin(double[] arr)
        {
            double min = arr[0];

            for (int i = 1; i < arr.Length; i++) if (arr[i] < min) min = arr[i];

            return min;
        }

        static int ArraySizeOfNonMinMultiplyElem(double[] arr, double min)
        {
            int k = 0;

            for (int i = 0; i < arr.Length; i++) if (arr[i] % min != 0) k++;

            return k;
        }

        static double[] ArrayDeleteMinMultiply(double[] arr)
        {
            double min = ArrayFindMin(arr);
            int newSize = ArraySizeOfNonMinMultiplyElem(arr, min);
            double[] newArr = new double[newSize];
            int sizeOfArray = arr.Length;
            int index = 0;

            for (int i = 0; i < sizeOfArray; i++)
            {
                if (arr[i] % min != 0) newArr[index++] = arr[i];
            }

            return newArr;
        }

        #endregion

        #region Task2
        static string LeftShift(string str, int k)
        {
            char[] txt = str.ToCharArray();

            for (int times = 0; times < k; times++)
            {
                char tmp = txt[0];
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    txt[i] = txt[i + 1];
                }
                txt[txt.Length - 1] = tmp;
            }

            return (new string(txt));
        }

        static string[] ChangeWords(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] = LeftShift(arr[i], i + 1);
            return arr;
        }

        static string GetChangedText(string txt)
        {
            string[] words = GetWordsFromText(txt);
            words = ChangeWords(words);

            string newTxt = "";
            int len = 0;

            int i = 0;
            while (i < words.Length)
            {
                newTxt += words[i];
                len += words[i].Length;


                if (i == words.Length - 1)
                {
                    while (len < txt.Length)
                    {
                        if (txt[len] != ' ') newTxt += txt[len];
                        len++;
                    }
                }
                else
                {
                    // Нужно проверить не пришли ли мы к началу след.слова
                    // Для этого нужно найти индекс изначальной первой буквы слова в изменном слове
                    // Его можно найти по формуле: (Len - (i+1) % Len) % Len
                    // Где i - индекс след. слова, Len - его длина
                    while (txt[len] != words[i + 1][(words[i + 1].Length - (i + 2) % words[i + 1].Length) % words[i + 1].Length])
                    {
                        if (txt[len] != ' ') newTxt += txt[len];
                        len++;
                    }
                    newTxt += ' ';
                }
                i++;
            }

            return newTxt;
        }

        static string[] GetWordsFromText(string txt)
        {
            char[] sep = { ' ', '.', '!', '?', '-', ',', ':', ';' };

            string[] words = txt.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        static string GetText(string userInstruction)
        {
            string buf;
            do
            {
                Console.Write(userInstruction);
                buf = Console.ReadLine();
                if (buf.Length == 0) Console.WriteLine("Введите непустую строку!");
            } while (buf.Length == 0);

            return buf;
        }

        static string CreateNewText(int size)
        {
            int wLen = RND_WORDS.Length;
            int pLen = PUNCT.Length;

            int[] used = new int[wLen];

            Random rand = new Random();

            string txt = "";
            for (int i = 0; i < size; i++)
            {
                int pos;
                bool ok = false;
                do
                {
                    pos = rand.Next(0, wLen);
                    if (used[pos] < 2) ok = true;
                } while (!ok);

                used[pos]++;
                txt += RND_WORDS[pos];

                int prob = rand.Next(0, 21);
                if (prob >= 10 && prob <= 12)
                {
                    pos = rand.Next(0, pLen);
                    txt += PUNCT[pos];
                }

                txt += ' ';
            }
            return txt;
        }

        #endregion

        #region interface

        static int ReadInteger(string userInstruction, int lowerBound = MIN_SIZE, int upperBound = MAX_SIZE)
        {
            int number = 0;
            bool ok = false;

            do
            {
                try
                {
                    Console.Write(userInstruction);
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);

                    if (number >= lowerBound && number <= upperBound) ok = true;
                    else Console.WriteLine("Ошибка: введенное число должно попадать в промежуток от {0} до {1}", lowerBound, upperBound);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: введенное число не поддерживается!");
                }

            } while (!ok);

            return number;
        }

        static bool EmptyArraySituation(ref double[] arr, ref bool finishStage)
        {
            Console.WriteLine("После удаление всех кратных элементов массив стал пустым, выберите что делать дальше:");
            Console.WriteLine("    1: Сформировать новый массив с помощью ДСЧ");
            Console.WriteLine("    2: Сформировать новый массив с клавиатуры");
            Console.WriteLine("    0: Продолжить работу без нового массива и вернуться в основное меню");


            int userChoise = ReadInteger("Введите выбранную опцию: ", 0, 2);

            Console.WriteLine(DIVIDER);
            switch (userChoise)
            {
                case 1:
                    {
                        int size = ReadInteger("Введите размер массива: ");
                        arr = CreateRandomArray(size);
                        return true;
                    }
                case 2:
                    {
                        int size = ReadInteger("Введите размер массива: ");
                        arr = ReadArray(size);
                        return true;
                    }
                default:
                    {
                        finishStage = true;
                        return false;
                    }
            }
        }

        static void Task1Menu(bool arr)
        {
            Console.WriteLine("Доступные опции:");
            Console.WriteLine($"    1: Сформировать массив с помощью ДСЧ");
            Console.WriteLine($"    2: Сформировать массив с клавиатуры");
            if (arr) Console.WriteLine($"    3: Удалить элементы, кратные минимальному");
            Console.WriteLine($"    0: Вернуться в прошлое меню");
        }

        static void Task2Menu(bool str)
        {
            Console.WriteLine("Доступные опции:");
            Console.WriteLine($"    1: Сформировать текст из стандратного набора слов");
            Console.WriteLine($"    2: Ввести текст с клавиатуры");
            if (str) Console.WriteLine($"    3: Сдвинуть циклически каждое слово в тексте влево");
            Console.WriteLine($"    0: Вернуться в прошлое меню");
        }

        static void MainMenu()
        {
            Console.WriteLine("Доступные опции:");
            Console.WriteLine($"    1: Работать с одномерным массивом");
            Console.WriteLine($"    2: Работать со строкой");
            Console.WriteLine($"    0: Завершить выполнение программы");
        }

        static void ArrayPrint(double[] arr)
        {
            Console.WriteLine("\nТекущий массив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void ArrayHandler(ref double[] arr, ref bool arrFlag, ref bool finish)
        {
            int userChoise;
            bool finishStage = false;
            do
            {
                Console.WriteLine(DIVIDER);
                Task1Menu(arrFlag);
                userChoise = ReadInteger("Введите выбранную опцию: ", 0, arrFlag ? 3 : 2);

                switch (userChoise)
                {
                    case 0:
                        {
                            Console.WriteLine(DIVIDER);
                            finishStage = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine(DIVIDER);
                            int size = ReadInteger("Введите размер массива: ");
                            arr = CreateRandomArray(size);
                            arrFlag = true;
                            ArrayPrint(arr);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(DIVIDER);
                            int size = ReadInteger("Введите размер массива: ");
                            arr = ReadArray(size);
                            arrFlag = true;
                            ArrayPrint(arr);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(DIVIDER);
                            arr = ArrayDeleteMinMultiply(arr);
                            if (arr.Length == 0)
                            {
                                arrFlag = EmptyArraySituation(ref arr, ref finishStage);
                            }

                            ArrayPrint(arr);
                            break;
                        }
                }
            } while (!finishStage);
        }

        static void StringHandler(ref string txt, ref bool txtFlag, ref bool finish)
        {
            bool finishStage = false;
            do
            {
                Console.WriteLine(DIVIDER);
                Task2Menu(txtFlag);
                int userChoise = ReadInteger("Введите выбранную опцию: ", 0, txtFlag ? 3 : 2);

                switch (userChoise)
                {
                    case 0:
                        {
                            Console.WriteLine(DIVIDER);
                            finishStage = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine(DIVIDER);
                            int size = ReadInteger("Введите количество слов, которые нужно использовать: ", 1, RND_WORDS.Length * 2 - 1);
                            txt = CreateNewText(size);
                            txtFlag = true;
                            Console.WriteLine($"Текущая строка:\n{txt}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(DIVIDER);
                            txt = GetText("Введите текст: ");
                            txtFlag = true;
                            Console.WriteLine($"Текущая строка:\n{txt}");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(DIVIDER);
                            txt = GetChangedText(txt);
                            Console.WriteLine($"Текущая строка:\n{txt}");
                            break;
                        }

                }
            } while (!finishStage);
        }

        #endregion

        static void Main(string[] args)
        {
            double[] arr = null;
            string txt = null;
            bool arrFlag = false, txtFlag = false;
            int userChoise;

            bool finish = false;
            do
            {
                MainMenu();
                userChoise = ReadInteger("Введите выбранную опцию: ", 0, 2);

                if (userChoise == 1) ArrayHandler(ref arr, ref arrFlag, ref finish);
                else if (userChoise == 2) StringHandler(ref txt, ref txtFlag, ref finish);
                else finish = true;

            } while (!finish);
        }
    }
}