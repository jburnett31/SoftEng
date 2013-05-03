using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YAMD
{
    public class MotionEventArgs : EventArgs
    {
        public Magnitude Severity
        { get; set; }
        public String VideoName
        { get; set; }
        public Bitmap Screenshot
        { get; set; }
		public DateTime StartTime
		{ get; set; }
		public DateTime EndTime
		{ get; set; }

		public MotionEventArgs(Magnitude m, String name, ref Bitmap image, DateTime startTime, DateTime endTime)
        {
            Severity = m;
            VideoName = name;
            Screenshot = image;
			StartTime = startTime;
			EndTime = EndTime;

        }
    }
}
