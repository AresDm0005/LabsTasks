using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Arrays
    {
        public const int MAX_ELEM = 100;
        public const int MIN_ELEM = -100;

        public const int MAX_SIZE = 20;
        public const int MIN_SIZE = 1;

        public const string empty = "Пустой массив";

        private int type;

        private string strArr;
        private int[] arr;
        
        private string strMtx;
        private int[,] mtx;

        private string strJag;
        private int[][] jag;

        public Arrays(int typeOfArray)
        {
            this.type = typeOfArray;

            switch (type) {
                case 0:
                    arr = null;
                    strArr = "Одномерный массив не инициализирован";
                    break;
                case 1:
                    mtx = null;
                    strMtx = "Матрица не инициализирована";
                    break;
                case 2:
                    jag = null;
                    strJag = "Рваный массив не инициализирован";
                    break;
            }
        }

        override public string ToString()
        {
            string txt = "";

            switch (type)
            {
                case 0:
                    {
                        if (arr.Length == 0) txt = empty;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            txt += arr[i].ToString() + " ";
                        }
                        break;
                    }
                case 1:
                    {
                        if (mtx.GetLength(0) == 0) txt = empty;
                        for (int i = 0; i < mtx.GetLength(0); i++)
                        {
                            for (int j = 0; j < mtx.GetLength(1); j++)
                            {
                                txt += mtx[i, j].ToString() + " ";
                            }
                            txt += "\n\r";
                        }

                        break;
                    }
                case 2:
                    {
                        if (jag.GetLength(0) == 0) txt = empty;
                        for (int i = 0; i < jag.GetLength(0); i++)
                        {
                            for (int j = 0; j < jag[i].Length; j++)
                            {
                                txt += jag[i][j].ToString() + " ";
                            }
                            txt += "\n\r";
                        }
                        break;
                    }
            }

            return txt;
        }

        #region IntLogic
        private static int[] CreateRandomArray(int sizeOfArray)
        {
            int[] arr = new int[sizeOfArray];

            Random rand = new Random();
            for (int i = 0; i < sizeOfArray; i++) arr[i] = rand.Next(MIN_ELEM, MAX_ELEM);

            return arr;
        }

        private static int[] ArrayDeleteEven(int[] arr)
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

            return newArr;
        }

        private static int[,] CreateRandomMatrix(int row, int column)
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

        private static int[,] MatrixAddRows(int[,] matr, int[,] addMatr)
        {
            int[,] newMatr;
            if (matr.GetLength(0) == 0) newMatr = addMatr;
            else
            {
                int row = matr.GetLength(0);
                int col = addMatr.GetLength(1);
                int k = addMatr.GetLength(0);
                newMatr = new int[row + k, col];


                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        newMatr[i, j] = matr[i, j];
                    }
                }


                for (int i = row; i < row + k; i++)
                {
                    int t = i - row;
                    for (int j = 0; j < col; j++)
                    {
                        newMatr[i, j] = addMatr[t, j];
                    }
                }
            }
            return newMatr;
        }

        private static int[][] CreateRandomJagged(int row, int[] sizes)
        {
            int[][] jag = new int[row][];
            Random rand = new Random();


            for (int i = 0; i < row; i++)
            {
                int size = sizes[i];
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

        private static bool JaggedFirstRowWithZero(ref int[][] jag, ref int rowDel)
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

        private static int[][] JaggedDeleteZeroRow(int[][] jag)
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


                return jag1;
            }
        }
        #endregion

        #region Define
        public void Define(string txt, string txtSize, bool random)
        {
            if (random)
            {
                int row = Convert.ToInt32(txtSize);
                jag = new int[row][];

                string[] nums = txt.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] size = new int[row];
                for (int i = 0; i < row; i++)
                {
                    size[i] = Convert.ToInt32(nums[i]);
                }

                jag = CreateRandomJagged(row, size);

            }
            else
            {
                int row = Convert.ToInt32(txtSize);
                jag = new int[row][];

                string[] str = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < row; i++)
                {
                    string[] nums = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int size = Convert.ToInt32(nums[0]);
                    jag[i] = new int[size];
                    for (int j = 0; j < size; j++)
                    {
                        jag[i][j] = Convert.ToInt32(nums[j + 1]);
                    }
                }
            }

            strJag = this.ToString();
        }

        public void Define(string txt, string txtSize)
        {
            int size = Convert.ToInt32(txtSize);
            arr = new int[size];

            string[] nums = txt.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(nums[i]);
            }

            strArr = this.ToString();
        }

        public void Define(string txt, string txtSize1, string txtSize2)
        {
            int row = Convert.ToInt32(txtSize1);
            int col = Convert.ToInt32(txtSize2);
            
            mtx = new int[row, col];
            string[] str = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < row; i++)
            {
                string[] nums = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < col; j++)
                {
                    mtx[i, j] = Convert.ToInt32(nums[j]);
                }
            }

            strMtx = this.ToString();
        }

        public void DefineRandom(string txtSize)
        {
            int size = Convert.ToInt32(txtSize);

            arr = CreateRandomArray(size);
            strArr = this.ToString();
        }

        public void DefineRandom(string txtSize1, string txtSize2)
        {
            int row = Convert.ToInt32(txtSize1);
            int col = Convert.ToInt32(txtSize2);

            mtx = CreateRandomMatrix(row, col);
            strMtx = this.ToString();
        }
        #endregion

        #region Action
        public void PerformAction()
        {
            if (type == 0)
            {
                arr = ArrayDeleteEven(arr);

                if (arr.Length == 0)
                {
                    strArr = empty;
                    arr = null;
                }
                else strArr = this.ToString();
            }
            else
            {
                jag = JaggedDeleteZeroRow(jag);

                if (jag.GetLength(0) == 0)
                {
                    strJag = empty;
                    jag = null;
                }
                else strJag = this.ToString();
            }
        }

        public void PerformAction(string txt, string txtSize, string txtSize2 = "")
        {
            if (txt == "")
            {
                PerformActionMtxRandom(Convert.ToInt32(txtSize), Convert.ToInt32(txtSize2));
                return;
            }
            string[] str = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int row = Convert.ToInt32(txtSize);
            int col;
            if (mtx == null) col = Convert.ToInt32(txtSize2);
            else col = mtx.GetLength(1);

            int[,] addMatr = new int[row, col];
            
            for (int i = 0; i < row; i++)
            {
                string[] nums = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < col; j++)
                {
                    addMatr[i, j] = Convert.ToInt32(nums[j]);
                }
            }

            if (mtx == null)
            {
                mtx = new int[0, 0];
                mtx = MatrixAddRows(mtx, addMatr);

                strMtx = this.ToString();
            }
            else
            {
                mtx = MatrixAddRows(mtx, addMatr);
                strMtx = this.ToString();
            }
        }

        private void PerformActionMtxRandom(int row, int col)
        {
            int[,] addMtx = new int[row, col];

            Random rand = new Random();
            for(int i = 0; i<row; i++)
            {
                for(int j = 0; j<col; j++)
                {
                    addMtx[i, j] = rand.Next(MIN_ELEM, MAX_ELEM);
                }
            }

            mtx = MatrixAddRows(mtx, addMtx);
            strMtx = this.ToString();
        }
        #endregion

        #region BackToForm
        public string GetStrArr()
        {
            return this.strArr;
        }

        public string GetStrMtx()
        {
            return this.strMtx;
        }

        public string GetStrJag()
        {
            return this.strJag;
        }

        public int GetMtxColumns()
        {
            if (mtx == null) return 0;
            return mtx.GetLength(1);
        }
        #endregion
    }
}
