namespace Client_App
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageLabel = new System.Windows.Forms.GroupBox();
            this.messageValue = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.chatLabel = new System.Windows.Forms.GroupBox();
            this.chatValue = new System.Windows.Forms.ListBox();
            this.propertiesBox = new System.Windows.Forms.GroupBox();
            this.buffersizeValue = new System.Windows.Forms.TextBox();
            this.portValue = new System.Windows.Forms.TextBox();
            this.buffersizeLabel = new System.Windows.Forms.Label();
            this.leaveButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameValue = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipValue = new System.Windows.Forms.TextBox();
            this.messageLabel.SuspendLayout();
            this.chatLabel.SuspendLayout();
            this.propertiesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.Controls.Add(this.messageValue);
            this.messageLabel.Controls.Add(this.submitButton);
            this.messageLabel.Location = new System.Drawing.Point(12, 232);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(303, 50);
            this.messageLabel.TabIndex = 8;
            this.messageLabel.TabStop = false;
            this.messageLabel.Text = "Send message";
            // 
            // messageValue
            // 
            this.messageValue.Location = new System.Drawing.Point(6, 19);
            this.messageValue.Name = "messageValue";
            this.messageValue.PlaceholderText = "message...";
            this.messageValue.Size = new System.Drawing.Size(200, 23);
            this.messageValue.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(212, 19);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(85, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Send";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // chatLabel
            // 
            this.chatLabel.Controls.Add(this.chatValue);
            this.chatLabel.Location = new System.Drawing.Point(12, 5);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(303, 227);
            this.chatLabel.TabIndex = 10;
            this.chatLabel.TabStop = false;
            this.chatLabel.Text = "Chat";
            // 
            // chatValue
            // 
            this.chatValue.FormattingEnabled = true;
            this.chatValue.ItemHeight = 15;
            this.chatValue.Location = new System.Drawing.Point(6, 15);
            this.chatValue.Name = "chatValue";
            this.chatValue.Size = new System.Drawing.Size(291, 199);
            this.chatValue.TabIndex = 2;
            // 
            // propertiesBox
            // 
            this.propertiesBox.Controls.Add(this.buffersizeValue);
            this.propertiesBox.Controls.Add(this.portValue);
            this.propertiesBox.Controls.Add(this.buffersizeLabel);
            this.propertiesBox.Controls.Add(this.leaveButton);
            this.propertiesBox.Controls.Add(this.joinButton);
            this.propertiesBox.Controls.Add(this.usernameLabel);
            this.propertiesBox.Controls.Add(this.usernameValue);
            this.propertiesBox.Controls.Add(this.portLabel);
            this.propertiesBox.Controls.Add(this.ipLabel);
            this.propertiesBox.Controls.Add(this.ipValue);
            this.propertiesBox.Location = new System.Drawing.Point(321, 5);
            this.propertiesBox.Name = "propertiesBox";
            this.propertiesBox.Size = new System.Drawing.Size(196, 270);
            this.propertiesBox.TabIndex = 11;
            this.propertiesBox.TabStop = false;
            this.propertiesBox.Text = "Connect to Server";
            // 
            // buffersizeValue
            // 
            this.buffersizeValue.Location = new System.Drawing.Point(8, 171);
            this.buffersizeValue.Name = "buffersizeValue";
            this.buffersizeValue.Size = new System.Drawing.Size(181, 23);
            this.buffersizeValue.TabIndex = 18;
            this.buffersizeValue.Text = "1024";
            // 
            // portValue
            // 
            this.portValue.Location = new System.Drawing.Point(8, 125);
            this.portValue.Name = "portValue";
            this.portValue.Size = new System.Drawing.Size(181, 23);
            this.portValue.TabIndex = 17;
            this.portValue.Text = "80";
            // 
            // buffersizeLabel
            // 
            this.buffersizeLabel.AutoSize = true;
            this.buffersizeLabel.Location = new System.Drawing.Point(6, 151);
            this.buffersizeLabel.Name = "buffersizeLabel";
            this.buffersizeLabel.Size = new System.Drawing.Size(65, 15);
            this.buffersizeLabel.TabIndex = 16;
            this.buffersizeLabel.Text = "Buffer Size:";
            // 
            // leaveButton
            // 
            this.leaveButton.Location = new System.Drawing.Point(6, 227);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(183, 35);
            this.leaveButton.TabIndex = 15;
            this.leaveButton.Text = "Leave Server";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(7, 227);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(183, 35);
            this.joinButton.TabIndex = 6;
            this.joinButton.Text = "Join Server";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(7, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 15);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameValue
            // 
            this.usernameValue.Location = new System.Drawing.Point(7, 37);
            this.usernameValue.Name = "usernameValue";
            this.usernameValue.Size = new System.Drawing.Size(182, 23);
            this.usernameValue.TabIndex = 13;
            this.usernameValue.Text = "User";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(7, 107);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 15);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port:";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(6, 63);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(58, 15);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "IP Adress:";
            // 
            // ipValue
            // 
            this.ipValue.Location = new System.Drawing.Point(7, 81);
            this.ipValue.Name = "ipValue";
            this.ipValue.PlaceholderText = "8.8.8.8";
            this.ipValue.Size = new System.Drawing.Size(182, 23);
            this.ipValue.TabIndex = 0;
            this.ipValue.Text = "127.0.0.1";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 287);
            this.Controls.Add(this.propertiesBox);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.messageLabel);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.messageLabel.ResumeLayout(false);
            this.messageLabel.PerformLayout();
            this.chatLabel.ResumeLayout(false);
            this.propertiesBox.ResumeLayout(false);
            this.propertiesBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox messageLabel;
        private TextBox messageValue;
        private Button submitButton;
        private GroupBox chatLabel;
        private ListBox chatValue;
        private GroupBox propertiesBox;
        private Label ipLabel;
        private TextBox ipValue;
        private Button joinButton;
        private Button leaveButton;
        private Label usernameLabel;
        private TextBox usernameValue;
        private TextBox buffersizeValue;
        private TextBox portValue;
        private Label buffersizeLabel;
        private Label portLabel;
    }
}