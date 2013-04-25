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
        const float stopCondition = 5.0f;
        VideoFileWriter videoRecorder;
        FixedSizeQueue<Bitmap> buffer;
        public bool Running
        { get; set;}
        Magnitude low, medium, high;
        public double Timeout
        { get; set; }

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
            this.low = low;
            this.medium = medium;
            this.high = high;
            timer = new Stopwatch();
            videoRecorder = new VideoFileWriter();
            Running = false;
            buffer = new FixedSizeQueue<Bitmap>();
            buffer.Limit = 50;
        }

        ~YAMDDetector()
        {
           
        }

        public void Start()
        {
            //Running = true;
            //inputStream.Start();
            //detectorThread = new Thread(new ThreadStart(mainLoop));
        }

        public void Stop()
        {
            //videoRecorder.Close();
            //Running = false;
            //inputStream.Stop();
            //detectorThread.Join();
        }

        public String RecordVideo()
        {
            String videoName = "";
            consBuffer();
            //Bitmap image;
            //videoRecorder.AddFrame(image)
            
            return videoName;
        }

        private void consBuffer()
        {
            for (int i = 0; i < buffer.Size(); i++ )
            {
                Bitmap img = buffer.Dequeue();
                videoRecorder.WriteVideoFrame(img);
            }
        }

        protected virtual void OnMotionEvent(MotionEventArgs e)
        {
            MotionEventHandler handler = RaiseMotionEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            lock (this)
            {
                Magnitude m = null;
                float motionLevel = detector.ProcessFrame(image);
                int level = (int)Math.Floor(motionLevel * 100);

                if (level >= high.Sensitivity)
                    m = high;
                else if (level >= medium.Sensitivity)
                    m = medium;
                else if (level >= low.Sensitivity)
                    m = low;

                if (m != null)
                {
                    String file = DateTime.Now.ToShortDateString() + DateTime.Now.ToString("HH mm") + ".avi";
                    OnMotionEvent(new MotionEventArgs(m, file, ref image));
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

        private bool checkMagnitude(Magnitude m, int duration, int sensitivity)
        {
            if (duration >= m.Duration && sensitivity > m.Duration)
            {
                return true;
            }
            return false;
        }
    }
}
