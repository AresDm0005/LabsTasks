using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab8
{
    public partial class MostProfitableYearsForm : Form
    {
        private Firm phx;

        public MostProfitableYearsForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
        }

        private void MostProfitableYearsForm_Load(object sender, EventArgs e)
        {
            Label head = new Label();
            head.Text = "Подразделение";
            showTable.Controls.Add(head, 0, 0);

            Label head1 = new Label();
            head1.Text = "Доход";
            showTable.Controls.Add(head1, 1, 0);

            int depCount = phx.actualDepartmentNames.Length;

            RowStyle tmp = showTable.RowStyles[1];
            showTable.RowCount = depCount + 1;
            showTable.Size = new Size(1200, 40 + depCount * 40);
            for (int i = 2; i < showTable.ColumnCount; i++)
            {
                showTable.RowStyles.Insert(i, new RowStyle(tmp.SizeType, tmp.Height));
            }

            phx.Task1();

            int k = 1;
            foreach(string name in phx.actualDepartmentNames)
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
            label1.Text = $"Самый прибыльный год: {dep.MaxIncomeYear() + phx.startYear}, с доходом: {dep.MaxIncomeValue()}";
            showTable.Controls.Add(label1, 1, ind);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
