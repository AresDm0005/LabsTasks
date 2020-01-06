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
    public partial class DlgArray : Form
    {
        private int actionId;
        private ErrorProvider sizeError = new ErrorProvider();
        private ErrorProvider elemError = new ErrorProvider();
        
        public DlgArray(int actionId)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.actionId = actionId;

            //sizeError.SetError(sizeText, "Ничего не введено");
            //elemError.SetError(elementsText, "Ничего не введено");

            okButton.Text = "Ок";
            cancelButton.Text = "Отмена";

            // 0 - Ввод всего массива
            // 1 - Ввод только размера
            if (actionId == 0)
            {
                this.Size = new Size(400, 180);
                this.Text = "Ввод одномерного массива";

                elementsText.Size = new Size(235, 20);
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
                //elementsText.Enabled = false;
                //elementsLabel.Enabled = false;
            }
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
            if (!InputHandler.CheckArray(elementsText.Text, sizeText.Text, out errorMsg))
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
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d\s]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public string GetSizeText()
        {
            return sizeText.Text;
        }

        public string GetArrayText()
        {
            return elementsText.Text;
        }
    }
}
