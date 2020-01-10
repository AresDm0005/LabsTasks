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

                elementsText.Size = new Size(190, 110);
                sizeLable.Text = "Число строк:";
                elementsLabel.Text = "Размер строки и\n\rЭлементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }
            else
            {
                this.Size = new Size(400, 180);
                this.Text = "Ввод размеров рваного массива";

                elementsText.Size = new Size(235, 20);
                elementsText.Multiline = false;
                sizeLable.Text = "Число строк:";
                elementsLabel.Text = "Размеры строк: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 100);
                cancelButton.Location = new Point(okButton.Location.X + 180, 100);
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
            bool condition = (actionId == 0) ? !InputHandler.CheckJagged(elementsText.Text, sizeText.Text, out errorMsg) :
                !InputHandler.CheckJaggedRandom(elementsText.Text, sizeText.Text, out errorMsg);

            if (condition)
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

        public string GetJaggedText()
        {
            return elementsText.Text.Trim();
        }
    }
}
