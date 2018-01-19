using System;

namespace PeriodsJoining
{
    public class TimePeriod
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimePeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}