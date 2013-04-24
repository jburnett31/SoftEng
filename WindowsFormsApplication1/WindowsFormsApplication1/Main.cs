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
        public VideoCaptureDevice cam = null;
        public FilterInfoCollection usbCam;
        public main_Form()
        {
            
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Really close this form?", string.Empty, MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                cam.Stop();
                Close();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            threshold_Settings_Form Threshold_Settings = new threshold_Settings_Form();
            Threshold_Settings.Show();
            this.Hide();
        }

        private void addWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usbCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo camera in usbCam)
            {
                MessageBox.Show(camera.Name);
            }
            if (usbCam.Count >= 1)
            {
                usbCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                cam = new VideoCaptureDevice(usbCam[1].MonikerString);

                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

                button4.Hide();

                cam.Start();
            }
            else
            {
                MessageBox.Show("YAMD cannot detect an available webcam. Please make sure that your device is property plugged into your computer and try again.");
            }
        }
        

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            webcam_Frame.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository_Settings repository_Settings = new Repository_Settings();
            repository_Settings.Show();
            this.Hide();
        }

        private void main_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cam.Stop();
            this.Close();
        }

        private void webcam_Frame_Click(object sender, EventArgs e)
        {

        }

        private void deadZoneButton_Click(object sender, EventArgs e)
        {
            DeadZoneForm deadZone_Settings = new DeadZoneForm();
            deadZone_Settings.Show();
            this.Hide();
        }
    }
}
