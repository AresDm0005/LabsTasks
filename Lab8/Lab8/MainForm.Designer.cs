namespace Lab8
{
    partial class MainForm
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
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.deletionButton = new System.Windows.Forms.Button();
            this.addDepartamentButton = new System.Windows.Forms.Button();
            this.downwardsYearsButton = new System.Windows.Forms.Button();
            this.profitsYearsButton = new System.Windows.Forms.Button();
            this.dataAccessButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(252, 69);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(125, 23);
            this.loadButton.TabIndex = 16;
            this.loadButton.Text = "Загрузить из файла";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(252, 24);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(125, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Сохранить в файл";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(41, 113);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(140, 25);
            this.changeButton.TabIndex = 14;
            this.changeButton.Text = "Изменение записей";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deletionButton
            // 
            this.deletionButton.Location = new System.Drawing.Point(41, 69);
            this.deletionButton.Name = "deletionButton";
            this.deletionButton.Size = new System.Drawing.Size(140, 25);
            this.deletionButton.TabIndex = 13;
            this.deletionButton.Text = "Удаление записей";
            this.deletionButton.UseVisualStyleBackColor = true;
            this.deletionButton.Click += new System.EventHandler(this.deletionButton_Click);
            // 
            // addDepartamentButton
            // 
            this.addDepartamentButton.Location = new System.Drawing.Point(41, 24);
            this.addDepartamentButton.Name = "addDepartamentButton";
            this.addDepartamentButton.Size = new System.Drawing.Size(140, 25);
            this.addDepartamentButton.TabIndex = 12;
            this.addDepartamentButton.Text = "Добавить отделение";
            this.addDepartamentButton.UseVisualStyleBackColor = true;
            this.addDepartamentButton.Click += new System.EventHandler(this.addDepartamentButton_Click);
            // 
            // downwardsYearsButton
            // 
            this.downwardsYearsButton.Location = new System.Drawing.Point(463, 113);
            this.downwardsYearsButton.Name = "downwardsYearsButton";
            this.downwardsYearsButton.Size = new System.Drawing.Size(136, 23);
            this.downwardsYearsButton.TabIndex = 11;
            this.downwardsYearsButton.Text = "Периоды спада";
            this.downwardsYearsButton.UseVisualStyleBackColor = true;
            this.downwardsYearsButton.Click += new System.EventHandler(this.downwardsYearsButton_Click);
            // 
            // profitsYearsButton
            // 
            this.profitsYearsButton.Location = new System.Drawing.Point(463, 70);
            this.profitsYearsButton.Name = "profitsYearsButton";
            this.profitsYearsButton.Size = new System.Drawing.Size(136, 23);
            this.profitsYearsButton.TabIndex = 10;
            this.profitsYearsButton.Text = "Прибыльные годы";
            this.profitsYearsButton.UseVisualStyleBackColor = true;
            this.profitsYearsButton.Click += new System.EventHandler(this.profitsYearsButton_Click);
            // 
            // dataAccessButton
            // 
            this.dataAccessButton.Location = new System.Drawing.Point(463, 24);
            this.dataAccessButton.Name = "dataAccessButton";
            this.dataAccessButton.Size = new System.Drawing.Size(136, 25);
            this.dataAccessButton.TabIndex = 9;
            this.dataAccessButton.Text = "Список данных";
            this.dataAccessButton.UseVisualStyleBackColor = true;
            this.dataAccessButton.Click += new System.EventHandler(this.dataAccessButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 161);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deletionButton);
            this.Controls.Add(this.addDepartamentButton);
            this.Controls.Add(this.downwardsYearsButton);
            this.Controls.Add(this.profitsYearsButton);
            this.Controls.Add(this.dataAccessButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Лабораторная №8";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deletionButton;
        private System.Windows.Forms.Button addDepartamentButton;
        private System.Windows.Forms.Button downwardsYearsButton;
        private System.Windows.Forms.Button profitsYearsButton;
        private System.Windows.Forms.Button dataAccessButton;
    }
}

