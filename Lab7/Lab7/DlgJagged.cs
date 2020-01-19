using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab7
{
    public partial class DlgJagged : Form
    {
        private int actionId;
        private ErrorProvider sizeError;
        private ErrorProvider elemError;

        public DlgJagged(int actionId)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.actionId = actionId;

            okButton.Text = "Ок";
            cancelButton.Text = "Отмена";

            if (actionId == 0)
            {
                this.Size = new Size(580, 260);
                this.Text = "Ввод рваного массива";

                elementsTextBox.Size = new Size(190, 110);
                rowsLable.Text = "Число строк:";
                elementsLabel.Text = "Размер строки и\n\rЭлементы массива: ";

                helpLabel.Text = "Пример ввода:\nСтрок: 3\n1 1\n2 2 3\n3 4 5 6\n\nВ полученном массиве:\n1 строка содержит 1 элемент - 1\n2 строка 2 элемента - 2 и 3\nи третья строка 3 элемента - 4,5 и 6";
                helpLabel.Location = new Point(350, 10);

                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }
            else
            {
                this.Size = new Size(700, 180);
                this.Text = "Ввод размеров рваного массива";

                elementsTextBox.Size = new Size(235, 20);
                elementsTextBox.Multiline = false;
                rowsLable.Text = "Число строк:";
                elementsLabel.Text = "Размеры строк: ";

                helpLabel.Text = "Пример ввода:\nСтрок: 3\nРазмеры: 1 2 3\n\n В полученном массиве будет 3 строки с 1,2,3\nслучайными элементами в строке соответственно";
                helpLabel.Location = new Point(400, 10);

                okButton.Location = new Point((this.Size.Width - 330) / 2, 100);
                cancelButton.Location = new Point(okButton.Location.X + 180, 100);
            }

            sizeError = new ErrorProvider();
            sizeError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            elemError = new ErrorProvider();
            elemError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void rowsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(rowsTextBox.Text, ref errorMsg))
            {
                e.Cancel = true;
                rowsTextBox.Select(0, rowsTextBox.Text.Length);

                sizeError.SetError(rowsTextBox, errorMsg);
            }
        }

        private void rowsTextBox_Validated(object sender, EventArgs e)
        {
            sizeError.SetError(rowsTextBox, String.Empty);
        }

        private void elementsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            bool condition = (actionId == 0) ? !InputHandler.CheckJagged(elementsTextBox.Text, rowsTextBox.Text, out errorMsg) :
                !InputHandler.CheckJaggedRandom(elementsTextBox.Text, rowsTextBox.Text, out errorMsg);

            if (condition)
            {
                e.Cancel = true;
                elementsTextBox.Select(0, elementsTextBox.Text.Length);

                elemError.SetError(elementsTextBox, errorMsg);
            }
        }

        private void elementsTextBox_Validated(object sender, EventArgs e)
        {
            elemError.SetError(elementsTextBox, String.Empty);
        }

        private void rowsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void elementsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d\s\-]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public string GetRowsAsString()
        {
            return rowsTextBox.Text.Trim();
        }

        public string GetStringOfElements()
        {
            return elementsTextBox.Text.Trim();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Visible)) this.Close();
            else this.DialogResult = 0;
        }
    }
}
