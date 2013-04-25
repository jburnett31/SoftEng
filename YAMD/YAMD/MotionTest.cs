using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Vision.Motion;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Drawing;
using Splicer.Timeline;
using Splicer.Renderer;
using Splicer.Utilities;
using Splicer.WindowsMedia;

namespace YAMD
{
    class MotionTest
    {
        MotionDetector detector;
        AsyncVideoSource source;
        AviWriter recorder;

        public MotionTest()
        {
            detector = new MotionDetector(new SimpleBackgroundModelingDetector(),
                                                     new BlobCountingObjectsProcessing(true));
            source = new AsyncVideoSource(new FileVideoSource("091028_170442.AVI"));

            
        }

        static void Main(string[] args)
        {
            string outputFile = "test-output.wmv";

            using (ITimeline timeline = new DefaultTimeline(15))
            {
                IGroup videoGroup = timeline.AddVideoGroup(24, 320, 240);
                ITrack videoTrack = videoGroup.AddTrack();

                Bitmap bmp = new Bitmap(320, 240, PixelFormat.Format24bppRgb);
                for (int i=0; i<100; i++)
                {
                    bmp.SetPixel(i,i,Color.FromArgb(i,0,255-i));
                    videoTrack.AddImage(bmp);
                }
                bmp.Dispose();

                IRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.LowQualityVideo);
                {
                    renderer.Render();
                }
                
            }
        }
    }
}
