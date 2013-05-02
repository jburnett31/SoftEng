using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AForge.Vision.Motion;
using AForge.Video;
using AForge.Video.VFW;
using AForge.Video.FFMPEG;
using System.Diagnostics;
using System.Drawing;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace YAMD
{

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
        { get; set;}
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
            for (int i = 0; i < buffer.Size(); i++ )
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
            /*
            lock (this)
            {
                float motionLevel = detector.ProcessFrame(image);

                if (motionLevel > motionAlarmLevel)
                {
                    // flash for 2 seconds
                    flash = (int)(2 * (1000 / alarmTimer.Interval));
                }

                // accumulate history
                motionHistory.Add(motionLevel);
                if (motionHistory.Count > 300)
                {
                    motionHistory.RemoveAt(0);
                }

                if (showMotionHistoryToolStripMenuItem.Checked)
                    DrawMotionHistory(image);
            }
             */
        }

        private int checkMagnitude(ref Queue<int> mags)
        {
            double avg = mags.Average();
            mags.Clear();
            return (int)Math.Round(avg);
        }
    }
}
