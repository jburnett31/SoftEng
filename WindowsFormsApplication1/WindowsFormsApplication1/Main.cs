using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApplication1
{
    public partial class main_Form : Form
    {
        public main_Form()
        {
            
            InitializeComponent();

        }

        VideoCaptureDevice cam;

        private void button4_Click(object sender, System.EventArgs e)
        {
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int i = new int();
            for (i = 0; i < devices.Count; i++)
            {
                try
                {
                    cam = new VideoCaptureDevice(devices[i].MonikerString);
                    break;
                }
                catch
                {
                }
            }

             cam.NewFrame += new AForge.Video.NewFrameEventHandler(cam_NewFrame);

             button4.Hide();
             label3.Hide();
             label4.Hide();
             label1.Show();
             label5.Hide();

             cam.Start();
        }

        void cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            webcam_Frame.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = (MessageBox.Show("Are you sure you want to quit? YAMD will no longer be monitoring after closing.", " ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning));
                if (result == DialogResult.Yes)
                {
                    label1.Hide();
                    label3.Show();

                    if (cam != null && cam.IsRunning)
                    {
                        cam.SignalToStop();
                        cam = null;
                    }
                }
                else if (result == DialogResult.No)
                {
                    
                }

            }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add help resources 
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            threshold_Settings_Form Threshold_Settings = new threshold_Settings_Form();
            Threshold_Settings.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository_Settings repository_Settings = new Repository_Settings();
            repository_Settings.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deadzone_Settings deadzone_Settings = new Deadzone_Settings();
            deadzone_Settings.Show();
        }

        private void main_Form_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label3.Show();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = (MessageBox.Show("Are you sure you want to quit? YAMD will no longer be monitoring after closing.", " ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning));
            if (result == DialogResult.Yes)
            {
                //label1.Hide();
                //label3.Show();
                cam.SignalToStop();
                cam = null;
                Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }

        }
    }
}
