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
    public partial class Form1 : Form
    {
        public VideoCaptureDevice cam = null;
        public FilterInfoCollection usbCam;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        private void Form1_Load(object sender, EventArgs e)
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
                MessageBox.Show("YAMD cannot detect an available webcam. Please make sure that your device is property plugged into your computer and try again");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // pictureBox1.Image = (Bitmap)cam.SnapshotFr
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
        }
    }
}
