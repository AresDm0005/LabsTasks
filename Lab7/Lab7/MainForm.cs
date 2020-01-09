﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab7
{
    public partial class MainForm : Form
    {
        static string[] activities = { "Удалить четные элементы:", "Добавить К строк в конец матрицы", "Удалить первую строку с нулями" };
        private static Arrays arr = new Arrays(0);
        private static Arrays mtx = new Arrays(1);
        private static Arrays jag = new Arrays(2);

        public MainForm()
        {
            InitializeComponent();
            arraysComboBox.SelectedIndex = 0;
            readLabel.Text = "Ввести массив с клавиатуры:";
            createLabel.Text = "Сформировать массив с помощью ДСЧ:";

            readButton.Text = "Ввести!";
            createButton.Text = "Сформировать!";

            justLabel1.Text = "Выбранный тип массива: ";
            justLabel2.Text = "Текущий массив";
            arrayOutTextBox.Text = "Массив не инициализирован";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void arraysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            activityLabel.Text = activities[arraysComboBox.SelectedIndex];
            activityButton.Text = activities[arraysComboBox.SelectedIndex].Split(' ')[0] + '!';

            switch (arraysComboBox.SelectedIndex)
            {
                case 0:
                    {
                        arrayOutTextBox.Text = arr.GetStrArr();
                        break;
                    }
                case 1:
                    {
                        arrayOutTextBox.Text = mtx.GetStrMtx();
                        break;
                    }
                case 2:
                    {
                        arrayOutTextBox.Text = jag.GetStrJag();
                        break;
                    }
            }            
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            switch (arraysComboBox.SelectedIndex)
            {
                case 0:
                    {
                        DlgArray dlg = new DlgArray(0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            arr.Define(dlg.GetArrayText(), dlg.GetSizeText());

                            arrayOutTextBox.Text = arr.GetStrArr();
                        }

                        break;
                    }
                case 1:
                    {
                        DlgMatrix dlg = new DlgMatrix(0, 0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.Define(dlg.GetMatrixText(), dlg.GetSize1Text(), dlg.GetSize2Text());

                            arrayOutTextBox.Text = mtx.GetStrMtx();
                        }


                        break;
                    }
                case 2:
                    {
                        DlgJagged dlg = new DlgJagged(0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            jag.Define(dlg.GetJaggedText(), dlg.GetSizeText(), false);

                            arrayOutTextBox.Text = jag.GetStrJag();
                        }

                        break;
                    }

            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            switch (arraysComboBox.SelectedIndex)
            {
                case 0:
                    {
                        DlgArray dlg = new DlgArray(1);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            arr.DefineRandom(dlg.GetSizeText());

                            arrayOutTextBox.Text = arr.GetStrArr();
                        }

                        break;
                    }
                case 1:
                    {
                        DlgMatrix dlg = new DlgMatrix(1, 0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.DefineRandom(dlg.GetSize1Text(), dlg.GetSize2Text());

                            arrayOutTextBox.Text = mtx.GetStrMtx();
                        }

                        break;
                    }
                case 2:
                    {
                        DlgJagged dlg = new DlgJagged(1);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            jag.Define(dlg.GetJaggedText(), dlg.GetSizeText(), true);

                            arrayOutTextBox.Text = jag.GetStrJag();
                        }

                        break;
                    }

            }
        }

        private void activityButton_Click(object sender, EventArgs e)
        {
            switch (arraysComboBox.SelectedIndex)
            {
                case 0:
                    {
                        string change = arr.GetStrArr();
                        
                        if(arrayOutTextBox.Text == Arrays.empty)
                        {
                            MessageBox.Show("Массив пуст!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                        else
                        {
                            arr.PerformAction();
                            arrayOutTextBox.Text = arr.GetStrArr();

                            if (arrayOutTextBox.Text == change)
                            {
                                MessageBox.Show("В массиве нет четных. Ничего не было удалено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        
                        break;
                    }
                case 1:
                    {
                        string change = mtx.GetStrMtx();
                        DlgMatrix dlg = new DlgMatrix(2, mtx.GetMtxColumns());
                        dlg.ShowDialog();

                        if(dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.PerformAction(dlg.GetMatrixText(), dlg.GetSize1Text(), dlg.GetSize2Text());

                            arrayOutTextBox.Text = mtx.GetStrMtx();
                        }

                        break;
                    }
                case 2:
                    {
                        string change = jag.GetStrJag();
                        
                        if (arrayOutTextBox.Text == Arrays.empty)
                        {
                            MessageBox.Show("Массив пуст!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            jag.PerformAction();

                            arrayOutTextBox.Text = jag.GetStrJag();
                            if (arrayOutTextBox.Text == change)
                            {
                                MessageBox.Show("В массиве нет строк с 0. Ничего не было удалено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }


                        
                        break;
                    }
            }
        }

        private void saveFileOption_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                var fileStream = saveFileDialog.OpenFile(); 

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    int type = arraysComboBox.SelectedIndex;

                    switch (type)
                    {
                        case 0:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(arr.GetLength());
                                writer.WriteLine(arr.GetStrArr());
                                break;
                            }
                        case 1:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(mtx.GetLength());
                                writer.WriteLine(mtx.GetStrMtx());
                                break;
                            }
                        case 2:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(jag.GetLength());
                                writer.WriteLine(jag.GetStrJag());
                                break;
                            }
                    }
                }
            }
        }

        private void loadFileOption_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                        string error = "";
                        try
                        {
                            string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            int it = 0;
                            foreach(string line in lines)
                            {
                                line.Trim();
                                if (line == "") it++;
                            }

                            int type = 0;
                            if(Regex.IsMatch(lines[0], @"[012]"))
                            {
                                type = Convert.ToInt32(lines[0]);
                            }

                            arraysComboBox.SelectedIndex = type;
                            switch (type)
                            {
                                case 0:
                                    {
                                        if (InputHandler.CheckArray(lines[2], lines[1], out error))
                                        {
                                            arr.Define(lines[2], lines[1]);
                                            arrayOutTextBox.Text = arr.GetStrArr();
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        if (InputHandler.CheckSize(lines[1], ref error)){
                                            int row = Convert.ToInt32(lines[1]);

                                            string txt = "";
                                            for(int i = 3; i<3+row; i++)
                                            {
                                                txt += lines[i] + "\n";
                                            } 

                                            if(InputHandler.CheckMatrix(txt, lines[1], lines[2], out error))
                                            {
                                                mtx.Define(txt, lines[1], lines[2]);
                                                arrayOutTextBox.Text = mtx.GetStrMtx();
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if(InputHandler.CheckSize(lines[1], ref error)){
                                            int row = Convert.ToInt32(lines[1]);

                                            string txt = "";
                                            for (int i = 2; i < 2 + row; i++)
                                            {
                                                txt += lines[i] + "\n";
                                            }

                                            if(InputHandler.CheckJagged(txt, lines[1], 0, out error))
                                            {
                                                jag.Define(txt, lines[1]);
                                                arrayOutTextBox.Text = jag.GetStrJag();
                                            }
                                        }
                                        break;
                                    }
                            }
                            if (error != "") MessageBox.Show($"Произошла ошибка при чтении файла:\n{error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show("При чтении файла произошла ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }
    }
}
