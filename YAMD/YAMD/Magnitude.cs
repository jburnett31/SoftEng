using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMD
{
    public enum Level { Low, Medium, High };

    public class Magnitude
    {
        private Level severity;
        // duration should be in milliseconds to avoid floating point comparisons
        private int duration;
        private int sensitivity;
        public Level Severity
        { get { return severity; } }
        public int Duration
        { get { return duration; }}
        public int Sensitivity
        { get { return sensitivity; }}

        public Magnitude(Level severity, int duration, int sensitivity)
        {
            this.severity = severity;
            this.duration = duration;
            this.sensitivity = sensitivity;
        }
    }
}
