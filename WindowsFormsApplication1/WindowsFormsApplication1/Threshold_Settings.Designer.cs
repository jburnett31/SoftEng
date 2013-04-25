namespace WindowsFormsApplication1
{
    partial class threshold_Settings_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(threshold_Settings_Form));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.low_Threshold_Tab = new System.Windows.Forms.TabPage();
            this.sensitivityBar_Low = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.med_Threshold_Tab = new System.Windows.Forms.TabPage();
            this.high_Threshold_Tab = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durationBar_Low = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.low_Threshold_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityBar_Low)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationBar_Low)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 691);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(463, 647);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 30);
            this.button4.TabIndex = 15;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(721, 135);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 42);
            this.button5.TabIndex = 14;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(850, 135);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 43);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(592, 135);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 43);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(463, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 43);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.low_Threshold_Tab);
            this.tabControl1.Controls.Add(this.med_Threshold_Tab);
            this.tabControl1.Controls.Add(this.high_Threshold_Tab);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(57, 181);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 447);
            this.tabControl1.TabIndex = 3;
            // 
            // low_Threshold_Tab
            // 
            this.low_Threshold_Tab.BackColor = System.Drawing.Color.DimGray;
            this.low_Threshold_Tab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("low_Threshold_Tab.BackgroundImage")));
            this.low_Threshold_Tab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.low_Threshold_Tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.low_Threshold_Tab.Controls.Add(this.durationBar_Low);
            this.low_Threshold_Tab.Controls.Add(this.sensitivityBar_Low);
            this.low_Threshold_Tab.Controls.Add(this.label1);
            this.low_Threshold_Tab.Location = new System.Drawing.Point(4, 27);
            this.low_Threshold_Tab.Margin = new System.Windows.Forms.Padding(0);
            this.low_Threshold_Tab.Name = "low_Threshold_Tab";
            this.low_Threshold_Tab.Size = new System.Drawing.Size(885, 416);
            this.low_Threshold_Tab.TabIndex = 0;
            this.low_Threshold_Tab.Text = "Low Threshold";
            // 
            // sensitivityBar_Low
            // 
            this.sensitivityBar_Low.BackColor = System.Drawing.Color.Gainsboro;
            this.sensitivityBar_Low.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sensitivityBar_Low.Location = new System.Drawing.Point(442, 112);
            this.sensitivityBar_Low.Name = "sensitivityBar_Low";
            this.sensitivityBar_Low.Size = new System.Drawing.Size(217, 45);
            this.sensitivityBar_Low.TabIndex = 1;
            this.sensitivityBar_Low.TickFrequency = 2;
            this.sensitivityBar_Low.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(122, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please specify your low threshold values.";
            // 
            // med_Threshold_Tab
            // 
            this.med_Threshold_Tab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("med_Threshold_Tab.BackgroundImage")));
            this.med_Threshold_Tab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.med_Threshold_Tab.Location = new System.Drawing.Point(4, 27);
            this.med_Threshold_Tab.Margin = new System.Windows.Forms.Padding(0);
            this.med_Threshold_Tab.Name = "med_Threshold_Tab";
            this.med_Threshold_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.med_Threshold_Tab.Size = new System.Drawing.Size(885, 416);
            this.med_Threshold_Tab.TabIndex = 1;
            this.med_Threshold_Tab.Text = "Medium Threshold";
            this.med_Threshold_Tab.UseVisualStyleBackColor = true;
            // 
            // high_Threshold_Tab
            // 
            this.high_Threshold_Tab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("high_Threshold_Tab.BackgroundImage")));
            this.high_Threshold_Tab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.high_Threshold_Tab.Location = new System.Drawing.Point(4, 27);
            this.high_Threshold_Tab.Name = "high_Threshold_Tab";
            this.high_Threshold_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.high_Threshold_Tab.Size = new System.Drawing.Size(885, 416);
            this.high_Threshold_Tab.TabIndex = 2;
            this.high_Threshold_Tab.Text = "High Threshold";
            this.high_Threshold_Tab.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InfoText;
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // durationBar_Low
            // 
            this.durationBar_Low.BackColor = System.Drawing.Color.Gainsboro;
            this.durationBar_Low.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.durationBar_Low.Location = new System.Drawing.Point(442, 300);
            this.durationBar_Low.Name = "durationBar_Low";
            this.durationBar_Low.Size = new System.Drawing.Size(217, 45);
            this.durationBar_Low.TabIndex = 2;
            // 
            // threshold_Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1004, 683);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1024, 725);
            this.MinimumSize = new System.Drawing.Size(1024, 725);
            this.Name = "threshold_Settings_Form";
            this.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Threshold Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.button1_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.low_Threshold_Tab.ResumeLayout(false);
            this.low_Threshold_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityBar_Low)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationBar_Low)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage low_Threshold_Tab;
        private System.Windows.Forms.TabPage med_Threshold_Tab;
        private System.Windows.Forms.TabPage high_Threshold_Tab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar sensitivityBar_Low;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar durationBar_Low;
    }
}

