using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthTools.Net
{

    public class EarthToolsClient
    {
        public static readonly string BaseUrl = "http://www.earthtools.org";


        public EarthToolsClient()
        {
            TimeZones = new TimeZoneClient();
            Places = new PlaceClient();
        }

        public TimeZoneClient TimeZones { get; private set; }
        public PlaceClient Places { get; private set; }




    }
}
