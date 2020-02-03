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

namespace Lab8
{
    public partial class DlgSetIncome : Form
    {
        private Firm phx;
        private string name;
        private int index;
        public int position { get; private set; }
        public double income { get; private set; }

        private string[] monthsNames = { "", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public DlgSetIncome(Firm phx, string name, int index)
        {
            InitializeComponent();
            this.phx = phx;
            this.name = name;
            this.index = index;
        }

        private void DlgSetIncome_Load(object sender, EventArgs e)
        {
            monthLabel.Text = monthsNames[phx.GetCurrentMonth(index)];
            yearLabel.Text = phx.GetCurrentYear(index).ToString();
            endRadioButton.Checked = true;
        }

        private void incomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d,]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void beginRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            position = 1;
            numberTextBox.Enabled = false;
        }

        private void endRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            position = phx.incomeRecordCounter + 1;
            numberTextBox.Enabled = false;
        }

        private void numberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            numberTextBox.Enabled = true;
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
                if (number > upperBound + 1 || number == 0)
                {
                    ok = false;
                    error = "Записи с таким номером не существует";
                }
            }

            return ok;
        }

        private bool CheckIncomeInput(out string error)
        {
            error = "";
            bool ok = true;

            double income = 0;
            try
            {
                income = double.Parse(incomeTextBox.Text);
            }
            catch
            {
                ok = false;
                error = "Значение дохода введено некорректно";
            }

            return ok;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string[] errors = { "", "" };
            if (numberRadioButton.Checked)
            {
                if (CheckNumberInput(out errors[0]) && CheckIncomeInput(out errors[1]))
                {
                    income = double.Parse(incomeTextBox.Text);
                    position = int.Parse(numberTextBox.Text);

                    incomeTextBox.Text = position.ToString();
                    phx.SetIncome(name, index, income, position-1);
                    DialogResult = DialogResult.OK;
                }
            } 
            else
            {
                if(CheckIncomeInput(out errors[0]))
                {
                    income = double.Parse(incomeTextBox.Text);
                    incomeTextBox.Text = position.ToString();
                    phx.SetIncome(name, index, income, position-1);
                    
                    DialogResult = DialogResult.OK;
                }
            }

            string errorMsg = "";
            foreach (string error in errors) if (error != "") errorMsg += error + '\n';

            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Firm GetUpdatedForm()
        {
            return phx;
        }
    }
}
