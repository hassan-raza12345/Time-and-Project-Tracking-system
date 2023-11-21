using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem
{
    public class TimeTracker
    {
        public DateTime StartTime { get; set; }

        public void StartTracking()
        {
            StartTime = DateTime.Now;
        }

        public TimeSpan StopTracking()
        {
            return DateTime.Now - StartTime;
        }
    }
}

