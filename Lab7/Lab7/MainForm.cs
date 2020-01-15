using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab7
{
    public partial class MainForm : Form
    {
        private static string[] activities = { "Удалить четные элементы:", "Добавить К строк в конец матрицы", "Удалить первую строку с нулями" };
        private static Arrays arr;
        private static Arrays mtx;
        private static Arrays jag;

        public MainForm()
        {
            InitializeComponent();            
            readLabel.Text = "Ввести массив с клавиатуры:";
            createLabel.Text = "Сформировать массив с помощью ДСЧ:";

            readButton.Text = "Ввести!";
            createButton.Text = "Сформировать!";

            justLabel1.Text = "Выбранный тип массива: ";
            justLabel2.Text = "Текущий массив";

            arr = new Arrays(0);
            mtx = new Arrays(1);
            jag = new Arrays(2);

            arraysComboBox.SelectedIndex = 0;
        }

        private void arraysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            activityLabel.Text = activities[arraysComboBox.SelectedIndex];
            activityButton.Text = activities[arraysComboBox.SelectedIndex].Split(' ')[0] + '!';

            switch (arraysComboBox.SelectedIndex)
            {
                case 0:
                    {
                        arrayOutTextBox.Text = arr.GetStringFormArray();
                        break;
                    }
                case 1:
                    {
                        arrayOutTextBox.Text = mtx.GetStringFormArray();
                        break;
                    }
                case 2:
                    {
                        arrayOutTextBox.Text = jag.GetStringFormArray();
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
                            arr.Define(dlg.GetStringOfElements(), dlg.GetLengthAsString());
                            arrayOutTextBox.Text = arr.GetStringFormArray();
                        }
                        dlg.Dispose();
                        break;
                    }
                case 1:
                    {
                        DlgMatrix dlg = new DlgMatrix(0, 0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.Define(dlg.GetStringOfElements(), dlg.GetRowsAsString(), dlg.GetColumnsAsString());
                            arrayOutTextBox.Text = mtx.GetStringFormArray();
                        }
                        dlg.Dispose();
                        break;
                    }
                case 2:
                    {
                        DlgJagged dlg = new DlgJagged(0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            jag.Define(dlg.GetStringOfElements(), dlg.GetRowsAsString(), false);
                            arrayOutTextBox.Text = jag.GetStringFormArray();
                        }
                        dlg.Dispose();
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
                            arr.DefineRandom(dlg.GetLengthAsString());
                            arrayOutTextBox.Text = arr.GetStringFormArray();
                        }
                        dlg.Dispose();
                        break;
                    }
                case 1:
                    {
                        DlgMatrix dlg = new DlgMatrix(1, 0);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.DefineRandom(dlg.GetRowsAsString(), dlg.GetColumnsAsString());
                            arrayOutTextBox.Text = mtx.GetStringFormArray();
                        }
                        dlg.Dispose();
                        break;
                    }
                case 2:
                    {
                        DlgJagged dlg = new DlgJagged(1);
                        dlg.ShowDialog();

                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            jag.Define(dlg.GetStringOfElements(), dlg.GetRowsAsString(), true);
                            arrayOutTextBox.Text = jag.GetStringFormArray();
                        }
                        dlg.Dispose();
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
                        string change = arr.GetStringFormArray();
                        
                        if(arrayOutTextBox.Text == Arrays.EMPTY)
                        {
                            MessageBox.Show("Массив пуст!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                        else if(arrayOutTextBox.Text == Arrays.INIT)
                        {
                            MessageBox.Show("Массив не инициализирован!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            arr.PerformAction();
                            arrayOutTextBox.Text = arr.GetStringFormArray();

                            if (arrayOutTextBox.Text == change) MessageBox.Show("В массиве нет четных. Ничего не было удалено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                        
                        break;
                    }
                case 1:
                    {
                        string change = mtx.GetStringFormArray();
                        DlgMatrix dlg = new DlgMatrix(2, mtx.GetMtxColumns());
                        dlg.ShowDialog();

                        if(dlg.DialogResult == DialogResult.OK)
                        {
                            mtx.PerformAction(dlg.GetStringOfElements(), dlg.GetRowsAsString(), dlg.GetColumnsAsString());
                            arrayOutTextBox.Text = mtx.GetStringFormArray();
                        }
                        dlg.Dispose();
                        break;
                    }
                case 2:
                    {
                        string change = jag.GetStringFormArray();
                        
                        if (arrayOutTextBox.Text == Arrays.EMPTY)
                        {
                            MessageBox.Show("Массив пуст!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (arrayOutTextBox.Text == Arrays.INIT)
                        {
                            MessageBox.Show("Массив не инициализирован!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            jag.PerformAction();
                            arrayOutTextBox.Text = jag.GetStringFormArray();
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
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = saveFileDialog.OpenFile(); 

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    int type = arraysComboBox.SelectedIndex;

                    switch (type)
                    {
                        case 0:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(arr.GetLength());
                                writer.Write(arr.GetStringFormArray());
                                break;
                            }
                        case 1:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(mtx.GetLength());
                                writer.Write(mtx.GetStringFormArray());
                                break;
                            }
                        case 2:
                            {
                                writer.WriteLine(type.ToString());
                                writer.WriteLine(jag.GetLength());
                                writer.Write(jag.GetStringFormArray());
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
                    string filePath = openFileDialog.FileName;

                    Stream fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                        string error = "";
                        try
                        {
                            string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            string tmp = "";
                            foreach (string line in lines)
                            {
                                if (line.Trim().Length != 0) tmp += line.Trim() + "\n";                                
                            }
                            lines = tmp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

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
                                            arrayOutTextBox.Text = arr.GetStringFormArray();
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
                                                arrayOutTextBox.Text = mtx.GetStringFormArray();
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

                                            if(InputHandler.CheckJagged(txt, lines[1], out error))
                                            {
                                                jag.Define(txt, lines[1], false);
                                                arrayOutTextBox.Text = jag.GetStringFormArray();
                                            }
                                        }
                                        break;
                                    }
                            }
                            if (error != "") MessageBox.Show($"Произошла ошибка при чтении файла:\n{error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show("При чтении файла произошла неизвестная ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void fileHelpOption_Click(object sender, EventArgs e)
        {
            string message = "Перед загрузкой массива из файла убедитесь, что загрузочный файл имеет расширение txt.\nТакже проверьте что он соответсутвует форме:\n";
            message += "<Номер типа (0 - одномерный, 1 - двумерный, 2 - рваный)>\n<Размеры массива (для одномерного - длина, матрицы - на отдельных строках число строк и столбцов,";
            message += "рваного - число строк)>\nДалее сам массив, в такой же форме как в приложении\n\nПример одномерного:\n0\n4\n1 -3 95 13\n\nМатрицы:\n1\n2\n3\n1 54 -7\n4 16 64\n\n";
            message += "Рваного:\n2\n4\n5 3 -8 25 -7 44\n1 0\n4 3 5 2 -1\n3 3 1 2\n\nВ случае ошибки проверьте, что все строки заканчиваются цифрой (то есть не пробелом) и что в файле отсутсвуют пустые строки";
            MessageBox.Show(message, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
