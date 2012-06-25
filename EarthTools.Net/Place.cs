using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthTools.Net
{
    public class Place
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Admin1 { get; set; }
        public string Admin2 { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Detail Detail { get; set; }


    }
}
