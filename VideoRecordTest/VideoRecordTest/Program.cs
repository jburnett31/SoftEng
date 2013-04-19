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
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoFileWriter writer = new VideoFileWriter();
            try
            {
                writer.Open("test-out.avi", 320, 240, 25, VideoCodec.MPEG4);
                Bitmap bmp = new Bitmap(320, 240, PixelFormat.Format24bppRgb);
                for (int i = 0; i < 100; i++)
                {
                    bmp.SetPixel(i, i, Color.FromArgb(i, 0, 255 - i));
                    writer.WriteVideoFrame(bmp);
                }
                bmp.Dispose();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            writer.Dispose();

            Console.ReadKey();
        }
    }
}
