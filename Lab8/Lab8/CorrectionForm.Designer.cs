namespace Lab8
{
    partial class CorrectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.departmentPage = new System.Windows.Forms.TabPage();
            this.departRenameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.departChangeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.departIdTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.departKeyRadioButton = new System.Windows.Forms.RadioButton();
            this.departNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.incomePage = new System.Windows.Forms.TabPage();
            this.incomeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.incomeChangeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearUpDown = new System.Windows.Forms.NumericUpDown();
            this.monthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.incomeIdTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.incomeKeyRadioButton = new System.Windows.Forms.RadioButton();
            this.incomeNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.departmentPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.incomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(363, 331);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 25);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.departmentPage);
            this.tabControl.Controls.Add(this.incomePage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(501, 313);
            this.tabControl.TabIndex = 17;
            // 
            // departmentPage
            // 
            this.departmentPage.Controls.Add(this.departRenameTextBox);
            this.departmentPage.Controls.Add(this.label6);
            this.departmentPage.Controls.Add(this.departChangeButton);
            this.departmentPage.Controls.Add(this.label1);
            this.departmentPage.Controls.Add(this.departIdTextBox);
            this.departmentPage.Controls.Add(this.panel1);
            this.departmentPage.Location = new System.Drawing.Point(4, 22);
            this.departmentPage.Name = "departmentPage";
            this.departmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.departmentPage.Size = new System.Drawing.Size(493, 287);
            this.departmentPage.TabIndex = 0;
            this.departmentPage.Text = "Изменение подразделения";
            this.departmentPage.UseVisualStyleBackColor = true;
            // 
            // departRenameTextBox
            // 
            this.departRenameTextBox.Location = new System.Drawing.Point(22, 174);
            this.departRenameTextBox.Name = "departRenameTextBox";
            this.departRenameTextBox.Size = new System.Drawing.Size(170, 20);
            this.departRenameTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Введите новое название подразделения";
            // 
            // departChangeButton
            // 
            this.departChangeButton.Location = new System.Drawing.Point(347, 256);
            this.departChangeButton.Name = "departChangeButton";
            this.departChangeButton.Size = new System.Drawing.Size(140, 25);
            this.departChangeButton.TabIndex = 14;
            this.departChangeButton.Text = "Изменить";
            this.departChangeButton.UseVisualStyleBackColor = true;
            this.departChangeButton.Click += new System.EventHandler(this.departChangeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите ключ/номер изменяемого отделения:";
            // 
            // departIdTextBox
            // 
            this.departIdTextBox.Location = new System.Drawing.Point(22, 119);
            this.departIdTextBox.Name = "departIdTextBox";
            this.departIdTextBox.Size = new System.Drawing.Size(163, 20);
            this.departIdTextBox.TabIndex = 3;
            this.departIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.departIdTextBox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.departKeyRadioButton);
            this.panel1.Controls.Add(this.departNumberRadioButton);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 85);
            this.panel1.TabIndex = 2;
            // 
            // departKeyRadioButton
            // 
            this.departKeyRadioButton.AutoSize = true;
            this.departKeyRadioButton.Location = new System.Drawing.Point(16, 17);
            this.departKeyRadioButton.Name = "departKeyRadioButton";
            this.departKeyRadioButton.Size = new System.Drawing.Size(144, 17);
            this.departKeyRadioButton.TabIndex = 0;
            this.departKeyRadioButton.TabStop = true;
            this.departKeyRadioButton.Text = "Изменить по названию";
            this.departKeyRadioButton.UseVisualStyleBackColor = true;
            this.departKeyRadioButton.CheckedChanged += new System.EventHandler(this.departKeyRadioButton_CheckedChanged);
            // 
            // departNumberRadioButton
            // 
            this.departNumberRadioButton.AutoSize = true;
            this.departNumberRadioButton.Location = new System.Drawing.Point(16, 54);
            this.departNumberRadioButton.Name = "departNumberRadioButton";
            this.departNumberRadioButton.Size = new System.Drawing.Size(131, 17);
            this.departNumberRadioButton.TabIndex = 1;
            this.departNumberRadioButton.TabStop = true;
            this.departNumberRadioButton.Text = "Изменить по номеру";
            this.departNumberRadioButton.UseVisualStyleBackColor = true;
            this.departNumberRadioButton.CheckedChanged += new System.EventHandler(this.departNumberRadioButton_CheckedChanged);
            // 
            // incomePage
            // 
            this.incomePage.Controls.Add(this.incomeTextBox);
            this.incomePage.Controls.Add(this.label7);
            this.incomePage.Controls.Add(this.incomeChangeButton);
            this.incomePage.Controls.Add(this.label5);
            this.incomePage.Controls.Add(this.label4);
            this.incomePage.Controls.Add(this.label3);
            this.incomePage.Controls.Add(this.yearUpDown);
            this.incomePage.Controls.Add(this.monthUpDown);
            this.incomePage.Controls.Add(this.label2);
            this.incomePage.Controls.Add(this.incomeIdTextBox);
            this.incomePage.Controls.Add(this.panel2);
            this.incomePage.Location = new System.Drawing.Point(4, 22);
            this.incomePage.Name = "incomePage";
            this.incomePage.Padding = new System.Windows.Forms.Padding(3);
            this.incomePage.Size = new System.Drawing.Size(493, 287);
            this.incomePage.TabIndex = 1;
            this.incomePage.Text = "Изменение месячных доходов";
            this.incomePage.UseVisualStyleBackColor = true;
            // 
            // incomeTextBox
            // 
            this.incomeTextBox.Location = new System.Drawing.Point(19, 221);
            this.incomeTextBox.Name = "incomeTextBox";
            this.incomeTextBox.Size = new System.Drawing.Size(140, 20);
            this.incomeTextBox.TabIndex = 20;
            this.incomeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.incomeTextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Введите новое значение дохода";
            // 
            // incomeChangeButton
            // 
            this.incomeChangeButton.Location = new System.Drawing.Point(347, 256);
            this.incomeChangeButton.Name = "incomeChangeButton";
            this.incomeChangeButton.Size = new System.Drawing.Size(140, 25);
            this.incomeChangeButton.TabIndex = 13;
            this.incomeChangeButton.Text = "Изменить";
            this.incomeChangeButton.UseVisualStyleBackColor = true;
            this.incomeChangeButton.Click += new System.EventHandler(this.incomeChangeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Год";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Месяц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Укажите месяц и год за который корректируется информация";
            // 
            // yearUpDown
            // 
            this.yearUpDown.Location = new System.Drawing.Point(137, 158);
            this.yearUpDown.Name = "yearUpDown";
            this.yearUpDown.Size = new System.Drawing.Size(69, 20);
            this.yearUpDown.TabIndex = 9;
            this.yearUpDown.ValueChanged += new System.EventHandler(this.yearUpDown_ValueChanged);
            // 
            // monthUpDown
            // 
            this.monthUpDown.Location = new System.Drawing.Point(22, 158);
            this.monthUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.monthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthUpDown.Name = "monthUpDown";
            this.monthUpDown.Size = new System.Drawing.Size(71, 20);
            this.monthUpDown.TabIndex = 8;
            this.monthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите номер записи /  название отделения в котором изменяется информация";
            // 
            // incomeIdTextBox
            // 
            this.incomeIdTextBox.Location = new System.Drawing.Point(22, 110);
            this.incomeIdTextBox.Name = "incomeIdTextBox";
            this.incomeIdTextBox.Size = new System.Drawing.Size(137, 20);
            this.incomeIdTextBox.TabIndex = 6;
            this.incomeIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.incomeIdTextBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.incomeKeyRadioButton);
            this.panel2.Controls.Add(this.incomeNumberRadioButton);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 85);
            this.panel2.TabIndex = 5;
            // 
            // incomeKeyRadioButton
            // 
            this.incomeKeyRadioButton.AutoSize = true;
            this.incomeKeyRadioButton.Location = new System.Drawing.Point(16, 17);
            this.incomeKeyRadioButton.Name = "incomeKeyRadioButton";
            this.incomeKeyRadioButton.Size = new System.Drawing.Size(131, 17);
            this.incomeKeyRadioButton.TabIndex = 0;
            this.incomeKeyRadioButton.TabStop = true;
            this.incomeKeyRadioButton.Text = "Изменение по ключу";
            this.incomeKeyRadioButton.UseVisualStyleBackColor = true;
            this.incomeKeyRadioButton.CheckedChanged += new System.EventHandler(this.incomeKeyRadioButton_CheckedChanged);
            // 
            // incomeNumberRadioButton
            // 
            this.incomeNumberRadioButton.AutoSize = true;
            this.incomeNumberRadioButton.Location = new System.Drawing.Point(16, 54);
            this.incomeNumberRadioButton.Name = "incomeNumberRadioButton";
            this.incomeNumberRadioButton.Size = new System.Drawing.Size(138, 17);
            this.incomeNumberRadioButton.TabIndex = 1;
            this.incomeNumberRadioButton.TabStop = true;
            this.incomeNumberRadioButton.Text = "Изменение по номеру";
            this.incomeNumberRadioButton.UseVisualStyleBackColor = true;
            this.incomeNumberRadioButton.CheckedChanged += new System.EventHandler(this.incomeNumberRadioButton_CheckedChanged);
            // 
            // CorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 371);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tabControl);
            this.Name = "CorrectionForm";
            this.Text = "Изменение данных";
            this.Load += new System.EventHandler(this.CorrectionForm_Load);
            this.tabControl.ResumeLayout(false);
            this.departmentPage.ResumeLayout(false);
            this.departmentPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.incomePage.ResumeLayout(false);
            this.incomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage departmentPage;
        private System.Windows.Forms.TextBox departRenameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button departChangeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox departIdTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton departKeyRadioButton;
        private System.Windows.Forms.RadioButton departNumberRadioButton;
        private System.Windows.Forms.TabPage incomePage;
        private System.Windows.Forms.TextBox incomeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button incomeChangeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yearUpDown;
        private System.Windows.Forms.NumericUpDown monthUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox incomeIdTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton incomeKeyRadioButton;
        private System.Windows.Forms.RadioButton incomeNumberRadioButton;
    }
}