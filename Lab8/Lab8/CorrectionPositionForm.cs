using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    public partial class CorrectionPositionForm : Form
    {
        public int positionChange { get; private set; }
        public Firm phx;

        public CorrectionPositionForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
            beginRadioButton.Checked = true;
        }

        private void beginRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            positionChange = 1;
            numberTextBox.Enabled = false;
        }

        private void endRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            positionChange = phx.incomeRecordCounter + 1;
            numberTextBox.Enabled = false;
        }

        private void numberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            numberTextBox.Enabled = true;
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private bool CheckNumberInput(out string error)
        {
            error = "";
            bool ok = true;
            string value = numberTextBox.Text;
            int upperBound = phx.incomeRecordCounter;

            int number = 0;
            try
            {
                number = int.Parse(value);
            }
            catch
            {
                ok = false;
                error = "Номер записи введен некорректно";
            }

            if (ok)
            {
                if (number > upperBound || number == 0)
                {
                    ok = false;
                    error = "Записи с таким номером не существует";
                }
            }

            return ok;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string errorMsg = "";

            if (numberRadioButton.Checked)
            {
                if(CheckNumberInput(out errorMsg))
                {
                    positionChange = int.Parse(numberTextBox.Text);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.None;
                    MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
