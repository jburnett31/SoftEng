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
        const float stopCondition = 5.0f;
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
                    timer.Start();
                    filename = DateTime.Now.ToShortDateString() + DateTime.Now.ToString("HH mm") + ".avi";
                    StartRecording(filename);
                }
                else
                {
                    buffer.Enqueue(image);
                    if (Recording && stoptimer.IsRunning)
                        if (stoptimer.ElapsedMilliseconds > Timeout)
                        {
                            StopRecording();
                            OnMotionEvent(new MotionEventArgs(m, filename, ref screenshot));
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

        private int checkMagnitude(Queue<int> mags, int duration)
        {
    
            return 0;
        }
    }
}
