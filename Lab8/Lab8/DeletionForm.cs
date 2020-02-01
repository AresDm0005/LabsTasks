using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    public partial class DeletionForm : Form
    {
        private Firm phx;
        private int departDeleteMode;
        private int incomeDeleteMode;
        public string[] monthsNames = { "", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", 
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public DeletionForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
        }

        private void DeletionForm_Load(object sender, EventArgs e)
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
            string name = (mode == 0) ? departmentIdTextBox.Text : incomeIdTextBox.Text;

            int index = Array.IndexOf(phx.actualDepartmentNames, name);

            if(index == -1)
            {
                ok = false;
                error = $"Отделения {name} не найдено";
            }

            return ok;
        }

        private bool CheckNumberInput(int mode, out string error)
        {
            error = "";
            bool ok = true;
            string value = (mode == 0) ? departmentIdTextBox.Text : incomeIdTextBox.Text;
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

        #region DepartmentsDeletion

        private void departKeyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            departDeleteMode = 0;
        }

        private void departNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            departDeleteMode = 1;
        }

        private void departmentIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (departDeleteMode == 1)
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void ClearDepartmentInputs()
        {
            departmentIdTextBox.Text = "";
            departKeyRadioButton.Checked = true;
        }

        private void departmentDeleteButton_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            if(departDeleteMode == 0)
            {
                if(CheckKeyInput(0, out errorMsg))
                {
                    phx.DeleteDepartment(departmentIdTextBox.Text);
                    MessageBox.Show($"Отделение {departmentIdTextBox.Text} успешно удалено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if(CheckNumberInput(0, out errorMsg))
                {
                    int number = int.Parse(departmentIdTextBox.Text);
                    string name = phx.GetDepartmentName(number - 1);
                    phx.DeleteDepartment(number - 1);

                    MessageBox.Show($"Отделение {name} успешно удалено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if(errorMsg == "")
            {
                ClearDepartmentInputs();
            } 
            else
            {
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.None;
        }

        #endregion

        #region IncomeDeletion
        
        private void incomeKeyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            incomeDeleteMode = 0;

            monthUpDown.Enabled = true;
            yearUpDown.Enabled = true;
        }

        private void incomeNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            incomeDeleteMode = 1;

            monthUpDown.Enabled = false;
            yearUpDown.Enabled = false;
        }

        private void incomeIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (incomeDeleteMode == 1)
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), @"\d") && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
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
        
        private void ClearIncomeInputs()
        {
            incomeKeyRadioButton.Checked = true;
            incomeIdTextBox.Text = "";
        }

        private void incomeDeleteButton_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            if(incomeDeleteMode == 0)
            {
                if(CheckKeyInput(1, out errorMsg))
                {
                    string name = incomeIdTextBox.Text;
                    int index = (decimal.ToInt32(yearUpDown.Value) - phx.startYear) * 12 + decimal.ToInt32(monthUpDown.Value) - phx.startMonth;
                    
                    if(phx.IsIncomeValid(name, index))
                    {
                        phx.DeleteIncome(name, index);
                        MessageBox.Show($"Значение дохода за {monthsNames[(int)monthUpDown.Value]} месяц {yearUpDown.Value} год удалено", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if(!phx.IsIncomeSet(name, index))
                        {
                            errorMsg = "Записи о доходе с таким ключом не существует\n" +
                                "Невозможно удалить данные, которые не существуют";
                        } 
                        else
                        {
                            errorMsg = "Запись о доходе с таким ключом была удалена\n" +
                                "Номера будут откорректированы как только половина записей станет удаленной";
                        }

                        
                    }
                }
            } 
            else
            {
                if(CheckNumberInput(1, out errorMsg))
                {
                    int number = int.Parse(incomeIdTextBox.Text);
                    IncomeId id = phx.GetIncomeId(number - 1);

                    int month = (id.index + phx.startMonth) % 12;
                    int year = (id.index + phx.startMonth - 1) / 12 + phx.startYear;

                    if(!phx.IsIncomeDeleted(id.name, id.index))
                    {
                        phx.DeleteIncome(number);
                        MessageBox.Show($"Значение дохода за {monthsNames[month]} месяц {year} год удалено", "", MessageBoxButtons.OK);
                    } 
                    else
                    {
                        errorMsg = "Запись о доходе с таким ключом была удалена\n" +
                                "Номера будут откорректированы как только половина записей станет удаленной";
                    }

                   
                }
            }

            if(errorMsg == "")
            {
                ClearIncomeInputs();
            } 
            else
            {
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.None;
        }

        #endregion

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public Firm GetUpdatedFirm() { return phx; }
    }
}
