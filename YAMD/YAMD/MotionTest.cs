using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Vision.Motion;
using AForge.Video.VFW;
using AForge.Video;
using AForge.Video.DirectShow;

namespace YAMD
{
    class MotionTest
    {
        MotionDetector detector;
        AsyncVideoSource source;

        public MotionTest()
        {
            detector = new MotionDetector(new SimpleBackgroundModelingDetector(),
                                                     new BlobCountingObjectsProcessing(true));
            source = new AsyncVideoSource(new FileVideoSource("091028_170442.AVI"));
        }   
    }
}
