using System;

namespace Laba5
{
    class Program
    {
        const int MAX_ELEM = 10000;
        const int MIN_ELEM = -10000;

        const int MAX_LENGTH = 1000; // Максимальное кол-во элементов в одномерном массиве/строке двумерного или рваного массивов
        const int MAX_DEPTH = 25; // Максимальное кол-во строк в двумерном или рваном массиве
        const int MIN_SIZE = 1;

        static int ReadInteger(string userInstruction, int lowerBound = MIN_ELEM, int upperBound = MAX_ELEM)
        {
            int num = 0;
            bool ok = false;
            string input;
            do
            {
                try
                {
                    Console.Write(userInstruction);
                    input = Console.ReadLine();
                    num = Convert.ToInt32(input);
                    if (num >= lowerBound && num <= upperBound) ok = true;
                    else Console.WriteLine("Ошибка: введенное число должно попадать в промежуток от {0} до {1}", lowerBound, upperBound);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: введено слишком большое (или маленькое) число");
                }
            } while (!ok);
            return num;
        }

        static void PrintArray(int[] arr, string message = "Сформированный одномерный массив:")
        {
            Console.WriteLine();
            if (arr.Length == 0) Console.WriteLine("Массив пустой");
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintArray(int[,] arr, string message = "Сформированный двумерный массив:")
        {
            Console.WriteLine();
            if (arr.GetLength(0) == 0) Console.WriteLine("Массив пустой");
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void PrintArray(int[][] arr, string message = "Сформированный рваный массив:")
        {
            Console.WriteLine();
            if (arr.GetLength(0) == 0) Console.WriteLine("Массив пустой");
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write(arr[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int RedefineOption(int userChoise, bool arr, bool mat, bool jag)
        {
            if ((userChoise >= 0 && userChoise <= 3) || (arr && mat && jag)) return userChoise;
            bool[] flags = { arr, mat, jag };

            if (userChoise == 4)
            {
                for (int i = 0; i < 3 && !flags[i]; i++)
                {
                    userChoise++;
                }

            }
            else if (userChoise == 5)
            {
                if (flags[0] == false) userChoise++;
                else if (flags[1] == false) userChoise++;
            }
            return userChoise;
        }

        #region Array
        static int[] CreateRandomArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];

            Random rand = new Random();
            for (int i = 0; i < sizeOfArray; i++) arr[i] = rand.Next(MIN_ELEM, MAX_ELEM);

            return arr;
        }

        static int[] ReadArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++)
                arr[i] = ReadInteger($"Введите {i + 1} элемент: ");

            return arr;
        }

        static int[] ArrayDeleteEven(int[] arr)
        {
            int sizeArr = arr.Length;
            int sizeNew = 0;
            for (int i = 0; i < sizeArr; i++)
            {
                if (arr[i] % 2 != 0) sizeNew++;
            }

            int[] newArr = new int[sizeNew];
            int newInd = 0;
            for (int i = 0; i < sizeArr; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    newArr[newInd] = arr[i];
                    newInd++;
                }
            }
            if (sizeNew == sizeArr) Console.WriteLine("\nВ массиве нет четных элементов для удаления!");
            else PrintArray(newArr, "После удаления четных элементов массив выглядит так:");
            return newArr;
        }

        #endregion

        #region Matrix
        static int[,] CreateRandomMatrix(int row, int column)
        {
            int[,] matr = new int[row, column];
            Random rand = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matr[i, j] = rand.Next(MIN_ELEM, MAX_ELEM);
                }
            }

