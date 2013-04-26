namespace WindowsFormsApplication1
{
    partial class Deadzone_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deadzone_Settings));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.screen = new System.Windows.Forms.PictureBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tempLabel = new System.Windows.Forms.Label();
            this.zoneMaskPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(843, 137);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 42);
            this.button3.TabIndex = 14;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(585, 137);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 42);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(456, 137);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webcamSettingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // webcamSettingsToolStripMenuItem
            // 
            this.webcamSettingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.webcamSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWebcamToolStripMenuItem});
            this.webcamSettingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.webcamSettingsToolStripMenuItem.Name = "webcamSettingsToolStripMenuItem";
            this.webcamSettingsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.webcamSettingsToolStripMenuItem.Text = "Webcam Settings";
            // 
            // addWebcamToolStripMenuItem
            // 
            this.addWebcamToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addWebcamToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addWebcamToolStripMenuItem.Name = "addWebcamToolStripMenuItem";
            this.addWebcamToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addWebcamToolStripMenuItem.Text = "Add Webcam";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Visible = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(846, 340);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(155, 52);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Add a Deadzone";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(846, 456);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(155, 52);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(846, 398);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(155, 52);
            this.removeButton.TabIndex = 18;
            this.removeButton.Text = "Remove a Deadzone";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // screen
            // 
            this.screen.Location = new System.Drawing.Point(160, 200);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(641, 475);
            this.screen.TabIndex = 19;
            this.screen.TabStop = false;
            this.screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screen_MouseDown);
            // 
            // captureButton
            // 
            this.captureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.captureButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.captureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureButton.Location = new System.Drawing.Point(846, 253);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(155, 81);
            this.captureButton.TabIndex = 17;
            this.captureButton.Text = "Capture Image";
            this.captureButton.UseVisualStyleBackColor = false;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(714, 137);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 42);
            this.button7.TabIndex = 22;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tempLabel
            // 
            this.tempLabel.Location = new System.Drawing.Point(849, 200);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(147, 50);
            this.tempLabel.TabIndex = 23;
            this.tempLabel.Text = "This text should change...";
            // 
            // zoneMaskPanel
            // 
            this.zoneMaskPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zoneMaskPanel.Location = new System.Drawing.Point(160, 200);
            this.zoneMaskPanel.Name = "zoneMaskPanel";
            this.zoneMaskPanel.Size = new System.Drawing.Size(86, 70);
            this.zoneMaskPanel.TabIndex = 24;
            this.zoneMaskPanel.Visible = false;
            // 
            // Deadzone_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 687);
            this.Controls.Add(this.zoneMaskPanel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Deadzone_Settings";
            this.Text = "Deadzone Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.quit_Form);
            this.Load += new System.EventHandler(this.Deadzone_Settings_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webcamSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Panel zoneMaskPanel;
    }
}