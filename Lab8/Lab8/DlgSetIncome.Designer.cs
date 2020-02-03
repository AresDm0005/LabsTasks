namespace Lab8
{
    partial class DlgSetIncome
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
            this.label1 = new System.Windows.Forms.Label();
            this.incomeTextBox = new System.Windows.Forms.TextBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addNumberGroup = new System.Windows.Forms.GroupBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.numberRadioButton = new System.Windows.Forms.RadioButton();
            this.endRadioButton = new System.Windows.Forms.RadioButton();
            this.beginRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addNumberGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание записи о месячном доходе за";
            // 
            // incomeTextBox
            // 
            this.incomeTextBox.Location = new System.Drawing.Point(188, 125);
            this.incomeTextBox.Name = "incomeTextBox";
            this.incomeTextBox.Size = new System.Drawing.Size(117, 20);
            this.incomeTextBox.TabIndex = 1;
            this.incomeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.incomeTextBox_KeyPress);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthLabel.Location = new System.Drawing.Point(290, 19);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(46, 17);
            this.monthLabel.TabIndex = 2;
            this.monthLabel.Text = "label2";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearLabel.Location = new System.Drawing.Point(371, 19);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(46, 17);
            this.yearLabel.TabIndex = 3;
            this.yearLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Текущее значение дохода:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(205, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "не установлено или удалено";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Новое значение дохода:";
            // 
            // addNumberGroup
            // 
            this.addNumberGroup.Controls.Add(this.numberTextBox);
            this.addNumberGroup.Controls.Add(this.numberRadioButton);
            this.addNumberGroup.Controls.Add(this.endRadioButton);
            this.addNumberGroup.Controls.Add(this.beginRadioButton);
            this.addNumberGroup.Location = new System.Drawing.Point(12, 163);
            this.addNumberGroup.Name = "addNumberGroup";
            this.addNumberGroup.Size = new System.Drawing.Size(261, 129);
            this.addNumberGroup.TabIndex = 29;
            this.addNumberGroup.TabStop = false;
            this.addNumberGroup.Text = "Добавить:";
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
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(361, 261);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 25);
            this.okButton.TabIndex = 30;
            this.okButton.Text = "Изменить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(478, 261);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DlgSetIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 297);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addNumberGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.incomeTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DlgSetIncome";
            this.Text = "Изменение дохода";
            this.Load += new System.EventHandler(this.DlgSetIncome_Load);
            this.addNumberGroup.ResumeLayout(false);
            this.addNumberGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox incomeTextBox;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox addNumberGroup;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.RadioButton numberRadioButton;
        private System.Windows.Forms.RadioButton endRadioButton;
        private System.Windows.Forms.RadioButton beginRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}