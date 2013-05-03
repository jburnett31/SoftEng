using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

using AForge.Video;
using AForge.Video.DirectShow;


using System.Threading;
using AForge.Vision.Motion;
using AForge.Video.VFW;
using AForge.Video.FFMPEG;
using System.Diagnostics;

using System.Collections.Concurrent;

namespace WindowsFormsApplication1
{
    public partial class main_Form : Form
    {
        public Emailer mailMan;
        public YAMDDetector detector;
        public Magnitude low;
        public Magnitude medium;
        public Magnitude high;

        public main_Form()
        {
            
            InitializeComponent();
            mailMan = new WindowsFormsApplication1.Emailer();
            low = new Magnitude(Level.Low, (long).1, 1);
            medium = new Magnitude(Level.Medium, (long).2, 2);
            high = new Magnitude(Level.High, (long).3, 3);
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
            detector = new YAMDDetector(cam, low, medium, high);
            detector.RaiseMotionEvent += sendNotification();
            detector.RaiseMotionEvent += sendToDropbox();
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

        //******************************** MOTION EVENT HANDLER METHODS ******************************

        private void sendNotification(object sender, MotionEventArgs e)
        {
            Bitmap image = e.Screenshot;
            //save the image
            mailMan.sendNotification(e.StartTime, e.EndTime, image, e.Severity.ToString());
            // replace image.jpg with whatever the actual name of the jpg file is
        }

        private void sendToDropbox(object sender, MotionEventArgs e)
        {
            // replace string with whatever the actual name of the video file is
            mailMan.sendToDropbox(e.VideoName);
        }
    }

    //************************************* MOTION EVENT ARGS *****************************************

    public class MotionEventArgs : EventArgs
    {
        public Magnitude Severity
        { get; set; }
        public String VideoName
        { get; set; }
        public Bitmap Screenshot
        { get; set; }
        public DateTime StartTime
        { get; set; }
        public DateTime EndTime
        { get; set; }

        public MotionEventArgs(Magnitude m, String name, ref Bitmap image, DateTime startTime, DateTime endTime)
        {
            Severity = m;
            VideoName = name;
            Screenshot = image;
            StartTime = startTime;
            EndTime = EndTime;

        }
    }


    //************************************* MAGNITUDE *************************************************
    public enum Level { Low, Medium, High };

    public class Magnitude
    {
        private Level severity;
        // duration should be in milliseconds to avoid floating point comparisons
        private long duration;
        private int sensitivity;
        public Level Severity
        { get { return severity; } }
        public long Duration
        { get { return duration; } }
        public int Sensitivity
        { get { return sensitivity; } }

        public Magnitude(Level severity, long duration, int sensitivity)
        {
            this.severity = severity;
            this.duration = duration;
            this.sensitivity = sensitivity;
        }

        public override string ToString()
        {
            string[] levels = { "Low", "Medium", "High" };
            return levels[(int)Severity];
        }
    }


    //************************************* EMAIL CLASS ************************************************
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
                                    Bitmap image, string magnitudeLevel)
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

                MemoryStream memStream = new MemoryStream();
                image.Save(memStream, ImageFormat.Jpeg);

                ContentType contentType = new ContentType();
                contentType.MediaType = MediaTypeNames.Image.Jpeg;
                contentType.Name = "image";

                Attachment attachment = new Attachment(memStream, contentType);

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




    // yamdmotiondetection@gmail.com
    // d0n0tsh@r3
    public class YAMDDetector
    {
        MotionDetector detector;
        AsyncVideoSource inputStream;
        Stopwatch timer;
        Stopwatch stoptimer;
        const int stopCondition = 5000;
        VideoFileWriter videoRecorder;
        FixedSizeQueue<Bitmap> buffer;
        public bool Running
        { get; set; }
        public bool Recording
        { get; set; }
        Magnitude low, medium, high;
        public double Timeout
        { get; set; }
        private Bitmap screenshot;
        private String filename;
        Queue<int> magnitudes;
        int videoMagnitude;
        bool gotMagnitude;
        DateTime startTime;

        // event handler
        public delegate void MotionEventHandler(object sender, MotionEventArgs a);
        public event MotionEventHandler RaiseMotionEvent;

