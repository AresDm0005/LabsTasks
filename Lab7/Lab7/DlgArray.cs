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

                elementsText.Size = new Size(230, 20);
                elementsText.Multiline = false;
                sizeLabel.Text = "Размер массива:";
                elementsLabel.Text = "Элементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 100);
                cancelButton.Location = new Point(okButton.Location.X + 180, 100);
            }
            else
            {
                this.Size = new Size(400, 130);
                this.Text = "Ввод размера одномерного массива";

                sizeLabel.Text = "Размер массива:";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 60);
                cancelButton.Location = new Point(okButton.Location.X + 180, 60);

                elementsText.Hide();
                elementsLabel.Hide();
            }

            sizeError = new ErrorProvider();
            sizeError.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            elemError = new ErrorProvider();
            elemError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void sizeText_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(sizeText.Text, ref errorMsg))
            {
                e.Cancel = true;
                sizeText.Select(0, sizeText.Text.Length);

                sizeError.SetError(sizeText, errorMsg);
            }
        }

        private void sizeText_Validated(object sender, EventArgs e)
        {
            sizeError.SetError(sizeText, String.Empty);
        }

        private void elementsText_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!InputHandler.CheckArray(elementsText.Text, sizeText.Text, out errorMsg))
            {
                e.Cancel = true;
                elementsText.Select(0, elementsText.Text.Length);

                elemError.SetError(elementsText, errorMsg);
            }
        }

        private void elementsText_Validated(object sender, EventArgs e)
        {
            elemError.SetError(elementsText, String.Empty);
        }

        private void sizeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void elementsText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d\s\-]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public string GetSizeText()
        {
            return sizeText.Text.Trim();
        }

        public string GetArrayText()
        {
            return elementsText.Text.Trim();
        }
    }
}
