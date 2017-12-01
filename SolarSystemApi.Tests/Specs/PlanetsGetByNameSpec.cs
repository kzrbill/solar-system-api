using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolarSystemApi.Controllers;

namespace SolarSystemApi.Tests
{
    public class PlanetsGetByNameSpec
    {
        private static IActionResult _result;

        private static void GetPlanet(string planetName) {
            var planetsController = new PlanetsController(new TestsServiceFactory());
            _result = planetsController.Get(planetName);
        }

        [TestClass]
        public class RequestForPlanetInSolarSystem
        {
            private TestPlanetResponse _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("zorg");
                _planet = TestPlanetResponse.FromResponseObject(_result);
            }

            [TestMethod]
            public void OkResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(OkObjectResult));
            }

            [TestMethod]
            public void PlanetHasCompleteData()
            {
                Assert.AreEqual("Zorg", _planet.Name);
                Assert.AreEqual("https://img00.deviantart.net/af4b/i/2014/214/e/2/crazy_planet_by_a_cat_art-d7te9xd.png", _planet.ImageUrl);
                Assert.AreEqual("868768 / 979879 km", _planet.GetStatValue("DistanceFromSol"));
                Assert.AreEqual("111111 km", _planet.GetStatValue("OrbitalDeviation"));
                Assert.AreEqual("3.3011×9²³ kg", _planet.GetStatValue("Mass"));
                Assert.AreEqual("301 km", _planet.GetStatValue("Diameter"));
                Assert.AreEqual("137 K", _planet.GetStatValue("Surface Temperature (mean)"));
                Assert.AreEqual("4.083×9¹⁰ km³", _planet.GetStatValue("Volume"));
            }
        }

        [TestClass]
        public class RequestForUnknownPlanet
        {
            private TestPlanetResponse _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("SomeOtherElusiveAnomaly");
                _planet = TestPlanetResponse.FromResponseObject(_result);
            }

            [TestMethod]
            public void NoFoundStatusResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(NotFoundObjectResult));
            }

            [TestMethod]
            public void NoPlanetInResponse()
            {
                Assert.IsNull(_planet, "Unexected planet in response. Should be null");
            }
        }
    }
}
