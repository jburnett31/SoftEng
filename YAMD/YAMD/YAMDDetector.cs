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
        }

        public ~YAMDDetector()
        {
            videoRecorder.Close();
        }

        public void Start()
        {
            //main loop
            Running = true;
            detectorThread = 
        }

        public void Stop()
        {
            Running = false;
        }

        public String RecordVideo()
        {
            String videoName = "";
            //Bitmap image;
            //videoRecorder.AddFrame(image)
            
            return videoName;
        }
    }
}
