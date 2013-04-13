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

        public YAMDDetector(IVideoSource source, Magnitude low, Magnitude medium, Magnitude high)
        {
            detector = new MotionDetector(
                new SimpleBackgroundModelingDetector(),
                new BlobCountingObjectsProcessing());
            inputStream = source;
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
            detectorThread = new Thread(new ThreadStart(mainLoop));
        }

        public void Stop()
        {
            Running = false;
            detectorThread.Join();
        }

        public String RecordVideo()
        {
            String videoName = "";
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
    }
}
