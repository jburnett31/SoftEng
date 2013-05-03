using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using UserSettingsDemo.Properties;

namespace WindowsFormsApplication1
{
    public partial class email_Settings_Form : Form
    {
        public email_Settings_Form()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
            this.Close();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository_Settings repository_Settings = new Repository_Settings();
            repository_Settings.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            threshold_Settings_Form threshold_Settings = new threshold_Settings_Form();
            threshold_Settings.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Deadzone_Settings deadzone_Settings = new Deadzone_Settings();
            deadzone_Settings.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.textBox1 = null;
        }


    }
}
