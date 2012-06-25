using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthTools.Net
{
    public class TimeZone
    {

        public decimal Version { get; set; }
        public Location Location { get; set; }
        public decimal Offset { get; set; }
        public string Suffix { get; set; }
        public DateTime LocalTime { get; set; }
        public DateTimeOffset IsoTime { get; set; }
        public DateTime UtcTime { get; set; }
        public string DST { get; set; }

    }
}
