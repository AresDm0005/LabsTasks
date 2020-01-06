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
    public partial class DlgMatrix : Form
    {
        private int actionId;
        private ErrorProvider elemError = new ErrorProvider();
        private ErrorProvider size1Error = new ErrorProvider();
        private ErrorProvider size2Error = new ErrorProvider();
        
        public DlgMatrix(int actionId)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.actionId = actionId;

            okButton.Text = "Ок";
            cancelButton.Text = "Отмена";

            if (actionId == 0)
            {
                this.Size = new Size(420, 260);
                this.Text = "Ввод матрицы";

                elementsText.Size = new Size(255, 110);
                sizeLable.Text = "Число строк:";
                size2Label.Text = "Число столбцов";
                elementsLabel.Text = "Элементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }
            else
            {
                this.Size = new Size(420, 130);
                this.Text = "Ввод размера матрицы";

                sizeLable.Text = "Число строк:";
                size2Label.Text = "Число столбцов";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 60);
                cancelButton.Location = new Point(okButton.Location.X + 180, 60);

                elementsText.Hide();
                elementsLabel.Hide();
            }
        }

        private void DlgMatrix_Load(object sender, EventArgs e)
        {

        }

        private void elementsText_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckMatrix(elementsText.Text, sizeText.Text, size2Text.Text, out errorMsg))
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

        private void sizeText_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(sizeText.Text, ref errorMsg))
            {
                e.Cancel = true;
                sizeText.Select(0, sizeText.Text.Length);

                size1Error.SetError(sizeText, errorMsg);
            }
        }

        private void sizeText_Validated(object sender, EventArgs e)
        {
            size1Error.SetError(sizeText, "");
        }

        private void size2Text_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(size2Text.Text, ref errorMsg))
            {
                e.Cancel = true;
                size2Text.Select(0, size2Text.Text.Length);

                size2Error.SetError(size2Text, errorMsg);
            }
        }

        private void size2Text_Validated(object sender, EventArgs e)
        {
            size2Error.SetError(size2Text, "");
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

        private void size2Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public string GetMatrixText()
        {
            return elementsText.Text;
        }

        public string GetSize1Text()
        {
            return sizeText.Text;
        }

        public string GetSize2Text()
        {
            return size2Text.Text;
        }
    }
}
