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
    public partial class threshold_Settings_Form : Form
    {
        public threshold_Settings_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void low_Tab_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void low_Tab_Click_1(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            threshold_Settings_Form threshold_Settings = new threshold_Settings_Form();
            threshold_Settings.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository_Settings repository_Settings = new Repository_Settings();
            repository_Settings.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deadzone_Settings deadzone_Settings = new Deadzone_Settings();
            deadzone_Settings.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
