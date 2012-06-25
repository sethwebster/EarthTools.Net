using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EarthTools.Net
{
    public sealed class PlaceClient
    {
        // {0} = place, eg. Tucson, AZ
        public static readonly string BaseUrlPlaces = EarthToolsClient.BaseUrl + "/placea.php?place={0}";

        public IEnumerable<Place> Query(string Location)
        {
            var client = GetClient();
            var data = client.DownloadString(string.Format
                (BaseUrlPlaces, Location));

            XDocument doc = XDocument.Parse(data);

            var d = from p in doc.Descendants("place")
                    select new Place()
                    {
                        Name = p.Elements("name").First().Value,
                        Admin1 = p.Elements("admin1").First().Value,
                        Admin2 = p.Elements("admin2").First().Value,
                        Country = p.Elements("country").First().Value,
                        Detail = new Detail()
                        {
                            FeatureClass = new FeatureClass()
                            {
                                Code = p.Elements("detail")
                                .First()
                                .Elements("featureclass")
                                .First()
                                .Elements("code")
                                .First()
                                .Value,
                                Description = p.Elements("detail")
                                .First()
                                .Elements("featureclass")
                                .First()
                                .Elements("description").First().Value,
                                Type = p.Elements("detail")
                                .First()
                                .Elements("featureclass")
                                .First()
                                .Elements("type")
                                .First()
                                .Value,
                            },
                            Importance = Int32.Parse(p.Elements("detail").First().Elements("importance").First().Value),
                        },
                        Latitude = Decimal.Parse(p.Elements("latitude").First().Value),
                        Longitude = Decimal.Parse(p.Elements("longitude").First().Value)
                    };

            return d.OrderBy(p => p.Detail.Importance);
        }

        private static WebClient GetClient()
        {
            WebClient c = new WebClient();
            c.Headers["User-Agent"] = "test";
            return c;
        }
    }
}
