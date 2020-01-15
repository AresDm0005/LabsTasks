namespace Lab7
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.justLabel1 = new System.Windows.Forms.Label();
            this.arrayOutTextBox = new System.Windows.Forms.TextBox();
            this.justLabel2 = new System.Windows.Forms.Label();
            this.activityButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.activityLabel = new System.Windows.Forms.Label();
            this.createLabel = new System.Windows.Forms.Label();
            this.readLabel = new System.Windows.Forms.Label();
            this.arraysComboBox = new System.Windows.Forms.ComboBox();
            this.fileHelpOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesMenuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesMenuStrip
            // 
            this.filesMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileOption,
            this.loadFileOption,
            this.fileHelpOption});
            this.filesMenuStrip.Name = "filesMenuStrip";
            this.filesMenuStrip.Size = new System.Drawing.Size(57, 20);
            this.filesMenuStrip.Text = "Файлы";
            // 
            // saveFileOption
            // 
            this.saveFileOption.Name = "saveFileOption";
            this.saveFileOption.Size = new System.Drawing.Size(241, 22);
            this.saveFileOption.Text = "Сохранить в файл";
            this.saveFileOption.Click += new System.EventHandler(this.saveFileOption_Click);
            // 
            // loadFileOption
            // 
            this.loadFileOption.Name = "loadFileOption";
            this.loadFileOption.Size = new System.Drawing.Size(241, 22);
            this.loadFileOption.Text = "Загрузить из файла";
            this.loadFileOption.Click += new System.EventHandler(this.loadFileOption_Click);
            // 
            // justLabel1
            // 
            this.justLabel1.AutoSize = true;
            this.justLabel1.Location = new System.Drawing.Point(571, 42);
            this.justLabel1.Name = "justLabel1";
            this.justLabel1.Size = new System.Drawing.Size(35, 13);
            this.justLabel1.TabIndex = 19;
            this.justLabel1.Text = "label1";
            // 
            // arrayOutTextBox
            // 
            this.arrayOutTextBox.Location = new System.Drawing.Point(495, 119);
            this.arrayOutTextBox.Multiline = true;
            this.arrayOutTextBox.Name = "arrayOutTextBox";
            this.arrayOutTextBox.ReadOnly = true;
            this.arrayOutTextBox.Size = new System.Drawing.Size(334, 149);
            this.arrayOutTextBox.TabIndex = 18;
            this.arrayOutTextBox.Text = "label1";
            // 
            // justLabel2
            // 
            this.justLabel2.AutoSize = true;
            this.justLabel2.Location = new System.Drawing.Point(386, 122);
            this.justLabel2.Name = "justLabel2";
            this.justLabel2.Size = new System.Drawing.Size(35, 13);
            this.justLabel2.TabIndex = 17;
            this.justLabel2.Text = "label1";
            // 
            // activityButton
            // 
            this.activityButton.Location = new System.Drawing.Point(246, 224);
            this.activityButton.Name = "activityButton";
            this.activityButton.Size = new System.Drawing.Size(114, 23);
            this.activityButton.TabIndex = 16;
            this.activityButton.Text = "button3";
            this.activityButton.UseVisualStyleBackColor = true;
            this.activityButton.Click += new System.EventHandler(this.activityButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(246, 170);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(114, 23);
            this.createButton.TabIndex = 15;
            this.createButton.Text = "button2";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(246, 117);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(114, 23);
            this.readButton.TabIndex = 14;
            this.readButton.Text = "button1";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // activityLabel
            // 
            this.activityLabel.AutoSize = true;
            this.activityLabel.Location = new System.Drawing.Point(23, 229);
            this.activityLabel.Name = "activityLabel";
            this.activityLabel.Size = new System.Drawing.Size(35, 13);
            this.activityLabel.TabIndex = 13;
            this.activityLabel.Text = "label3";
            // 
            // createLabel
            // 
            this.createLabel.AutoSize = true;
            this.createLabel.Location = new System.Drawing.Point(23, 175);
            this.createLabel.Name = "createLabel";
            this.createLabel.Size = new System.Drawing.Size(35, 13);
            this.createLabel.TabIndex = 12;
            this.createLabel.Text = "label2";
            // 
            // readLabel
            // 
            this.readLabel.AutoSize = true;
            this.readLabel.Location = new System.Drawing.Point(23, 122);
            this.readLabel.Name = "readLabel";
            this.readLabel.Size = new System.Drawing.Size(35, 13);
            this.readLabel.TabIndex = 11;
            this.readLabel.Text = "label1";
            // 
            // arraysComboBox
            // 
            this.arraysComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arraysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arraysComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arraysComboBox.FormattingEnabled = true;
            this.arraysComboBox.Items.AddRange(new object[] {
            "Одномерный",
            "Двумерный",
            "Рваный"});
            this.arraysComboBox.Location = new System.Drawing.Point(728, 39);
            this.arraysComboBox.Name = "arraysComboBox";
            this.arraysComboBox.Size = new System.Drawing.Size(101, 21);
            this.arraysComboBox.TabIndex = 10;
            this.arraysComboBox.SelectedIndexChanged += new System.EventHandler(this.arraysComboBox_SelectedIndexChanged);
            // 
            // fileHelpOption
            // 
            this.fileHelpOption.Name = "fileHelpOption";
            this.fileHelpOption.Size = new System.Drawing.Size(241, 22);
            this.fileHelpOption.Text = "Справка по работе с файлами";
            this.fileHelpOption.Click += new System.EventHandler(this.fileHelpOption_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(844, 301);
            this.Controls.Add(this.justLabel1);
            this.Controls.Add(this.arrayOutTextBox);
            this.Controls.Add(this.justLabel2);
            this.Controls.Add(this.activityButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.activityLabel);
            this.Controls.Add(this.createLabel);
            this.Controls.Add(this.readLabel);
            this.Controls.Add(this.arraysComboBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Лабораторная №7";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveFileOption;
        private System.Windows.Forms.ToolStripMenuItem loadFileOption;
        private System.Windows.Forms.Label justLabel1;
        private System.Windows.Forms.TextBox arrayOutTextBox;
        private System.Windows.Forms.Label justLabel2;
        private System.Windows.Forms.Button activityButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Label activityLabel;
        private System.Windows.Forms.Label createLabel;
        private System.Windows.Forms.Label readLabel;
        private System.Windows.Forms.ComboBox arraysComboBox;
        private System.Windows.Forms.ToolStripMenuItem fileHelpOption;
    }
}

