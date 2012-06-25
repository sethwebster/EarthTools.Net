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
    }
}
