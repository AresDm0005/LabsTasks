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
    public partial class DlgChangeIncome : Form
    {
        private Firm phx;
        private string name;
        private int index;
        public int position { get; private set; }
        public double income { get; private set; }
        private string[] monthsNames = { "", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public DlgChangeIncome(Firm phx, string name, int index)
        {
            InitializeComponent();
            this.phx = phx;
            this.name = name;
            this.index = index;
        }

        private void DlgChangeIncome_Load(object sender, EventArgs e)
        {
            monthLabel.Text = monthsNames[phx.GetCurrentMonth(index)];
            yearLabel.Text = phx.GetCurrentYear(index).ToString();
            incomeLabel.Text = phx.GetDepartment(name).GetIncome(index).ToString();
        }

        private void incomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d,]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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
            string error = "";
            if(CheckIncomeInput(out error))
            {
                income = double.Parse(incomeTextBox.Text);
                phx.ChangeIncome(name, index, income);
                DialogResult = DialogResult.OK;
            } 
            else
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal Firm GetUpdatedForm()
        {
            return phx;
        }
    }
}
