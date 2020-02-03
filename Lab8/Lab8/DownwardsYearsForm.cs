using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab8
{
    public partial class DownwardsYearsForm : Form
    {
        private Firm phx;
        private string[] monthsNames = { "", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public DownwardsYearsForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
            phx.Task2();
        }

        private void DownwardsYearsForm_Load(object sender, EventArgs e)
        {
            Label head = new Label();
            head.Text = "Подразделение";
            showTable.Controls.Add(head, 0, 0);

            Label head1 = new Label();
            head1.Text = $"Периоды.   Средний доход по фирме: {phx.averageIncome}";
            head1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);


            showTable.Controls.Add(head1, 1, 0);

            int depCount = phx.actualDepartmentNames.Length;

            RowStyle tmp = showTable.RowStyles[1];
            showTable.RowCount = depCount + 1;
            showTable.Size = new Size(1200, 40 + depCount * 40);
            for (int i = 2; i < showTable.ColumnCount; i++)
            {
                showTable.RowStyles.Insert(i, new RowStyle(tmp.SizeType, tmp.Height));
            }

            

            int k = 1;
            foreach (string name in phx.actualDepartmentNames)
            {
                FillRow(name, k++, phx.GetDepartment(name));
            }
        }

        public void FillRow(string name, int ind, Department dep)
        {
            Label label = new Label();
            label.Text = $"{name}";
            showTable.Controls.Add(label, 0, ind);

            Label label1 = new Label();
            label1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            label1.Text = $"Самый большой период, с доходом меньше среднего (в месяцах): {dep.longestIncomeFallPeriod}. Период с {monthsNames[phx.GetCurrentMonth(dep.indexStartPeriod)]} " +
                $"{phx.GetCurrentYear(dep.indexStartPeriod)} года по {monthsNames[phx.GetCurrentMonth(dep.indexStartPeriod + dep.longestIncomeFallPeriod)]} " +
                $"{phx.GetCurrentYear(dep.indexStartPeriod + dep.longestIncomeFallPeriod)} год";
            showTable.Controls.Add(label1, 1, ind);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
