using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace EarthTools.Net
{
    public sealed class TimeZoneClient
    {
        // {0} = lat, {1} = long
        public static readonly string BaseUrlTimeZone = EarthToolsClient.BaseUrl + "/timezone/{0}/{1}";
        public TimeZone Query(decimal latitude, decimal longitude)
        {
            var client = WebClientFactory.GetClient();
            var data = client.DownloadString(string.Format
                (BaseUrlTimeZone, latitude, longitude));

            XDocument doc = XDocument.Parse(data);

            var timeZoneElement = doc.Descendants("timezone").First();
            var ret = new TimeZone()
            {
                Version = Decimal.Parse(timeZoneElement.Elements("version").First().Value),
                DST = timeZoneElement.Elements("dst").First().Value,
                IsoTime = DateTimeOffset.Parse(timeZoneElement.Elements("isotime").First().Value),
                LocalTime = DateTime.Parse(timeZoneElement.Elements("localtime").First().Value),
                Location = new Location()
                {
                    Longitude = Decimal.Parse(timeZoneElement.Elements("location").First().Elements("longitude").First().Value),
                    Latitude = Decimal.Parse(timeZoneElement.Elements("location").First().Elements("latitude").First().Value),
                },
                Offset = Decimal.Parse(timeZoneElement.Elements("offset").First().Value),
                Suffix = timeZoneElement.Elements("suffix").First().Value,
                UtcTime = DateTime.Parse(timeZoneElement.Elements("utctime").First().Value)
            };
            return ret;
        }
    }
}
