namespace Lab7
{
    partial class DlgArray
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
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.elementsLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(218, 95);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(39, 95);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 25);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // elementsText
            // 
            this.elementsTextBox.Location = new System.Drawing.Point(133, 58);
            this.elementsTextBox.Multiline = true;
            this.elementsTextBox.Name = "elementsText";
            this.elementsTextBox.Size = new System.Drawing.Size(245, 16);
            this.elementsTextBox.TabIndex = 17;
            this.elementsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementsTextBox_KeyPress);
            this.elementsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.elementsTextBox_Validating);
            this.elementsTextBox.Validated += new System.EventHandler(this.elementsTextBox_Validated);
            // 
            // sizeText
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(133, 20);
            this.lengthTextBox.Name = "sizeText";
            this.lengthTextBox.Size = new System.Drawing.Size(56, 20);
            this.lengthTextBox.TabIndex = 16;
            this.lengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lengthTextBox_KeyPress);
            this.lengthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lengthTextBox_Validating);
            this.lengthTextBox.Validated += new System.EventHandler(this.lengthTextBox_Validated);
            // 
            // elementsLabel
            // 
            this.elementsLabel.AutoSize = true;
            this.elementsLabel.Location = new System.Drawing.Point(16, 61);
            this.elementsLabel.Name = "elementsLabel";
            this.elementsLabel.Size = new System.Drawing.Size(35, 13);
            this.elementsLabel.TabIndex = 15;
            this.elementsLabel.Text = "label1";
            // 
            // sizeLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(16, 23);
            this.lengthLabel.Name = "sizeLabel";
            this.lengthLabel.Size = new System.Drawing.Size(35, 13);
            this.lengthLabel.TabIndex = 14;
            this.lengthLabel.Text = "label1";
            // 
            // DlgArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 141);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.elementsTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.elementsLabel);
            this.Controls.Add(this.lengthLabel);
            this.Name = "DlgArray";
            this.Text = "DlgArray";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox elementsTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label elementsLabel;
        private System.Windows.Forms.Label lengthLabel;
    }
}