namespace Lab7
{
    partial class DlgJagged
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
            this.okButton = new System.Windows.Forms.Button();
            this.elementsTextBox = new System.Windows.Forms.TextBox();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.elementsLabel = new System.Windows.Forms.Label();
            this.rowsLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(218, 90);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(39, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 25);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // elementsText
            // 
            this.elementsTextBox.Location = new System.Drawing.Point(133, 53);
            this.elementsTextBox.Multiline = true;
            this.elementsTextBox.Name = "elementsText";
            this.elementsTextBox.Size = new System.Drawing.Size(255, 16);
            this.elementsTextBox.TabIndex = 17;
            this.elementsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementsTextBox_KeyPress);
            this.elementsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.elementsTextBox_Validating);
            this.elementsTextBox.Validated += new System.EventHandler(this.elementsTextBox_Validated);
            // 
            // sizeText
            // 
            this.rowsTextBox.Location = new System.Drawing.Point(133, 15);
            this.rowsTextBox.Name = "sizeText";
            this.rowsTextBox.Size = new System.Drawing.Size(56, 20);
            this.rowsTextBox.TabIndex = 16;
            this.rowsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rowsTextBox_KeyPress);
            this.rowsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.rowsTextBox_Validating);
            this.rowsTextBox.Validated += new System.EventHandler(this.rowsTextBox_Validated);
            // 
            // elementsLabel
            // 
            this.elementsLabel.AutoSize = true;
            this.elementsLabel.Location = new System.Drawing.Point(16, 56);
            this.elementsLabel.Name = "elementsLabel";
            this.elementsLabel.Size = new System.Drawing.Size(35, 13);
            this.elementsLabel.TabIndex = 15;
            this.elementsLabel.Text = "label1";
            // 
            // sizeLable
            // 
            this.rowsLable.AutoSize = true;
            this.rowsLable.Location = new System.Drawing.Point(16, 18);
            this.rowsLable.Name = "sizeLable";
            this.rowsLable.Size = new System.Drawing.Size(35, 13);
            this.rowsLable.TabIndex = 14;
            this.rowsLable.Text = "label1";
            // 
            // DlgJagged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 131);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.elementsTextBox);
            this.Controls.Add(this.rowsTextBox);
            this.Controls.Add(this.elementsLabel);
            this.Controls.Add(this.rowsLable);
            this.Name = "DlgJagged";
            this.Text = "DlgJagged";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox elementsTextBox;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.Label elementsLabel;
        private System.Windows.Forms.Label rowsLable;
    }
}