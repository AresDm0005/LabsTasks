using System;

namespace Labs
{
    class Program
    {
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

        static int[] ReadArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++) arr[i] = ReadInteger($"Введите значение {i + 1} элемента: ", -10000, 10000);

            return arr;
        }

        static int[] CreateRandomArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];

            Random rand = new Random();
            for (int i = 0; i < sizeOfArray; i++) arr[i] = rand.Next(20000) - 10000;

            return arr;
        }

        static int[] CreateNewArray(string userInstruction)
        {
            Console.WriteLine(userInstruction);

            int sizeOfArray = ReadInteger("Введите размер массива: ", 1, 1000);

            Console.WriteLine("Выберите как должен быть сформирован массив:");
            Console.WriteLine("   1: Датчиком случайных чисел");
            Console.WriteLine("   2: Ввод с клавиатуры");

            int userChoise = ReadInteger("Нужная опция: ", 1, 2);

            int[] arr = null;
            switch (userChoise)
            {
                case 1:
                    {
                        arr = CreateRandomArray(sizeOfArray);
                        break;
                    }
                case 2:
                    {
                        arr = ReadArray(sizeOfArray);
                        break;
                    }
            }

            return arr;
        }

        static bool EmptyArraySituation(string cause, out int[] arr)
        {
            Console.WriteLine($"После {cause} массив стал пустым");
            Console.WriteLine("Выберите вариант продолжения работы:");
            Console.WriteLine("1: Сформировать новый массив");
            Console.WriteLine("0: Прекратить работу программы");

            bool ok = false;
            arr = null;
            int userChoise = ReadInteger("Ваш выбор: ", 0, 1);
            if (userChoise == 1)
            {
                arr = CreateNewArray("Формирование нового массива:");
                ok = true;
            }

            return !ok;
        }

        static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Меню доступных опций:");
            Console.WriteLine("   1: Сформировать новый массив");
            Console.WriteLine("   2: Напечатать массив");
            Console.WriteLine("   3: Удалить все нечетные элементы");
            Console.WriteLine("   4: Добавить новые элементы в массив");
            Console.WriteLine("   5: Переставить положительные элементы в начало, отрицательные - в конец");
            Console.WriteLine("   6: Выполнить поиск элемента в несортированном массиве");
            Console.WriteLine("   7: Отсортировать массив по возрастанию");
            Console.WriteLine("   8: Выполнить поиск элемента в отсортированном массиве");
            Console.WriteLine("   0: Прекратить работу программы");
        }

        static void ArrayPrintUser(int[] arr)
        {
            Console.WriteLine("Печать массива:");
            int sizeOfArray = arr.Length;
            Console.WriteLine($"Размер массива : {sizeOfArray}");
            Console.Write("Элементы массива: ");
            for (int i = 0; i < sizeOfArray; i++) Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        static void ArrayPrintFunc(int[] arr)
        {
            if (arr.Length == 0) Console.WriteLine("Пустой массив");
            for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static int[] ArrayRemoveOddElements(int[] arr)
        {
            Console.WriteLine("Удаление нечетных элементов:");

            int sizeOfArray = arr.Length;
            int sizeNewArray = 0;
            for (int i = 0; i < sizeOfArray; i++) if (arr[i] % 2 == 0) sizeNewArray++;
            int[] newArr = new int[sizeNewArray];
            int deleted = sizeOfArray - sizeNewArray;
            int k = 0;
            for (int i = 0; i < sizeOfArray && sizeNewArray > 0; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    newArr[k] = arr[i];
                    k++;
                    sizeNewArray--;
                }
            }
            if (deleted != 0) Console.WriteLine($"Было удалено элементов: {deleted}");
            else Console.WriteLine("Ни один элемент не был удален");
            ArrayPrintFunc(newArr);
            return newArr;
        }

        static int[] ArrayAddNewElements(int[] arr, int pos)
        {
            Console.WriteLine("Добавление элементов:");
            int[] addElem = CreateNewArray("Сформируем массив добавляемых элементов:");

            int sizeNewArray = arr.Length + addElem.Length;
            int[] newArr = new int[sizeNewArray];
            int arrInd = 0;
            int addInd = 0;
            for (int i = 0; i < pos; i++, arrInd++) newArr[i] = arr[i];
            for (int i = pos; i < pos + addElem.Length; i++, addInd++) newArr[i] = addElem[addInd];
            for (int i = pos + addElem.Length; i < sizeNewArray; i++, arrInd++) newArr[i] = arr[arrInd];
            ArrayPrintFunc(newArr);
            return newArr;
        }

        static void ArrayPosNegShuffle(ref int[] arr)
        {
            Console.WriteLine("Перестановка элементов");
            int[] addArr = new int[arr.Length];
            int posI = 0, negI = arr.Length - 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    addArr[negI] = arr[i];
                    negI--;
                }
                else
                {
                    addArr[posI] = arr[i];
                    posI++;
                }
            }

            arr = addArr;
            ArrayPrintFunc(arr);
        }

        static bool ArraySearchNoSort(int[] arr, int key, out int pos, out int it)
        {
            Console.WriteLine("Поиск элемента в несортированном массиве:");
            bool find = false;
            pos = -1; it = 0;
            for (int i = 0; i < arr.Length && !find; i++)
            {
                if (arr[i] == key)
                {
                    find = true;
                    pos = i + 1;
                }
                it++;
            }
            ArrayPrintFunc(arr);
            return find;
        }

        static void ArraySort(ref int[] arr)
        {
            Console.WriteLine("Сортировка массива");
            int sizeOfArray = arr.Length;
            for (int i = 1; i < sizeOfArray; i++)
            {
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
            ArrayPrintFunc(arr);
        }

        static bool IsArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] < arr[i]) return false;
            }
            return true;
        }

        static bool BinarySearch(int[] arr, int key, out int pos, out int it)
        {
            Console.WriteLine("Поиск в сортированном массиве");
            int left = 0, right = arr.Length - 1, mid;
            it = 0; pos = -1;
            do
            {
                mid = (left + right) / 2;
                if (arr[mid] < key) left = mid + 1;
                else right = mid;
                it++;
            } while (left != right);


            ArrayPrintFunc(arr);
            if (arr[left] == key)
            {
                pos = left + 1;
                return true;
            }
            else return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с массивом размером до 1000 и элементами не превышающими по модулю 10000");

            int[] arr = CreateNewArray("Для начала сформируем массив:");
            int sizeOfArray = arr.Length;
            bool finish = false;

            do
            {
                MainMenu();
                int userChoise = ReadInteger("Выбранная опция: ", 0, 8);
                Console.WriteLine();

                switch (userChoise)
                {
                    case 0:
                        {
                            Console.WriteLine("Завершаю работу");
                            finish = true;
                            break;
                        }
                    case 1:
                        {
                            arr = CreateNewArray("Формирование нового массива:");
                            break;
                        }
                    case 2:
                        {
                            ArrayPrintUser(arr);
                            break;
                        }
                    case 3:
                        {
                            arr = ArrayRemoveOddElements(arr);
                            if (arr.Length == 0)
                            {
                                finish = EmptyArraySituation("удаления нечетных элементов", out arr);
                            }
                            break;
                        }
                    case 4:
                        {
                            int addPos = ReadInteger("Введите позицию с которой нужно добавить новые элементы: ", 1, sizeOfArray + 1);
                            arr = ArrayAddNewElements(arr, addPos - 1); //Позицию уменьшаем на 1, тк пользователь считает от 1
                            break;
                        }
                    case 5:
                        {
                            ArrayPosNegShuffle(ref arr);
                            break;
                        }
                    case 6:
                        {
                            int key = ReadInteger("Введите искомый элемент: ", -10000, 10000);
                            int posOfKey, iterNum;
                            bool find = ArraySearchNoSort(arr, key, out posOfKey, out iterNum);
                            if (find)
                            {
                                Console.WriteLine($"Искомый элемент находится в массиве на позиции: {posOfKey}");
                                Console.WriteLine($"Для нахождения потребовалось итераций: {iterNum}");
                            }
                            else Console.WriteLine("Искомый элемент не найден");
                            break;
                        }
                    case 7:
                        {
                            if (IsArraySorted(arr)) Console.WriteLine("Массив уже отсортирован");
                            else ArraySort(ref arr);
                            break;
                        }
                    case 8:
                        {
                            bool ok = IsArraySorted(arr);

                            if (!ok)
                            {
                                Console.WriteLine("Поиск невозможен, так как массив не отсортирован");
                                Console.WriteLine("Отсортировать массив? (1 - Да, 0 - Нет): ");
                                int toSort = ReadInteger("", 0, 1);
                                if (toSort == 1) ArraySort(ref arr);
                                else break;
                            }
                            int key = ReadInteger("Введите искомый элемент: ", -10000, 10000);
                            int posOfKey, iterNum;

                            bool find = BinarySearch(arr, key, out posOfKey, out iterNum);

                            if (find)
                            {
                                Console.WriteLine($"Искомый элемент находится в массиве на позиции: {posOfKey}");
                                Console.WriteLine($"Для нахождения потребовалось итераций: {iterNum}");
                            }
                            else Console.WriteLine("Искомый элемент не найден");
                            break;
                        }
                }

            } while (!finish);
        }
    }
}
