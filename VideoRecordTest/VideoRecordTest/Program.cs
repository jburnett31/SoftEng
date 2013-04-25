using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.FFMPEG;
using AForge.Vision.Motion;
using Splicer.Timeline;
using Splicer.Renderer;
using Splicer.Utilities;
using Splicer.WindowsMedia;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFile = "test-output.wmv";

            using (ITimeline timeline = new DefaultTimeline(15))
            {
                timeline.AddAudioGroup().AddTrack();
                IGroup videoGroup = timeline.AddVideoGroup(24, 320, 240);
                ITrack videoTrack = videoGroup.AddTrack();

                Bitmap bmp = new Bitmap(320, 240, PixelFormat.Format24bppRgb);
                for (int i = 0; i < 100; i++)
                {
                    bmp.SetPixel(i, i, Color.FromArgb(i, 0, 255 - i));
                    videoTrack.AddImage(bmp);
                }
                bmp.Dispose();
                videoGroup.AddTransition(0.0, 0.1, StandardTransitions.CreatePixelate(), false);
                IRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.LowQualityVideo);
                {
                    renderer.Render();
                }

            }
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
