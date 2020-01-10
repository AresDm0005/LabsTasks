using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    class InputHandler
    {
        private static int sizeLowerBound = Arrays.MIN_SIZE;
        private static int sizeUpperBound = Arrays.MAX_SIZE;
        private static int elementLowerBound = Arrays.MIN_ELEM;
        private static int elementUpperBound = Arrays.MAX_ELEM;

        public static bool CheckSize(string txt, ref string error)
        {
            string pat = @"\d+";
            
            if (Regex.IsMatch(txt, pat))
            {
                int num;
                try
                {
                    num = Convert.ToInt32(txt);
                }
                catch (OverflowException)
                {
                    error = "В качестве размера массива введено число, неподдерживаемое по величине";
                    return false;
                }
                if (num >= sizeLowerBound && num <= sizeUpperBound) return true;
                else
                {
                    error = $"Размер массива не попадает в рабочий диапазон от {sizeLowerBound} до {sizeUpperBound}";
                }
            }
            else
            {
                if (txt == String.Empty) error = "Размер не был введен";
                else error = "Размер должен быть выражен целым числом";               
            }

            return false;
        }

        public static bool CheckArray(string txt, string txtSize, out string error)
        {
            string[] nums = txt.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            error = "";

            if (CheckSize(txtSize, ref error))
            {
                int size = Convert.ToInt32(txtSize);

                if (nums.Length == size)
                {
                    int okNums = 0;

                    for (int i = 0; i < size; i++)
                    {
                        int num;
                        try
                        {
                            num = Convert.ToInt32(nums[i]);
                        }
                        catch (FormatException)
                        {
                            error = $"Элемент {i + 1} - не целое число";
                            return false;
                        }
                        catch (OverflowException)
                        {
                            error = $"В качестве элемента массива {i + 1} введено число, неподдерживаемое по величине";
                            return false;
                        }

                        if (num >= elementLowerBound && num <= elementUpperBound) okNums++;
                        else
                        {
                            error = $"Элемент {i + 1} не попадает в рабочий диапазон от {elementLowerBound} до {elementUpperBound}!";
                            break;
                        }
                    }

                    if (okNums == size) return true;
                }
                else
                {                    
                    if(size < nums.Length) error = "Введено меньше элементов, чем указано!";
                    else error = "Введено больше элементов, чем указано!";
                }
            }
            
            return false;            
        }

        public static bool CheckMatrix(string txt, string txtSize1, string txtSize2, out string error)
        {
            error = "";

            bool size1Ok = CheckSize(txtSize1, ref error);
            bool size2Ok = CheckSize(txtSize2, ref error);

            if (size1Ok && size2Ok)
            {
                int row = Convert.ToInt32(txtSize1);
                int size = Convert.ToInt32(txtSize2);
                string[] rows = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (rows.Length == row)
                {
                    int okRows = 0;
                    for (int i = 0; i < row; i++)
                    {
                        string[] nums = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (nums.Length == size)
                        {
                            int okNums = 0;

                            for (int j = 0; j < size; j++)
                            {
                                int num;
                                try
                                {
                                    num = Convert.ToInt32(nums[j]);
                                }
                                catch (FormatException)
                                {
                                    error = $"Элемент {j + 1} в строке {i + 1} - не целое число";
                                    return false;
                                }
                                catch (OverflowException)
                                {
                                    error = $"В качестве элемента {i + 1} в строке {i + 1} введено число, неподдерживаемое по величине";
                                    return false;
                                }

                                if (num >= elementLowerBound && num <= elementUpperBound) okNums++;
                                else
                                {
                                    error = $"Элемент {i + 1} в строке {i + 1} не попадает в рабочий диапазон от {elementLowerBound} до {elementUpperBound}!";
                                    break;
                                }
                            }

                            if (okNums == size) okRows++;
                            else return false;
                        }
                        else
                        {
                            error = $"Количество введенных элементов в строке {i + 1} не соответствует указанному количеству столбцов";
                            return false;
                        }
                    }

                    if (okRows == row) return true;
                }
                else
                {
                    if(row < rows.Length) error = "Введено меньше строк, чем указано";
                    else error = "Введено больше строк, чем указано";
                }
            }
            else if (!size1Ok && !size2Ok)
            {
                string err = "";
                size2Ok = CheckSize(txtSize1, ref err);
                error = err + "\n\r" + error;
            }

            return false;
        }

        public static bool CheckJaggedRandom(string txt, string txtSize, out string error)
        {
            error = "";
            if (CheckSize(txtSize, ref error))
            {
                string[] nums = txt.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int size = Convert.ToInt32(txtSize);
                if (nums.Length == size)
                {
                    bool ok = true;
                    for (int i = 0; i < size && ok; i++) ok = CheckSize(nums[i], ref error);

                    return ok;
                }
                else
                {
                    error = "Введенное количество размеров строк не соответствует указанному";
                    if (nums.Length > size) error += " (больше)";
                    else error += " (меньше)";
                }
            }

            return false;
        }

        public static bool CheckJagged(string txt, string txtSize, out string error)
        {
            error = "";
            if (CheckSize(txtSize, ref error))
            {
                int row = Convert.ToInt32(txtSize);
                string[] rows = txt.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (rows.Length == row)
                {
                    int okRows = 0;
                    for (int i = 0; i < row; i++)
                    {
                        string[] nums = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (CheckSize(nums[0], ref error))
                        {
                            int size = Convert.ToInt32(nums[0]);

                            if (nums.Length - 1 == size)
                            {
                                int okNums = 0;

                                for (int j = 1; j < size + 1; j++)
                                {
                                    int num;
                                    try
                                    {
                                        num = Convert.ToInt32(nums[j]);
                                    }
                                    catch (FormatException)
                                    {
                                        error = $"Элемент {j + 1} в строке {i + 1} - не целое число";
                                        return false;
                                    }
                                    catch (OverflowException)
                                    {
                                        error = $"В качестве элемента {i + 1} в строке {i + 1} введено число, неподдерживаемое по величине";
                                        return false;
                                    }

                                    if (num >= elementLowerBound && num <= elementUpperBound) okNums++;
                                    else
                                    {
                                        error = $"Элемент {i + 1} в строке {i + 1} не попадает в рабочий диапазон от {elementLowerBound} до {elementUpperBound}!";
                                        break;
                                    }
                                }

                                if (okNums == size) okRows++;
                                else return false;
                            }
                            else
                            {
                                error = $"Указанный размер строки {i + 1} не соответствует количеству введенных элементов";
                                return false;
                            }
                        }
                        else return false;
                    }

                    if (okRows == row) return true;
                }
                else
                {
                    error = "Указанное количество строк не соответствует введенному количеству!";
                    return false;
                }
            }

            return false;                       
        }
      
    }
}
