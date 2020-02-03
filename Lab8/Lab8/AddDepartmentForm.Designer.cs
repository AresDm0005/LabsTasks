namespace Lab8
{
    partial class AddDepartmentForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.numberRadioButton = new System.Windows.Forms.RadioButton();
            this.endRadioButton = new System.Windows.Forms.RadioButton();
            this.beginRadioButton = new System.Windows.Forms.RadioButton();
            this.incomeSetTable = new System.Windows.Forms.TableLayoutPanel();
            this.departmentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numberTextBox);
            this.groupBox1.Controls.Add(this.numberRadioButton);
            this.groupBox1.Controls.Add(this.endRadioButton);
            this.groupBox1.Controls.Add(this.beginRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(14, 596);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 129);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(89, 97);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox.TabIndex = 6;
            this.numberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
            // 
            // numberRadioButton
            // 
            this.numberRadioButton.AutoSize = true;
            this.numberRadioButton.Location = new System.Drawing.Point(6, 98);
            this.numberRadioButton.Name = "numberRadioButton";
            this.numberRadioButton.Size = new System.Drawing.Size(82, 17);
            this.numberRadioButton.TabIndex = 5;
            this.numberRadioButton.TabStop = true;
            this.numberRadioButton.Text = "По номеру:";
            this.numberRadioButton.UseVisualStyleBackColor = true;
            this.numberRadioButton.CheckedChanged += new System.EventHandler(this.numberRadioButton_CheckedChanged);
            // 
            // endRadioButton
            // 
            this.endRadioButton.AutoSize = true;
            this.endRadioButton.Location = new System.Drawing.Point(6, 64);
            this.endRadioButton.Name = "endRadioButton";
            this.endRadioButton.Size = new System.Drawing.Size(65, 17);
            this.endRadioButton.TabIndex = 4;
            this.endRadioButton.TabStop = true;
            this.endRadioButton.Text = "В конец";
            this.endRadioButton.UseVisualStyleBackColor = true;
            this.endRadioButton.CheckedChanged += new System.EventHandler(this.endRadioButton_CheckedChanged);
            // 
            // beginRadioButton
            // 
            this.beginRadioButton.AutoSize = true;
            this.beginRadioButton.Location = new System.Drawing.Point(6, 29);
            this.beginRadioButton.Name = "beginRadioButton";
            this.beginRadioButton.Size = new System.Drawing.Size(70, 17);
            this.beginRadioButton.TabIndex = 3;
            this.beginRadioButton.TabStop = true;
            this.beginRadioButton.Text = "В начало";
            this.beginRadioButton.UseVisualStyleBackColor = true;
            this.beginRadioButton.CheckedChanged += new System.EventHandler(this.beginRadioButton_CheckedChanged);
            // 
            // incomeSetTable
            // 
            this.incomeSetTable.ColumnCount = 7;
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.incomeSetTable.Location = new System.Drawing.Point(14, 69);
            this.incomeSetTable.Name = "incomeSetTable";
            this.incomeSetTable.RowCount = 13;
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.incomeSetTable.Size = new System.Drawing.Size(650, 510);
            this.incomeSetTable.TabIndex = 28;
            // 
            // departmentName
            // 
            this.departmentName.Location = new System.Drawing.Point(14, 27);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(189, 20);
            this.departmentName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Название подразделения";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(527, 702);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Закрыть окно";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(358, 702);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(135, 23);
            this.okButton.TabIndex = 30;
            this.okButton.Text = "Добавить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AddDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 736);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.incomeSetTable);
            this.Controls.Add(this.departmentName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddDepartmentForm";
            this.Text = "Добавление подразделения";
            this.Load += new System.EventHandler(this.AddDepartmentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.RadioButton numberRadioButton;
        private System.Windows.Forms.RadioButton endRadioButton;
        private System.Windows.Forms.RadioButton beginRadioButton;
        private System.Windows.Forms.TableLayoutPanel incomeSetTable;
        private System.Windows.Forms.TextBox departmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}