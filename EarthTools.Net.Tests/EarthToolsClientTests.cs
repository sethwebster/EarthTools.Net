using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EarthTools.Net.Tests
{
    [TestClass]
    public class EarthToolsClientTests
    {
        [TestMethod]
        public void TestPlaceLookupSuccess()
        {
            EarthToolsClient cli = new EarthToolsClient();
            var place = cli.Places.Query("Tucson, AZ");
            Assert.IsNotNull(place);
            Assert.AreNotEqual(0, place.Count());

            var first = place.First();

            Assert.AreEqual("Tucson", first.Name);

            Assert.IsNotNull(place);
        }

        [TestMethod]
        public void TestTimeZoneLookup()
        {
            EarthToolsClient cli = new EarthToolsClient();
            var timezone = cli.TimeZones.Query(32, -110);

            Assert.IsNotNull(timezone);
            Assert.AreEqual(-7, timezone.Offset);
        }

        [TestMethod]
        public void TestFullLookup()
        {
            EarthToolsClient cli = new EarthToolsClient();

            string city = "Tucson";
            string state = "AZ";
            var places = cli.Places.Query(city + ", " + state);

            Assert.IsNotNull(places);
            Assert.AreNotEqual(0, places.Count());

            var first = places.First();

            Assert.AreEqual(city, first.Name);

            var timezone = cli.TimeZones.Query(first.Latitude, first.Longitude);

            Assert.IsNotNull(timezone);
     


        }
    }
}
