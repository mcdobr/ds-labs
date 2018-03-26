namespace ChatClient
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
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.userGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 12);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(400, 215);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(12, 233);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(400, 116);
            this.messageBox.TabIndex = 1;
            this.messageBox.Text = "";
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.connectButton);
            this.userGroupBox.Controls.Add(this.userBox);
            this.userGroupBox.Controls.Add(this.userLabel);
            this.userGroupBox.Location = new System.Drawing.Point(418, 12);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(154, 86);
            this.userGroupBox.TabIndex = 2;
            this.userGroupBox.TabStop = false;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(62, 55);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(54, 29);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(83, 20);
            this.userBox.TabIndex = 1;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(21, 29);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(27, 13);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "user";
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(418, 233);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(154, 116);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.userGroupBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.chatBox);
            this.Name = "ClientForm";
            this.Text = "Chat Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button sendButton;
    }
}

