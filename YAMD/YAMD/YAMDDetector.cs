using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AForge.Vision.Motion;
using AForge.Video;
using AForge.Video.VFW;
using System.Diagnostics;
using System.Drawing;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace YAMD
{
    public class YAMDDetector
    {
        MotionDetector detector;
        IVideoSource inputStream;
        Stopwatch timer;
        const float stopCondition = 5.0f;
        AVIWriter videoRecorder;
        Thread detectorThread;
        FixedSizeQueue<Bitmap> buffer;
        public bool Running
        { get; set;}
        Magnitude low, medium, high;
        public double Timeout
        { get; set; }

        public YAMDDetector(IVideoSource source, Magnitude low, Magnitude medium, Magnitude high)
        {
            detector = new MotionDetector(
                new SimpleBackgroundModelingDetector(),
                new BlobCountingObjectsProcessing());
            inputStream = source;
            this.low = low;
            this.medium = medium;
            this.high = high;
            timer = new Stopwatch();
            videoRecorder = new AVIWriter("wmv3");
            Running = false;
            buffer = new FixedSizeQueue<Bitmap>();
            buffer.Limit = 50;
        }

        public ~YAMDDetector()
        {
            videoRecorder.Close();
        }

        private void mainLoop()
        {
            while (Running)
            {

            }
        }

        public void Start()
        {
            Running = true;
            inputStream.Start();
            detectorThread = new Thread(new ThreadStart(mainLoop));
        }

        public void Stop()
        {
            Running = false;
            inputStream.Stop();
            detectorThread.Join();
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
                videoRecorder.AddFrame(img);
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
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
        }

        private void DrawMotionHistory(Bitmap image)
        {
            Color greenColor = Color.FromArgb(128, 0, 255, 0);
            Color yellowColor = Color.FromArgb(128, 255, 255, 0);
            Color redColor = Color.FromArgb(128, 255, 0, 0);

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite, image.PixelFormat);

            int t1 = (int)(motionAlarmLevel * 500);
            int t2 = (int)(0.075 * 500);

            for (int i = 1, n = motionHistory.Count; i <= n; i++)
            {
                int motionBarLength = (int)(motionHistory[n - i] * 500);

                if (motionBarLength == 0)
                    continue;

                if (motionBarLength > 50)
                    motionBarLength = 50;

                Drawing.Line(bitmapData,
                    new IntPoint(image.Width - i, image.Height - 1),
                    new IntPoint(image.Width - i, image.Height - 1 - motionBarLength),
                    greenColor);

                if (motionBarLength > t1)
                {
                    Drawing.Line(bitmapData,
                        new IntPoint(image.Width - i, image.Height - 1 - t1),
                        new IntPoint(image.Width - i, image.Height - 1 - motionBarLength),
                        yellowColor);
                }

                if (motionBarLength > t2)
                {
                    Drawing.Line(bitmapData,
                        new IntPoint(image.Width - i, image.Height - 1 - t2),
                        new IntPoint(image.Width - i, image.Height - 1 - motionBarLength),
                        redColor);
                }
            }

            image.UnlockBits(bitmapData);
        }

    }
}
