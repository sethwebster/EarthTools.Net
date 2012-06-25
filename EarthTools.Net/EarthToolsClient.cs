using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarthTools.Net
{

    public class EarthToolsClient
    {
        public static readonly string BaseUrl = "http://www.earthtools.org";
        // {0} = lat, {1} = long
        public static readonly string BaseUrlTimeZone = BaseUrl + "/timezone/{0}/{1}";
        // {0} = place, eg. Tucson, AZ
        public static readonly string BaseUrlPlaces = BaseUrl + "/placeap.php?place={0}";


    }
}
