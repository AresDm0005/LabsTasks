using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    public partial class AddDepartmentForm : Form
    {
        private Firm phx;
        public string[] monthsNames = { "", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        private int positionToAdd;

        public AddDepartmentForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
        }

        private void AddDepartmentForm_Load(object sender, EventArgs e)
        {
            InitIncomeTable();
            endRadioButton.Checked = true;
        }

        private void InitIncomeTable()
        {
            int yearsAmount = phx.endYear - phx.startYear + 1;

            // Оформление "Шапки"
            string[] years = { "", "", "", "", "", "", "" };

            for (int i = 1; i <= phx.endYear - phx.startYear + 1; i++)
            {
                years[i] = (phx.startYear + i - 1).ToString();
            }

            string[] months = { "", "Янв", "Февр", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Ноя", "Дек" };

            // Годы
            for (int i = 0; i < years.Length; i++)
            {
                Label lab = new Label();
                lab.Text = years[i];

                lab.Anchor = AnchorStyles.None;
                incomeSetTable.Controls.Add(lab, i, 0);
            }

            //Месяцы
            for (int i = 1; i < months.Length; i++)
            {
                Label lab = new Label();
                lab.Text = months[i];
                lab.Anchor = AnchorStyles.Left;
                incomeSetTable.Controls.Add(lab, 0, i);
            }
            // Шапка оформлена

            // Заполнение таблицы текстбоксами для ввода доходов            
            // Заполнение "неактивных" месяцев
            for (int i = 1; i < phx.startMonth; i++)
            {
                TextBox tb = new TextBox();

                tb.Anchor = AnchorStyles.None;
                tb.ReadOnly = true;
                tb.Text = "-";

                incomeSetTable.Controls.Add(tb, 1, i);
            }

            for (int i = phx.endMonth + 1; i <= 12; i++)
            {
                TextBox tb = new TextBox();

                tb.Anchor = AnchorStyles.None;
                tb.ReadOnly = true;
                tb.Text = "-";

                incomeSetTable.Controls.Add(tb, yearsAmount, i);
            }

            // Заполнение активных месяцев
            int cur_month = phx.startMonth;
            int cur_year = 1;
            for (int i = 1; i <= 60; i++)
            {
                TextBox tb = new TextBox();

                tb.Anchor = AnchorStyles.None;
                tb.Text = "-";
                tb.Name = $"TB {cur_month}-{cur_year}";

                incomeSetTable.Controls.Add(tb, cur_year, cur_month);

                cur_month++;
                if (cur_month == 13)
                {
                    cur_month = 1;
                    cur_year++;
                }
            }
        }

        private void InitNewAddition()
        {
            departmentName.Text = "";
            endRadioButton.Checked = true;

            int cur_month = phx.startMonth;
            int cur_year = 1;
            for (int i = 1; i <= 60; i++)
            {
                Control[] cntrs = incomeSetTable.Controls.Find($"TB {cur_month}-{cur_year}", true);
                TextBox tb = (TextBox)cntrs[0];
                tb.Text = "-";

                cur_month++;
                if (cur_month == 13)
                {
                    cur_month = 1;
                    cur_year++;
                }
            }
        }

        private void beginRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            positionToAdd = 1;
            numberTextBox.Enabled = false;
        }

        private void endRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            positionToAdd = phx.departmentRecordCounter + 1;
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

        private bool CheckNameInput(out string errorMsg)
        {
            errorMsg = "";
            bool ok = true;

            if (departmentName.Text == "")
            {
                errorMsg = "Введите название нового подразделения!";
                ok = false;
            }
            else if (departmentName.Text == Firm.depToRemove)
            {
                errorMsg = "Данное название подразделения недопустимо!";
                ok = false;
            }
            else
            {
                int index = Array.IndexOf(phx.actualDepartmentNames, departmentName.Text);

                if (index == -1)
                {
                    errorMsg = "Отделение уже существует!\nДля его редактирования используйте раздел \"Редактирование\" или \"Просмотр данных\"";
                    ok = false;
                }
            }

            return ok;
        }

        private bool CheckIncomeInputs(out string errorMsg)
        {
            errorMsg = "";
            bool ok = true;

            int cur_month = phx.startMonth;
            int cur_year = 1;
            for (int i = 0; i < 60 && ok; i++)
            {
                double income = 0;

                Control[] cntrs = incomeSetTable.Controls.Find($"TB {cur_month}-{cur_year}", true);
                TextBox tb = (TextBox)cntrs[0];

                try
                {
                    income = double.Parse(tb.Text);
                }
                catch
                {
                    if (tb.Text != "-")
                    {
                        errorMsg = $"Данные за {monthsNames[cur_month]} {cur_year + phx.startYear - 1} введены не верно";
                        ok = false;
                    }
                }

                if (income < 0)
                {
                    errorMsg = $"Месячный доход не может быть отрицателен: ошибка в {monthsNames[cur_month]} {cur_year + phx.startYear - 1}";
                    ok = false;
                }

                cur_month++;
                if (cur_month == 13)
                {
                    cur_month = 1;
                    cur_year++;
                }
            }

            return ok;
        }

        private bool CheckPositionInput(out string errorMsg)
        {
            errorMsg = "";
            bool ok = true;

            if (numberRadioButton.Checked)
            {
                int key = -1;
                try
                {
                    key = int.Parse(numberTextBox.Text);
                }
                catch
                {
                    errorMsg = "Номер записи введен некорректно";
                    ok = false;
                }

                if (ok)
                {
                    if (key > phx.departmentRecordCounter + 1 || key == 0)
                    {
                        errorMsg = "Невозможно создать новую запись с таким номером";
                        ok = false;
                    }
                    else
                    {
                        positionToAdd = key;
                    }
                }
            }

            return ok;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string[] errors = new string[3];
            if(CheckNameInput(out errors[0]) && CheckIncomeInputs(out errors[1]) && CheckPositionInput(out errors[2]))
            {
                string name = departmentName.Text;
                int cur_month = phx.startMonth;
                int cur_year = 1;

                phx.AddDepartment(name, positionToAdd - 1);

                for (int i = 0; i < 60; i++)
                {
                    double income = Department.BASE_INCOME_VALUE;
                    bool ok = false;

                    Control[] cntrs = incomeSetTable.Controls.Find($"TB {cur_month}-{cur_year}", true);
                    TextBox tb = (TextBox)cntrs[0];

                    if (tb.Text != "-")
                    {
                        ok = true;
                        income = double.Parse(tb.Text);
                    }

                    if (ok)
                        phx.SetIncome(name, i, income, phx.incomeRecordCounter);

                    cur_month++;
                    if (cur_month == 13)
                    {
                        cur_month = 1;
                        cur_year++;
                    }

                    InitNewAddition();
                    MessageBox.Show($"Подразделение {name} успешно добавлено", "", MessageBoxButtons.OK);
                    DialogResult = DialogResult.None;
                }
            } 
            else
            {
                string errorMsg = "";
                foreach(string error in errors)
                {
                    if (error != "") errorMsg += error + '\n';
                }

                MessageBox.Show(errorMsg, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Firm GetUpdatedFirm() { return phx; }
    }
}