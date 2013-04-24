namespace WindowsFormsApplication1
{
    partial class DeadZoneForm
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
            this.screen = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.screen.Location = new System.Drawing.Point(12, 12);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(189, 240);
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            this.screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screen_MouseDown);
            this.screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screen_MouseUp);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(207, 24);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 39);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add a Dead Zone";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseDown);
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(204, 66);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(226, 13);
            this.addLabel.TabIndex = 2;
            this.addLabel.Text = "This should display when the button is clicked.";
            this.addLabel.Visible = false;
            this.addLabel.Click += new System.EventHandler(this.addLabel_Click);
            // 
            // DeadZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.screen);
            this.Name = "DeadZoneForm";
            this.Text = "DeadZoneForm";
            this.Load += new System.EventHandler(this.DeadZoneForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label addLabel;
    }
}