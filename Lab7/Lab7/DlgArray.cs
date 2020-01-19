using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab7
{
    public partial class DlgArray : Form
    {
        private int actionId;
        private ErrorProvider sizeError;
        private ErrorProvider elemError;
        
        public DlgArray(int actionId)
        {
            InitializeComponent();            
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.actionId = actionId;
            
            okButton.Text = "Ок";
            cancelButton.Text = "Отмена";

            // 0 - Ввод всего массива
            // 1 - Ввод только размера
            if (actionId == 0)
            {
                this.Size = new Size(400, 180);
                this.Text = "Ввод одномерного массива";

                elementsTextBox.Size = new Size(230, 20);
                elementsTextBox.Multiline = false;
                lengthLabel.Text = "Размер массива:";
                elementsLabel.Text = "Элементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 100);
                cancelButton.Location = new Point(okButton.Location.X + 180, 100);
            }
            else
            {
                this.Size = new Size(400, 130);
                this.Text = "Ввод размера одномерного массива";

                lengthLabel.Text = "Размер массива:";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 60);
                cancelButton.Location = new Point(okButton.Location.X + 180, 60);

                elementsTextBox.Hide();
                elementsLabel.Hide();
            }

            sizeError = new ErrorProvider();
            sizeError.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            elemError = new ErrorProvider();
            elemError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void lengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(lengthTextBox.Text, ref errorMsg))
            {
                e.Cancel = true;
                lengthTextBox.Select(0, lengthTextBox.Text.Length);

                sizeError.SetError(lengthTextBox, errorMsg);
            }
        }

        private void lengthTextBox_Validated(object sender, EventArgs e)
        {
            sizeError.SetError(lengthTextBox, String.Empty);
        }

        private void elementsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!InputHandler.CheckArray(elementsTextBox.Text, lengthTextBox.Text, out errorMsg))
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

        private void lengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        public string GetLengthAsString()
        {
            return lengthTextBox.Text.Trim();
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
