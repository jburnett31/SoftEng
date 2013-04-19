using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Vision.Motion;
using AForge.Video.VFW;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Drawing;

namespace YAMD
{
    class MotionTest
    {
        MotionDetector detector;
        AsyncVideoSource source;
        AVIWriter recorder;

        public MotionTest()
        {
            detector = new MotionDetector(new SimpleBackgroundModelingDetector(),
                                                     new BlobCountingObjectsProcessing(true));
            source = new AsyncVideoSource(new FileVideoSource("091028_170442.AVI"));

            recorder = new AVIWriter("wmv3");
        }

        static void Main(string[] args)
        {
            AVIWriter writer = new AVIWriter("wmv3");
            try
            {
                writer.Open("test-out.wmv", 320, 240);
                Bitmap bmp = new Bitmap(320, 240, PixelFormat.Format24bppRgb);
                for (int i = 0; i < 100; i++)
                {
                    bmp.SetPixel(i, i, Color.FromArgb(i, 0, 255 - i));
                    writer.AddFrame(bmp);
                }
                bmp.Dispose();
            }
            catch (ApplicationException e)
            {
            }
            writer.Dispose();
        }
    }
}
