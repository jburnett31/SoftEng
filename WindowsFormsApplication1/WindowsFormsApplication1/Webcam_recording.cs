using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApplication1
{
    public partial class Webcam_recording : Form
    {

        public Webcam_recording() // init
        {
            InitializeComponent();
        }
        VideoCaptureDevice webcam;

        private void Webcam_recording_Load(object sender, System.EventArgs e)
        {
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (devices != null)
            {
                webcam = new VideoCaptureDevice(devices[0].MonikerString);

                try
                {
                    if (webcam.VideoCapabilities.Length > 0)
                    {
                        string bestResolution = "0;0";
                        for (int i = 0; i < webcam.VideoCapabilities.Length; i++)
                        {
                            if (webcam.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(bestResolution.Split(';')[0]))
                                bestResolution = webcam.VideoCapabilities[i].FrameSize.Width.ToString() + "i" + i.ToString();
                        }

                        webcam.DesiredFrameSize = webcam.VideoCapabilities[Convert.ToInt32(bestResolution.Split(';')[1])].FrameSize;
                    }
                }
                catch { }

                webcam.NewFrame += new AForge.Video.NewFrameEventHandler(cam_NewFrame);

                webcam.Start();
            }
        }

        void cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pictureBox1.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Webcam_recording_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (webcam != null && webcam.IsRunning)
            {
                webcam.SignalToStop();
                webcam = null;
            }
        }
    }
}