            return matr;
        }

        static int[,] ReadMatrix(int row, int column)
        {
            int[,] matr = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matr[i, j] = ReadInteger($"Введите {j + 1} элемент {i + 1} строки: ");
                }
            }

            return matr;
        }

        static int[,] MatrixAddRows(int[,] matr, int k)
        {
            int row = matr.GetLength(0);
            int col = matr.GetLength(1);
            int[,] newMatr = new int[row + k, col];

            Console.WriteLine("Выберите вариант формирования:");
            Console.WriteLine("    1: Сформировать с помощью ДСЧ");
            Console.WriteLine("    2: Сформировать вручную, с клавиатуры");
            int userChoise = ReadInteger("Введите номер выбранной опции: ", 1, 2);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    newMatr[i, j] = matr[i, j];
                }
            }

            int[,] addMatr;
            if (userChoise == 1) addMatr = CreateRandomMatrix(k, col);
            else addMatr = ReadMatrix(k, col);

            for (int i = row; i < row + k; i++)
            {
                int t = i - row;
                for (int j = 0; j < col; j++)
                {
                    newMatr[i, j] = addMatr[t, j];
                }
            }

            PrintArray(newMatr, "После добавления строк массив стал таким: ");
            return newMatr;
        }

        #endregion

        #region Jagged
        static int[][] CreateRandomJagged(int row)
        {
            int[][] jag = new int[row][];
            Random rand = new Random();


            for (int i = 0; i < row; i++)
            {
                int size = ReadInteger($"Введите длину {i + 1} строки: ", MIN_SIZE, MAX_LENGTH);
                jag[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    jag[i][j] = rand.Next(MIN_ELEM, MAX_ELEM);
                }
            }
            int fl = rand.Next(1, 4);
            if (fl != 3)
            {
                int i = rand.Next(0, row);
                int j = rand.Next(0, jag[i].GetLength(0));
                jag[i][j] = 0;
            }

            return jag;
        }

        static int[][] ReadJagged(int row)
        {
            int[][] jag = new int[row][];

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine();
                int size = ReadInteger($"Введите длину {i + 1} строки: ", MIN_SIZE, MAX_LENGTH);
                jag[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    jag[i][j] = ReadInteger($"Введите {j + 1} элемент строки: ");
                }
            }

            return jag;
        }

        static bool JaggedFirstRowWithZero(ref int[][] jag, ref int rowDel)
        {
            bool find = false;
            int row = jag.GetLength(0);
            for (int i = 0; i < row && !find; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    if (jag[i][j] == 0)
                    {
                        find = true;
                        rowDel = i;
                    }
                }
            }

            return find;
        }

        static int[][] JaggedDeleteZeroRow(int[][] jag)
        {
            int rowDel = -1;
            int row = jag.GetLength(0);

            bool find = JaggedFirstRowWithZero(ref jag, ref rowDel);

            if (!find)
            {
                Console.WriteLine("В массиве отсутствуют нули! Ничего не было удалено!");
                return jag;
            }
            else
            {
                int[][] jag1 = new int[row - 1][];
                for (int i = 0; i < rowDel; i++)
                {
                    jag1[i] = new int[jag[i].Length];
                    for (int j = 0; j < jag[i].Length; j++)
                    {
                        jag1[i][j] = jag[i][j];
                    }
                }

                for (int i = rowDel + 1; i < row; i++)
                {
                    jag1[i - 1] = new int[jag[i].Length];
                    for (int j = 0; j < jag[i].Length; j++)
                    {
                        jag1[i - 1][j] = jag[i][j];
                    }
                }

                PrintArray(jag1, "После удаления строк массив имеет такой вид:");
                return jag1;
            }
        }

        #endregion

        #region inteface
        static void CreateNewArray(string instruction, out int[] arr)
        {
            Console.WriteLine(instruction);
            int sizeOfArray = ReadInteger("Введите размер массива: ", MIN_SIZE, MAX_LENGTH);

            Console.WriteLine("Выберите вариант формирования:");
            Console.WriteLine("    1: Сформировать с помощью ДСЧ");
            Console.WriteLine("    2: Сформировать вручную, с клавиатуры");

            int userChoise = ReadInteger("Введите номер выбранной опции: ", 1, 2);
            arr = new int[sizeOfArray];

            Console.WriteLine();
            if (userChoise == 1) arr = CreateRandomArray(sizeOfArray);
            else arr = ReadArray(sizeOfArray);

            PrintArray(arr);
        }

        static void CreateNewArray(string instruction, out int[,] matr)
        {
            Console.WriteLine(instruction);
            int row = ReadInteger("Введите количество строк в матрице: ", MIN_SIZE, MAX_DEPTH);
            int column = ReadInteger("Введите количество столбцов: ", MIN_SIZE, MAX_LENGTH);

            Console.WriteLine("Выберите вариант формирования:");
            Console.WriteLine("    1: Сформировать с помощью ДСЧ");
            Console.WriteLine("    2: Сформировать вручную, с клавиатуры");

            Console.WriteLine();
            int userChoise = ReadInteger("Введите номер выбранной опции: ", 1, 2);
            matr = new int[row, column];

            if (userChoise == 1) matr = CreateRandomMatrix(row, column);
            else matr = ReadMatrix(row, column);

            PrintArray(matr);
        }

        static void CreateNewArray(string instruction, out int[][] jag)
        {
            Console.WriteLine(instruction);
            int row = ReadInteger("Введите количество строк в массиве: ", MIN_SIZE, MAX_DEPTH);

            Console.WriteLine("Выберите вариант формирования:");
            Console.WriteLine("    1: Сформировать с помощью ДСЧ");
            Console.WriteLine("    2: Сформировать вручную, с клавиатуры");

            Console.WriteLine();
            int userChoise = ReadInteger("Введите номер выбранной опции: ", 1, 2);

            jag = new int[row][];

            if (userChoise == 1) jag = CreateRandomJagged(row);
            else jag = ReadJagged(row);

            PrintArray(jag);
        }

        static void MainMenu(bool arr, bool mat, bool jag)
        {
            string word = (arr || mat || jag) ? "новый " : "";
            Console.WriteLine("\nДоступные опции:");
            Console.WriteLine($"    1: Сформировать {word}одномерный массив");
            Console.WriteLine($"    2: Сформировать {word}двумерный массив");
            Console.WriteLine($"    3: Сформировать {word}рваный массив");
            int ind = 4;
            if (arr)
            {
                Console.WriteLine($"    {ind++}: Удалить все четные элементы в одномерном массиве");
            }
            if (mat)
            {
                Console.WriteLine($"    {ind++}: Добавить строки в конец матрицы");
            }
            if (jag)
            {
                Console.WriteLine($"    {ind++}: Удалить первую строку в рваном массиве, содержащую нули");
            }
            Console.WriteLine("    0: Завершить работу программы");
        }

        static void Initial(out int[] arr, out int[,] matr, out int[][] jag, ref bool[] flags)
        {
            Console.WriteLine("Программа работает с одномерными, двумерными и рваными массивами");
            Console.WriteLine("Для начала сформируем массив:");
            MainMenu(flags[1], flags[2], flags[3]);
            int userChoise = ReadInteger("Введите номер выбранной опции: ", 0, 3);

            arr = null;
            matr = null;
            jag = null;

            switch (userChoise)
            {
                case 1:
                    CreateNewArray("", out arr);
                    break;
                case 2:
                    CreateNewArray("", out matr);
                    break;
                case 3:
                    CreateNewArray("", out jag);
                    break;
            }
            flags[userChoise] = true;
        }

        static void EmptyArraySituation(string cause, out int[] arr, ref bool arrF, ref bool finish)
        {
            Console.WriteLine($"После {cause} одномерный массив стал пустым");
            Console.WriteLine("Выберите вариант продолжения работы:");
            Console.WriteLine("    1: Сформировать новый одномерный массив");
            Console.WriteLine("    2: Продолжить работу с другими типами массивов");
            Console.WriteLine("    0: Прекратить работу программы");

            arr = null;

            int userChoise = ReadInteger("Введите номер выбранной опции: ", 0, 2);
            if (userChoise == 1)
            {
                CreateNewArray("Формирование нового одномерного массива:", out arr);
                arrF = true;
                finish = false;
            }
            else if (userChoise == 2)
            {
                arrF = false;
                finish = false;
            }
            else
            {
                finish = true;
            }
        }

        static void EmptyArraySituation(string cause, out int[][] jag, ref bool jagF, ref bool finish)
        {
            Console.WriteLine($"После {cause} рваный массив стал пустым");
            Console.WriteLine("Выберите вариант продолжения работы:");
            Console.WriteLine("    1: Сформировать новый одномерный массив");
            Console.WriteLine("    2: Продолжить работу с другими типами массивов");
            Console.WriteLine("    0: Прекратить работу программы");

            jag = null;

            int userChoise = ReadInteger("Введите номер выбранной опции: ", 0, 2);
            if (userChoise == 1)
            {
                CreateNewArray("Формирование нового рваного массива:", out jag);
                jagF = true;
                finish = false;
            }
            else if (userChoise == 2)
            {
                jagF = false;
                finish = false;
            }
            else
            {
                finish = true;
            }
        }

        #endregion

        static void Main(string[] args)
        {
            bool[] flags = { false, false, false, false };
            int[] arr;
            int[,] matr;
            int[][] jag;

            Initial(out arr, out matr, out jag, ref flags);

            bool arrF = flags[1], matF = flags[2], jagF = flags[3];
            int options = 4;

            bool finish = flags[0];
            do
            {
                MainMenu(arrF, matF, jagF);
                int userChoise = ReadInteger("Введите номер выбранной опции: ", 0, options);
                Console.WriteLine();
                userChoise = RedefineOption(userChoise, arrF, matF, jagF);
                switch (userChoise)
                {
                    case 0:
                        {
                            finish = true;
                            Console.WriteLine("Завершаю работу");
                            break;
                        }

                    case 1:
                        {
                            if (arrF) CreateNewArray("Формирование нового одномерного массива:", out arr);
                            else
                            {
                                CreateNewArray("Формирование одномерного массива", out arr);
                                options++;
                                arrF = true;
                            }
                            break;
                        }

                    case 2:
                        {
                            if (matF) CreateNewArray("Формирование нового двумерного массива:", out matr);
                            else
                            {
                                CreateNewArray("Формирование двумерного массива:", out matr);
                                options++;
                                matF = true;
                            }
                            break;
                        }

                    case 3:
                        {
                            if (jagF) CreateNewArray("Формирование нового рваного массива:", out jag);
                            else
                            {
                                CreateNewArray("Формирование рваного массива:", out jag);
                                options++;
                                jagF = true;
                            }
                            break;
                        }

                    case 4:
                        {
                            arr = ArrayDeleteEven(arr);
                            if (arr.Length == 0)
                            {
                                EmptyArraySituation("удаления четных элементов массива", out arr, ref arrF, ref finish);
                                if (!arrF) options--;
                            }
                            break;
                        }

                    case 5:
                        {
                            int pos = ReadInteger("Сколько строк нужно добавить: ", 1, MAX_DEPTH - matr.GetLength(0));
                            matr = MatrixAddRows(matr, pos);
                            break;
                        }

                    case 6:
                        {
                            jag = JaggedDeleteZeroRow(jag);
                            if (jag.GetLength(0) == 0)
                            {
                                EmptyArraySituation("после удаления рядов с одним или более нулями", out jag, ref jagF, ref finish);
                                if (!jagF) options--;
                            }
                            break;
                        }
                }
            } while (!finish);
        }
    }
}