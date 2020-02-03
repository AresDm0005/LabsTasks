using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Lab8
{
    public partial class MainForm : Form
    {
        private Firm phx;

        public MainForm()
        {
            InitializeComponent();
            DateTime date = DateTime.Today;
            phx = new Firm("Феникс", date);
        }

        private void addDepartamentButton_Click(object sender, EventArgs e)
        {
            AddDepartmentForm dlg = new AddDepartmentForm(phx);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                phx = dlg.GetUpdatedFirm();
            }
            dlg.Dispose();
        }

        private void deletionButton_Click(object sender, EventArgs e)
        {
            DeletionForm dlg = new DeletionForm(phx);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                phx = dlg.GetUpdatedFirm();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            CorrectionForm dlg = new CorrectionForm(phx);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                phx = dlg.GetUpdatedFirm();
            }
        }

        private void dataAccessButton_Click(object sender, EventArgs e)
        {
            ShowDataForm dlg = new ShowDataForm(phx);
            dlg.ShowDialog();
        }

        private void profitsYearsButton_Click(object sender, EventArgs e)
        {
            MostProfitableYearsForm dlg = new MostProfitableYearsForm(phx);
            dlg.ShowDialog();
        }

        private void downwardsYearsButton_Click(object sender, EventArgs e)
        {
            DownwardsYearsForm dlg = new DownwardsYearsForm(phx);
            dlg.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "dat files (*.dat)|*.dat";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;

                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, phx);
                    MessageBox.Show("Данные сериализованы", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "binary files (*.dat)|*.dat";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        BinaryFormatter formatter = new BinaryFormatter();
                        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                        {
                            phx = (Firm)formatter.Deserialize(fs);
                            MessageBox.Show("Данные загружены", "", MessageBoxButtons.OK);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка чтения!", "", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
