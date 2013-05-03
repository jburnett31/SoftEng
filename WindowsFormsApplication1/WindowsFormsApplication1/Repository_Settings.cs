using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Repository_Settings : Form
    {
        public Repository_Settings()
        {
            InitializeComponent();
        }

        private void repository_Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            threshold_Settings_Form Threshold_Settings = new threshold_Settings_Form();
            Threshold_Settings.Show();
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void repository_Button_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deadzone_Settings deadzone_Settings = new Deadzone_Settings();
            deadzone_Settings.Show();
            this.Hide();
        }
    }
}
