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
            this.elementsText = new System.Windows.Forms.TextBox();
            this.sizeText = new System.Windows.Forms.TextBox();
            this.elementsLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
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
            this.elementsText.Location = new System.Drawing.Point(133, 58);
            this.elementsText.Multiline = true;
            this.elementsText.Name = "elementsText";
            this.elementsText.Size = new System.Drawing.Size(255, 16);
            this.elementsText.TabIndex = 17;
            this.elementsText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementsText_KeyPress);
            this.elementsText.Validating += new System.ComponentModel.CancelEventHandler(this.elementsText_Validating);
            this.elementsText.Validated += new System.EventHandler(this.elementsText_Validated);
            // 
            // sizeText
            // 
            this.sizeText.Location = new System.Drawing.Point(133, 20);
            this.sizeText.Name = "sizeText";
            this.sizeText.Size = new System.Drawing.Size(56, 20);
            this.sizeText.TabIndex = 16;
            this.sizeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeText_KeyPress);
            this.sizeText.Validating += new System.ComponentModel.CancelEventHandler(this.sizeText_Validating);
            this.sizeText.Validated += new System.EventHandler(this.sizeText_Validated);
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
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(16, 23);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(35, 13);
            this.sizeLabel.TabIndex = 14;
            this.sizeLabel.Text = "label1";
            // 
            // DlgArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 141);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.elementsText);
            this.Controls.Add(this.sizeText);
            this.Controls.Add(this.elementsLabel);
            this.Controls.Add(this.sizeLabel);
            this.Name = "DlgArray";
            this.Text = "DlgArray";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox elementsText;
        private System.Windows.Forms.TextBox sizeText;
        private System.Windows.Forms.Label elementsLabel;
        private System.Windows.Forms.Label sizeLabel;
    }
}