        public YAMDDetector(IVideoSource source, Magnitude low, Magnitude medium, Magnitude high)
        {
            detector = new MotionDetector(
                new SimpleBackgroundModelingDetector(),
                new BlobCountingObjectsProcessing(true));
            //async video source processes images in a separate thread and uses the NewFrame event
            inputStream = new AsyncVideoSource(source);
            inputStream.NewFrame += inputStream_NewFrame;
            this.low = low;
            this.medium = medium;
            this.high = high;
            timer = new Stopwatch();
            stoptimer = new Stopwatch();
            videoRecorder = new VideoFileWriter();
            Running = false;
            buffer = new FixedSizeQueue<Bitmap>();
            buffer.Limit = 50;
            magnitudes = new Queue<int>();
        }

        ~YAMDDetector()
        {

        }

        public void setMotionZones(Rectangle[] mzs)
        {
            detector.MotionZones = mzs;
        }

        public void Start()
        {
            Running = true;
            inputStream.Start();
        }

        public void Stop()
        {
            videoRecorder.Close();
            Running = false;
            inputStream.Stop();
        }

        public void StartRecording(String name)
        {
            String videoName = name;
            consBuffer();
            Recording = true;
            startTime = DateTime.Now;
        }

        public void StopRecording()
        {
            Recording = false;
        }

        private void consBuffer()
        {
            for (int i = 0; i < buffer.Size(); i++)
            {
                Bitmap img = buffer.Dequeue();
                videoRecorder.WriteVideoFrame(img);
            }
        }

        protected void OnMotionEvent(MotionEventArgs e)
        {
            MotionEventHandler handler = RaiseMotionEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void inputStream_NewFrame(object sender, NewFrameEventArgs e)
        {
            lock (this)
            {
                
                Bitmap image = e.Frame;
                Magnitude m = null;
                float motionLevel = detector.ProcessFrame(image);
                int level = (int)Math.Floor(motionLevel * 100);

                if (level >= high.Sensitivity)
                {
                    m = high;
                    magnitudes.Enqueue(3);
                }
                else if (level >= medium.Sensitivity)
                {
                    m = medium;
                    magnitudes.Enqueue(2);
                }
                else if (level >= low.Sensitivity)
                {
                    m = low;
                    magnitudes.Enqueue(1);
                }
                else
                    magnitudes.Enqueue(0);

                if (Recording)
                {
                    videoRecorder.WriteVideoFrame(image);
                }
                if (m != null && !Recording)
                {
                    screenshot = image;
                    stoptimer.Reset();
                    gotMagnitude = false;
                    timer.Start();
                    filename = DateTime.Now.ToShortDateString() + DateTime.Now.ToString("HH mm") + ".avi";
                    StartRecording(filename);
                }
                else
                {
                    buffer.Enqueue(image);
                    if (Recording && stoptimer.IsRunning)
                        if (timer.ElapsedMilliseconds > Timeout || stoptimer.ElapsedMilliseconds > stopCondition)
                        {
                            StopRecording();
                            long vidDuration = timer.ElapsedMilliseconds;
                            timer.Reset();
                            stoptimer.Reset();
                            magnitudes.Clear();
                            Magnitude n;
                            switch (videoMagnitude)
                            {
                                case 3:
                                    n = new Magnitude(Level.High, vidDuration, high.Sensitivity);
                                    break;
                                case 2:
                                    n = new Magnitude(Level.Medium, vidDuration, medium.Sensitivity);
                                    break;
                                default:
                                    n = new Magnitude(Level.Low, vidDuration, low.Sensitivity);
                                    break;
                            }
                            OnMotionEvent(new MotionEventArgs(m, filename, ref screenshot, startTime, DateTime.Now));
                        }
                        else if (timer.ElapsedMilliseconds >= 5000 || timer.ElapsedMilliseconds <= 6000 && !gotMagnitude)
                        {
                            videoMagnitude = checkMagnitude(ref magnitudes);
                            gotMagnitude = true;
                        }
                        else
                            stoptimer.Start();
                }
            }
        }

        private int checkMagnitude(ref Queue<int> mags)
        {
            double avg = mags.Average();
            mags.Clear();
            return (int)Math.Round(avg);
        }
    }

    class FixedSizeQueue<T>
    {
        ConcurrentQueue<T> q = new ConcurrentQueue<T>();

        public int Limit { get; set; }

        public int Size()
        {
            return q.Count;
        }

        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (this)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }

        public T Dequeue()
        {
            T obj;
            q.TryDequeue(out obj);
            return obj;
        }
    }
}
