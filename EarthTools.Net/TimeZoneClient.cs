using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthTools.Net
{
    public sealed class TimeZoneClient
    {
        // {0} = lat, {1} = long
        public static readonly string BaseUrlTimeZone = EarthToolsClient.BaseUrl + "/timezone/{0}/{1}";

    }   
}
