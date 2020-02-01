using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    public partial class CorrectionForm : Form
    {
        private Firm phx;
        private int departChangeMode;
        private int incomeChangeMode;
        private int positionChange;

        public CorrectionForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
        }

        private void CorrectionForm_Load(object sender, EventArgs e)
        {
            departKeyRadioButton.Checked = true;
            incomeKeyRadioButton.Checked = true;

            yearUpDown.Maximum = phx.endYear;
            yearUpDown.Minimum = phx.startYear;
        }

        private bool CheckKeyInput(int mode, out string error)
        {
            error = "";
            bool ok = true;
            string name = (mode == 0) ? departIdTextBox.Text : incomeIdTextBox.Text;

            int index = Array.IndexOf(phx.actualDepartmentNames, name);

            if (index == -1)
            {
                ok = false;
                error = $"Отделения {name} не найдено";
            }
            
            if(name == "")
            {
                ok = false;
                error = "Введите название подразделения, подвергающееся переименованию";
            }

            return ok;
        }

        private bool CheckRenameInput(out string error)
        {
            error = "";
            bool ok = true;
            string rename = departRenameTextBox.Text;

            int index = Array.IndexOf(phx.actualDepartmentNames, rename);

            if (index != -1)
            {
                ok = false;
                error = "Подразделение с новым названием уже существует. Введите другое или редактируйте существующее";
            }

            if(rename == Firm.depToRemove)
            {
                ok = false;
                error = "Новое название некорректно";
            }

            if (rename == "")
            {
                ok = false;
                error = "Введите название нового подразделения";
            }

            return ok;
        }

        private bool CheckNumberInput(int mode, out string error)
        {
            error = "";
            bool ok = true;
            string value = (mode == 0) ? departIdTextBox.Text : incomeIdTextBox.Text;
            int upperBound = (mode == 0) ? phx.departmentRecordCounter : phx.incomeRecordCounter;

            int key = 0;
            try
            {
                key = int.Parse(value);
            }
            catch
            {
                ok = false;
                error = "Номер записи введен некорректно";
            }

            if (ok)
            {
                if (key > upperBound || key == 0)
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

        #region DepartmentChange

        private void departKeyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            departChangeMode = 0;
        }

        private void departNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            departChangeMode = 1;
        }

        private void departIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (departChangeMode == 1)
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void CleanDepartmentInputs()
        {
            departKeyRadioButton.Checked = true;
            departIdTextBox.Text = "";
            departRenameTextBox.Text = "";
        }

        private void departChangeButton_Click(object sender, EventArgs e)
        {
            string[] errors = new string[2];
            if(departChangeMode == 0)
            {
                if(CheckKeyInput(0, out errors[0]) && CheckRenameInput(out errors[1]))
                {
                    phx.ChangeDepartmentName(departIdTextBox.Text, departRenameTextBox.Text);
                    MessageBox.Show($"Название подразделения {departIdTextBox.Text} изменено на {departRenameTextBox.Text}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if(CheckNumberInput(0, out errors[0]))
                {
                    int number = int.Parse(departIdTextBox.Text);
                    string name = phx.GetDepartmentName(number - 1);

                    phx.ChangeDepartmentName(number - 1, departRenameTextBox.Text);
                    MessageBox.Show($"Название подразделения {name} изменено на {departRenameTextBox.Text}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            string errorMsg = "";
            foreach (string error in errors) if (error != "") errorMsg += error + '\n';

            if (errorMsg == "") CleanDepartmentInputs();
            else MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 

            DialogResult = DialogResult.None;
        }

        #endregion

        #region IncomeChange

        private void incomeKeyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            incomeChangeMode = 0;
        }

        private void incomeNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            incomeChangeMode = 1;
        }

        private void incomeIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (incomeChangeMode == 1)
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void incomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[\d,]") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void yearUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (phx.yearSpan == 6)
            {

                if (yearUpDown.Value == phx.startYear)
                {
                    monthUpDown.Minimum = phx.startMonth;
                    monthUpDown.Maximum = 12;
                    monthUpDown.Value = monthUpDown.Minimum;
                }
                else if (yearUpDown.Value == phx.endYear)
                {
                    monthUpDown.Minimum = 1;
                    monthUpDown.Maximum = phx.endMonth;
                    monthUpDown.Value = monthUpDown.Minimum;
                }
                else
                {
                    monthUpDown.Minimum = 1;
                    monthUpDown.Maximum = 12;
                }
            }
        }

        private void CleanIncomeInputs()
        {
            incomeKeyRadioButton.Checked = true;
            incomeIdTextBox.Text = "";
            incomeTextBox.Text = "";
        }

        private void incomeChangeButton_Click(object sender, EventArgs e)
        {
            string[] errors = { "", ""};
            if(incomeChangeMode == 0)
            {
                if(CheckKeyInput(1, out errors[0]) && CheckIncomeInput(out errors[1]))
                {
                    string name = incomeIdTextBox.Text;
                    int index = (decimal.ToInt32(yearUpDown.Value) - phx.startYear) * 12 + decimal.ToInt32(monthUpDown.Value) - phx.startMonth;
                    double income = double.Parse(incomeTextBox.Text);

                    if (phx.IsIncomeDeleted(name, index))
                    {
                        errors[0] = "Нельзя изменить удаленную запись";
                    } 
                    else if(!phx.IsIncomeSet(name, index))
                    {
                        CorrectionPositionForm dlg = new CorrectionPositionForm(phx);

                        if(dlg.ShowDialog() == DialogResult.OK)
                        {
                            positionChange = dlg.positionChange;

                            phx.SetIncome(name, index, income, positionChange);
                            MessageBox.Show("Запись дохода сделана", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        phx.ChangeIncome(name, index, income);
                        MessageBox.Show("Запись дохода изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if(CheckNumberInput(1, out errors[0]) && CheckIncomeInput(out errors[1]))
                {
                    int number = int.Parse(incomeIdTextBox.Text);
                    double income = double.Parse(incomeTextBox.Text);
                    IncomeId id = phx.GetIncomeId(number - 1);

                    if (phx.IsIncomeDeleted(id.name, id.index))
                    {
                        errors[0] = "Нельзя изменить удаленную запись";
                    }
                    else if (!phx.IsIncomeSet(id.name, id.index))
                    {
                        CorrectionPositionForm dlg = new CorrectionPositionForm(phx);

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            positionChange = dlg.positionChange;

                            phx.SetIncome(id.name, id.index, income, positionChange);
                            MessageBox.Show("Запись дохода сделана", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        phx.ChangeIncome(id.name, id.index, income);
                        MessageBox.Show("Запись дохода изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            string errorMsg = "";
            foreach (string error in errors) if (error != "") errorMsg += error + '\n';

            if (errorMsg == "") CleanDepartmentInputs();
            else MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DialogResult = DialogResult.None;
        }

        #endregion

        public Firm GetUpdatedFirm() { return phx; }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        
    }
}
