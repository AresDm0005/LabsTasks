using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab7
{
    public partial class DlgMatrix : Form
    {
        private int actionId;
        private ErrorProvider elemError;
        private ErrorProvider size1Error;
        private ErrorProvider size2Error;
        
        public DlgMatrix(int actionId, int columnSize)
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

                elementsTextBox.Size = new Size(255, 110);
                rowsLabel.Text = "Число строк:";
                columnsLabel.Text = "Число столбцов";
                elementsLabel.Text = "Элементы массива: ";

                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }
            else if(actionId == 1)
            {
                this.Size = new Size(420, 130);
                this.Text = "Ввод размера матрицы";

                rowsLabel.Text = "Число строк:";                
                columnsLabel.Text = "Число столбцов";                

                okButton.Location = new Point((this.Size.Width - 330) / 2, 60);
                cancelButton.Location = new Point(okButton.Location.X + 180, 60);
                elementsTextBox.Hide();
                elementsLabel.Hide();
            } 
            else
            {
                this.Size = new Size(420, 260);
                this.Text = "Ввод матрицы";

                elementsTextBox.Size = new Size(255, 110);
                rowsLabel.Text = "Число строк:";
                columnsLabel.Text = "Число столбцов";
                elementsLabel.Text = "Элементы массива: ";

                if (columnSize > 0)
                {
                    columnsTextBox.Text = columnSize.ToString();
                    columnsTextBox.ReadOnly = true;
                }
                okButton.Location = new Point((this.Size.Width - 330) / 2, 185);
                cancelButton.Location = new Point(okButton.Location.X + 180, 185);
            }

            size1Error = new ErrorProvider();
            size1Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            size2Error = new ErrorProvider();
            size2Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            elemError = new ErrorProvider();
            elemError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        } 

        private void elementsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            string txt = elementsTextBox.Text;
            if (!(InputHandler.CheckMatrix(elementsTextBox.Text, rowsTextBox.Text, columnsTextBox.Text, out errorMsg) || (actionId == 2 && txt.Trim() == ""))) 
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

        private void rowsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(rowsTextBox.Text, ref errorMsg))
            {
                e.Cancel = true;
                rowsTextBox.Select(0, rowsTextBox.Text.Length);

                size1Error.SetError(rowsTextBox, errorMsg);
            }
        }

        private void rowsTextBox_Validated(object sender, EventArgs e)
        {
            size1Error.SetError(rowsTextBox, String.Empty);
        }

        private void columnsTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            if (!InputHandler.CheckSize(columnsTextBox.Text, ref errorMsg))
            {
                e.Cancel = true;
                columnsTextBox.Select(0, columnsTextBox.Text.Length);

                size2Error.SetError(columnsTextBox, errorMsg);
            }
        }

        private void columnsTextBox_Validated(object sender, EventArgs e)
        {
            size2Error.SetError(columnsTextBox, String.Empty);
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

        private void columnsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public string GetStringOfElements()
        {
            return elementsTextBox.Text.Trim();
        }

        public string GetRowsAsString()
        {
            return rowsTextBox.Text.Trim();
        }

        public string GetColumnsAsString()
        {
            return columnsTextBox.Text.Trim();
        }
    }
}
