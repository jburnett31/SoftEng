namespace WindowsFormsApplication1
{
    partial class main_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_Form));
            this.file_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.help_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.quit_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.webcam_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.addWebcam_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.connect_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.webcam_Frame = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcam_Frame)).BeginInit();
            this.SuspendLayout();
            // 
            // file_Menu
            // 
            this.file_Menu.BackColor = System.Drawing.Color.Black;
            this.file_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help_Menu,
            this.quit_Menu,
            this.webcam_Menu});
            this.file_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.file_Menu.Name = "file_Menu";
            this.file_Menu.Size = new System.Drawing.Size(39, 20);
            this.file_Menu.Text = "File";
            // 
            // help_Menu
            // 
            this.help_Menu.BackColor = System.Drawing.Color.Black;
            this.help_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.help_Menu.Name = "help_Menu";
            this.help_Menu.Size = new System.Drawing.Size(166, 22);
            this.help_Menu.Text = "Help";
            // 
            // quit_Menu
            // 
            this.quit_Menu.BackColor = System.Drawing.Color.Black;
            this.quit_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quit_Menu.Name = "quit_Menu";
            this.quit_Menu.Size = new System.Drawing.Size(166, 22);
            this.quit_Menu.Text = "Quit";
            // 
            // webcam_Menu
            // 
            this.webcam_Menu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.webcam_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWebcam_Menu,
            this.connect_Menu});
            this.webcam_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.webcam_Menu.Name = "webcam_Menu";
            this.webcam_Menu.Size = new System.Drawing.Size(166, 22);
            this.webcam_Menu.Text = "Webcam Settings";
            // 
            // addWebcam_Menu
            // 
            this.addWebcam_Menu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addWebcam_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addWebcam_Menu.Name = "addWebcam_Menu";
            this.addWebcam_Menu.Size = new System.Drawing.Size(119, 22);
            // 
            // connect_Menu
            // 
            this.connect_Menu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.connect_Menu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.connect_Menu.Name = "connect_Menu";
            this.connect_Menu.Size = new System.Drawing.Size(119, 22);
            this.connect_Menu.Text = "Connect";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(454, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(583, 135);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 42);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(712, 135);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 42);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(16, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.addWebcamToolStripMenuItem.Click += new System.EventHandler(this.addWebcamToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Visible = false;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.webcam_Frame);
            this.panel1.Location = new System.Drawing.Point(189, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 491);
            this.panel1.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(280, 234);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 43);
            this.button4.TabIndex = 14;
            this.button4.Text = "Connect";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.addWebcamToolStripMenuItem_Click);
            // 
            // webcam_Frame
            // 
            this.webcam_Frame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webcam_Frame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("webcam_Frame.BackgroundImage")));
            this.webcam_Frame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.webcam_Frame.Location = new System.Drawing.Point(2, 0);
            this.webcam_Frame.Name = "webcam_Frame";
            this.webcam_Frame.Size = new System.Drawing.Size(641, 491);
            this.webcam_Frame.TabIndex = 13;
            this.webcam_Frame.TabStop = false;
            this.webcam_Frame.Click += new System.EventHandler(this.webcam_Frame_Click);
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1004, 683);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1024, 725);
            this.MinimumSize = new System.Drawing.Size(1024, 725);
            this.Name = "main_Form";
            this.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Text = "   YAMD Systems";
            this.Load += new System.EventHandler(this.main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webcam_Frame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem file_Menu;
        private System.Windows.Forms.ToolStripMenuItem help_Menu;
        private System.Windows.Forms.ToolStripMenuItem quit_Menu;
        private System.Windows.Forms.ToolStripMenuItem webcam_Menu;
        private System.Windows.Forms.ToolStripMenuItem addWebcam_Menu;
        private System.Windows.Forms.ToolStripMenuItem connect_Menu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webcamSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox webcam_Frame;
        private System.Windows.Forms.Button button4;

    }
}