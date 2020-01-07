using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class DlgJagged : Form
    {
        private int actionId;
        private ErrorProvider sizeError = new ErrorProvider();
        private ErrorProvider elemError = new ErrorProvider();

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
        }

        private void DlgJagged_Load(object sender, EventArgs e)
        {

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
            sizeError.SetError(sizeText, "");
        }

        private void elementsText_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckJagged(elementsText.Text, sizeText.Text, actionId, out errorMsg))
            {
                e.Cancel = true;
                elementsText.Select(0, elementsText.Text.Length);

                elemError.SetError(elementsText, errorMsg);
            }
        }

        private void elementsText_Validated(object sender, EventArgs e)
        {
            elemError.SetError(elementsText, "");
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
            return sizeText.Text;
        }

        public string GetJaggedText()
        {
            return elementsText.Text;
        }
    }
}
