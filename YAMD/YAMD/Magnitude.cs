using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMD
{
    enum Level { Low, Medium, High };

    class Magnitude
    {
        private Level severity;
        private double duration;
        private int sensitivity;
        public Level Severity()
        { return severity; }
        public double Duration()
        { return duration; }
        public int Sensitivity()
        { return sensitivity; }

        public Magnitude(Level severity, double duration, int sensitivity)
        {
            this.severity = severity;
            this.duration = duration;
            this.sensitivity = sensitivity;
        }
    }
}
