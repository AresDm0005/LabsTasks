using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab8
{
    public partial class ShowDataForm : Form
    {
        private string[] years;
        private string[] months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private Firm phx;

        public ShowDataForm(Firm phx)
        {
            InitializeComponent();
            this.phx = phx;
            SetYears();
        }

        private void SetYears()
        {
            years = new string[phx.yearSpan + 1];
            years[0] = "";

            for(int i = 1; i <= phx.yearSpan; i++)
            {
                years[i] = (phx.startYear + i - 1).ToString();
            }

        }

        private void ShowDataForm_Load(object sender, EventArgs e)
        {
            Label head = new Label();
            head.Text = "Подразделение";
            showTable.Controls.Add(head, 0, 0);

            Label head1 = new Label();
            head1.Text = "Доходы";
            showTable.Controls.Add(head1, 1, 0);

            int depCount = phx.actualDepartmentNames.Length;
            
            RowStyle tmp = showTable.RowStyles[1];
            showTable.RowCount = depCount + 1;
            showTable.Size = new Size(910, 40 + depCount * 510);
            for (int i = 2; i < showTable.ColumnCount; i++)
            {
                showTable.RowStyles.Insert(i, new RowStyle(tmp.SizeType, tmp.Height));
            }

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

            TableLayoutPanel table = SetSampleTableSettings(sampleTable);
            table.Name = $"TLP {showTable.RowCount - 1}";
            table.Visible = true;

            Random rand = new Random();

            int index = 0;
            for (int j = 1; j < 13; j++)
            {
                if (j < phx.startMonth)
                {
                    Label lab = new Label();

                    lab.Anchor = AnchorStyles.None;

                    lab.Text = "-";
                    table.Controls.Add(lab, 1, j);
                }
                else
                {
                    LinkLabel lab = new LinkLabel();

                    lab.Anchor = AnchorStyles.None;
                    lab.Name = $"{name} {index}";
                    lab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(defaultLinkedLabel_Click);

                    if (dep.GetIncome(index) == Department.BASE_INCOME_VALUE || dep.GetIncome(index) == Department.INCOME_TO_REMOVE)
                        lab.Text = "TBD";
                    else
                        lab.Text = string.Format("{0:f2}", dep.GetIncome(index));
                    table.Controls.Add(lab, 1, j);

                    index++;
                }
            }

            for (int i = 2; i < phx.yearSpan; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    LinkLabel lab = new LinkLabel();

                    lab.Anchor = AnchorStyles.None;
                    lab.Name = $"{name} {index}";
                    lab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(defaultLinkedLabel_Click);

                    if (dep.GetIncome(index) == Department.BASE_INCOME_VALUE || dep.GetIncome(index) == Department.INCOME_TO_REMOVE)
                        lab.Text = "TBD";
                    else
                        lab.Text = string.Format("{0:f2}", dep.GetIncome(index));
                    table.Controls.Add(lab, i, j);

                    index++;
                }
            }

            for (int j = 1; j < 13; j++)
            {
                if (j <= phx.endMonth)
                {
                    LinkLabel lab = new LinkLabel();

                    lab.Anchor = AnchorStyles.None;
                    lab.Name = $"{name} {index}";
                    lab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(defaultLinkedLabel_Click);

                    if (dep.GetIncome(index) == Department.BASE_INCOME_VALUE || dep.GetIncome(index) == Department.INCOME_TO_REMOVE)
                        lab.Text = "TBD";
                    else
                        lab.Text = string.Format("{0:f2}", dep.GetIncome(index));
                    table.Controls.Add(lab, phx.yearSpan, j);

                    index++;
                }
                else
                {
                    Label lab = new Label();

                    lab.Anchor = AnchorStyles.None;

                    lab.Text = "-";
                    table.Controls.Add(lab, phx.yearSpan, j);
                }
            }

            showTable.Controls.Add(table, 1, ind);
        }

        private TableLayoutPanel SetSampleTableSettings(TableLayoutPanel copied)
        {
            TableLayoutPanel table = new TableLayoutPanel();

            table.ColumnCount = copied.ColumnCount;
            table.ColumnStyles.Clear();

            for (int i = 0; i < table.ColumnCount; i++)
            {
                table.ColumnStyles.Insert(i, new ColumnStyle(copied.ColumnStyles[i].SizeType, copied.ColumnStyles[i].Width));
            }

            table.RowCount = copied.RowCount;
            for (int i = 0; i < table.RowCount; i++)
            {
                table.RowStyles.Insert(i, new RowStyle(copied.RowStyles[i].SizeType, copied.RowStyles[i].Height));
            }
            table.Size = new Size(copied.Width, copied.Height);
            table.Visible = true;

            for (int i = 0; i < years.Length; i++)
            {
                Label lab = new Label();
                lab.Text = years[i];

                lab.Font = fontLabel.Font;
                lab.Anchor = AnchorStyles.None;
                table.Controls.Add(lab, i, 0);
            }

            for (int i = 1; i < months.Length; i++)
            {
                Label lab = new Label();
                lab.Text = months[i];
                lab.Font = fontLabel.Font;
                lab.Anchor = AnchorStyles.Left;
                table.Controls.Add(lab, 0, i);
            }
            return table;
        }

        private void defaultLinkedLabel_Click(object sender, EventArgs e)
        {
            LinkLabel label = (LinkLabel)sender;

            string[] labelName = label.Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = labelName[0];
            int index = int.Parse(labelName[1]);

            if (label.Text == "TBD")
            {
                DlgSetIncome dlg = new DlgSetIncome(phx, name, index);
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    label.Text = dlg.income.ToString();
                    phx = dlg.GetUpdatedForm();
                }

                dlg.Dispose();
            } 
            else
            {
                DlgChangeIncome dlg = new DlgChangeIncome(phx, name, index);
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    label.Text = dlg.income.ToString();
                    phx = dlg.GetUpdatedForm();
                }

                dlg.Dispose();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
