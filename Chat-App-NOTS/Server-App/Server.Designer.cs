namespace Server_App
{
    partial class Server
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
            this.propertiesBox = new System.Windows.Forms.GroupBox();
            this.buffersizeValue = new System.Windows.Forms.TextBox();
            this.portValue = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.buffersizeLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipValue = new System.Windows.Forms.TextBox();
            this.chatValue = new System.Windows.Forms.ListBox();
            this.chatLabel = new System.Windows.Forms.GroupBox();
            this.propertiesBox.SuspendLayout();
            this.chatLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertiesBox
            // 
            this.propertiesBox.Controls.Add(this.buffersizeValue);
            this.propertiesBox.Controls.Add(this.portValue);
            this.propertiesBox.Controls.Add(this.stopButton);
            this.propertiesBox.Controls.Add(this.startButton);
            this.propertiesBox.Controls.Add(this.buffersizeLabel);
            this.propertiesBox.Controls.Add(this.portLabel);
            this.propertiesBox.Controls.Add(this.ipLabel);
            this.propertiesBox.Controls.Add(this.ipValue);
            this.propertiesBox.Location = new System.Drawing.Point(321, 12);
            this.propertiesBox.Name = "propertiesBox";
            this.propertiesBox.Size = new System.Drawing.Size(196, 214);
            this.propertiesBox.TabIndex = 0;
            this.propertiesBox.TabStop = false;
            this.propertiesBox.Text = "Server Properties";
            // 
            // buffersizeValue
            // 
            this.buffersizeValue.Location = new System.Drawing.Point(7, 127);
            this.buffersizeValue.Name = "buffersizeValue";
            this.buffersizeValue.Size = new System.Drawing.Size(183, 23);
            this.buffersizeValue.TabIndex = 11;
            this.buffersizeValue.Text = "1024";
            // 
            // portValue
            // 
            this.portValue.Location = new System.Drawing.Point(7, 81);
            this.portValue.Name = "portValue";
            this.portValue.Size = new System.Drawing.Size(183, 23);
            this.portValue.TabIndex = 10;
            this.portValue.Text = "80";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(7, 173);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(184, 35);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop Server";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(7, 173);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(184, 35);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start Server";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // buffersizeLabel
            // 
            this.buffersizeLabel.AutoSize = true;
            this.buffersizeLabel.Location = new System.Drawing.Point(5, 107);
            this.buffersizeLabel.Name = "buffersizeLabel";
            this.buffersizeLabel.Size = new System.Drawing.Size(65, 15);
            this.buffersizeLabel.TabIndex = 5;
            this.buffersizeLabel.Text = "Buffer Size:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(7, 63);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 15);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port:";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(6, 19);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(58, 15);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "IP Adress:";
            // 
            // ipValue
            // 
            this.ipValue.Location = new System.Drawing.Point(7, 37);
            this.ipValue.Name = "ipValue";
            this.ipValue.PlaceholderText = "8.8.8.8";
            this.ipValue.Size = new System.Drawing.Size(183, 23);
            this.ipValue.TabIndex = 0;
            this.ipValue.Text = "127.0.0.1";
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
            // chatLabel
            // 
            this.chatLabel.Controls.Add(this.chatValue);
            this.chatLabel.Location = new System.Drawing.Point(12, 12);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(303, 220);
            this.chatLabel.TabIndex = 7;
            this.chatLabel.TabStop = false;
            this.chatLabel.Text = "Chat";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 242);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.propertiesBox);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.propertiesBox.ResumeLayout(false);
            this.propertiesBox.PerformLayout();
            this.chatLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox propertiesBox;
        private Label portLabel;
        private Label ipLabel;
        private TextBox ipValue;
        private ListBox chatValue;
        private Label buffersizeLabel;
        private Button startButton;
        private GroupBox chatLabel;
        private Button stopButton;
        private TextBox buffersizeValue;
        private TextBox portValue;
    }
}