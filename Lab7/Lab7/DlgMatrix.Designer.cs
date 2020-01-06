namespace Lab7
{
    partial class DlgMatrix
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
            this.size2Text = new System.Windows.Forms.TextBox();
            this.size2Label = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.elementsText = new System.Windows.Forms.TextBox();
            this.sizeText = new System.Windows.Forms.TextBox();
            this.elementsLabel = new System.Windows.Forms.Label();
            this.sizeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // size2Text
            // 
            this.size2Text.Location = new System.Drawing.Point(332, 15);
            this.size2Text.Name = "size2Text";
            this.size2Text.Size = new System.Drawing.Size(56, 20);
            this.size2Text.TabIndex = 23;
            this.size2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.size2Text_KeyPress);
            this.size2Text.Validating += new System.ComponentModel.CancelEventHandler(this.size2Text_Validating);
            this.size2Text.Validated += new System.EventHandler(this.size2Text_Validated);
            // 
            // size2Label
            // 
            this.size2Label.AutoSize = true;
            this.size2Label.Location = new System.Drawing.Point(215, 18);
            this.size2Label.Name = "size2Label";
            this.size2Label.Size = new System.Drawing.Size(35, 13);
            this.size2Label.TabIndex = 22;
            this.size2Label.Text = "label1";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(218, 90);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 25);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(39, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 25);
            this.okButton.TabIndex = 20;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // elementsText
            // 
            this.elementsText.Location = new System.Drawing.Point(133, 53);
            this.elementsText.Multiline = true;
            this.elementsText.Name = "elementsText";
            this.elementsText.Size = new System.Drawing.Size(255, 16);
            this.elementsText.TabIndex = 19;
            this.elementsText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.elementsText_KeyPress);
            this.elementsText.Validating += new System.ComponentModel.CancelEventHandler(this.elementsText_Validating);
            this.elementsText.Validated += new System.EventHandler(this.elementsText_Validated);
            // 
            // sizeText
            // 
            this.sizeText.Location = new System.Drawing.Point(133, 15);
            this.sizeText.Name = "sizeText";
            this.sizeText.Size = new System.Drawing.Size(56, 20);
            this.sizeText.TabIndex = 18;
            this.sizeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeText_KeyPress);
            this.sizeText.Validating += new System.ComponentModel.CancelEventHandler(this.sizeText_Validating);
            this.sizeText.Validated += new System.EventHandler(this.sizeText_Validated);
            // 
            // elementsLabel
            // 
            this.elementsLabel.AutoSize = true;
            this.elementsLabel.Location = new System.Drawing.Point(16, 56);
            this.elementsLabel.Name = "elementsLabel";
            this.elementsLabel.Size = new System.Drawing.Size(35, 13);
            this.elementsLabel.TabIndex = 17;
            this.elementsLabel.Text = "label1";
            // 
            // sizeLable
            // 
            this.sizeLable.AutoSize = true;
            this.sizeLable.Location = new System.Drawing.Point(16, 18);
            this.sizeLable.Name = "sizeLable";
            this.sizeLable.Size = new System.Drawing.Size(35, 13);
            this.sizeLable.TabIndex = 16;
            this.sizeLable.Text = "label1";
            // 
            // DlgMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 131);
            this.Controls.Add(this.size2Text);
            this.Controls.Add(this.size2Label);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.elementsText);
            this.Controls.Add(this.sizeText);
            this.Controls.Add(this.elementsLabel);
            this.Controls.Add(this.sizeLable);
            this.Name = "DlgMatrix";
            this.Text = "DlgMatrix";
            this.Load += new System.EventHandler(this.DlgMatrix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox size2Text;
        private System.Windows.Forms.Label size2Label;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox elementsText;
        private System.Windows.Forms.TextBox sizeText;
        private System.Windows.Forms.Label elementsLabel;
        private System.Windows.Forms.Label sizeLable;
    }
}