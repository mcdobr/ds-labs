namespace CollabClient
{
    partial class ClientForm
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
            this.documentTextBox = new System.Windows.Forms.RichTextBox();
            this.documentBox = new System.Windows.Forms.GroupBox();
            this.paragraphTextBox = new System.Windows.Forms.RichTextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.paragraphBox = new System.Windows.Forms.GroupBox();
            this.documentBox.SuspendLayout();
            this.paragraphBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentTextBox
            // 
            this.documentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentTextBox.Location = new System.Drawing.Point(6, 19);
            this.documentTextBox.Name = "documentTextBox";
            this.documentTextBox.ReadOnly = true;
            this.documentTextBox.Size = new System.Drawing.Size(345, 516);
            this.documentTextBox.TabIndex = 2;
            this.documentTextBox.Text = "";
            // 
            // documentBox
            // 
            this.documentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentBox.Controls.Add(this.documentTextBox);
            this.documentBox.Location = new System.Drawing.Point(12, 20);
            this.documentBox.Name = "documentBox";
            this.documentBox.Size = new System.Drawing.Size(357, 541);
            this.documentBox.TabIndex = 3;
            this.documentBox.TabStop = false;
            this.documentBox.Text = "Document";
            // 
            // paragraphTextBox
            // 
            this.paragraphTextBox.Location = new System.Drawing.Point(6, 19);
            this.paragraphTextBox.Name = "paragraphTextBox";
            this.paragraphTextBox.Size = new System.Drawing.Size(340, 481);
            this.paragraphTextBox.TabIndex = 0;
            this.paragraphTextBox.Text = "";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(250, 506);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(75, 23);
            this.commitButton.TabIndex = 1;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // paragraphBox
            // 
            this.paragraphBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paragraphBox.Controls.Add(this.commitButton);
            this.paragraphBox.Controls.Add(this.paragraphTextBox);
            this.paragraphBox.Location = new System.Drawing.Point(377, 20);
            this.paragraphBox.Name = "paragraphBox";
            this.paragraphBox.Size = new System.Drawing.Size(352, 541);
            this.paragraphBox.TabIndex = 4;
            this.paragraphBox.TabStop = false;
            this.paragraphBox.Text = "Paragraph";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 571);
            this.Controls.Add(this.paragraphBox);
            this.Controls.Add(this.documentBox);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.documentBox.ResumeLayout(false);
            this.paragraphBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox documentTextBox;
        private System.Windows.Forms.GroupBox documentBox;
        private System.Windows.Forms.RichTextBox paragraphTextBox;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.GroupBox paragraphBox;
    }
}

