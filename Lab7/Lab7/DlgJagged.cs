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
                this.Size = new Size(400, 260);
                this.Text = "Ввод рваного массива";

                elementsTextBox.Size = new Size(190, 110);
                rowsLable.Text = "Число строк:";
                elementsLabel.Text = "Размер строки и\n\rЭлементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }
            else
            {
                this.Size = new Size(400, 180);
                this.Text = "Ввод размеров рваного массива";

                elementsTextBox.Size = new Size(235, 20);
                elementsTextBox.Multiline = false;
                rowsLable.Text = "Число строк:";
                elementsLabel.Text = "Размеры строк: ";

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
    }
}
