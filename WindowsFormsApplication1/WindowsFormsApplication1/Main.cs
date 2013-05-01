using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;

using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApplication1
{
    public partial class main_Form : Form
    {
        public Emailer mailMan;

        public main_Form()
        {
            
            InitializeComponent();
            mailMan = new WindowsFormsApplication1.Emailer();
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
            //this is where the YAMDDetector needs to be created
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

        private void sendNotification()
        {
            mailMan.sendNotification(DateTime.Today, DateTime.Now, "image.jpg", "Magnitude");
            // replace image.jpg with whatever the actual name of the jpg file is
        }

        private void sendToDropbox()
        {
            // replace string with whatever the actual name of the video file is
            mailMan.sendToDropbox("C:\\Users\\Rachel\\Desktop\\Movies\\ButterflyMovie.wlmp");
        }
    }

    public class Emailer
    {
        MailAddress dropbox = new MailAddress("yamd_fbc7@sendtodropbox.com", "YAMD");
        const string sendersPassword = "d0n0tsh@r3";
        const string senderAddress = "yamdmotiondetection@gmail.com";
        MailAddress sender = new MailAddress(senderAddress, "YAMD Software");
        MailAddress recipient;
        const string videoLink = "https://www.dropbox.com/sh/opu4kl7ayidvyic/EZAl1kEbTZ";

        public Emailer()
        {
            recipient = new MailAddress("yamdmotiondetection@gmail.com");
        }

        public Emailer(string recipientAddress)
        {
            recipient = new MailAddress(recipientAddress);
        }

        public void setRecipient(string recipientAddress)
        {
            recipient = new MailAddress(recipientAddress);
        }

        public void sendNotification(DateTime beginTime, DateTime endTime,
                                    string imageLocation, string magnitudeLevel)
        {

            string subject = magnitudeLevel + "-level Event Detected";
            string body = "Beginning at " + beginTime.ToString("T") + " on " + beginTime.ToString("yyyy-M-d")
                + ", YAMD detected motion for " + endTime.Subtract(beginTime).ToString() + " ending at " + endTime.ToString("T")
                + ". See the attachment for an image taken at the beginning of the event.\n"
                + "\n\nFollow this link to watch the video captured:\n" + videoLink;

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress, sendersPassword),
                    Timeout = 20000
                };
                MailMessage message = new MailMessage(sender, recipient);

                message.Subject = subject;
                message.Body = body;
                Attachment attachment = new Attachment(imageLocation);

                message.Attachments.Add(attachment);
                smtp.Send(message);
                Console.WriteLine("Message Sent Successfully");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(SmtpDeliveryMethod.Network.ToString());
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void sendToDropbox(string videoLocation)
        {
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderAddress, sendersPassword),
                    Timeout = 20000
                };
                MailMessage message = new MailMessage(sender, dropbox);
                Attachment attachment = new Attachment(videoLocation);

                message.Attachments.Add(attachment);
                smtp.Send(message);
                Console.WriteLine("Message Sent Successfully");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(SmtpDeliveryMethod.Network.ToString());
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
