using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolarSystemApi.Controllers;

namespace SolarSystemApi.Tests
{
    public class PlanetsGetByNameSpec
    {
        private static IActionResult GetPlanet(string planetName) {
            var planetsController = new PlanetsController(new TestsServiceFactory());
            return planetsController.Get(planetName);
        }

        [TestClass]
        public class RequestForPlanetInSolarSystem
        {
            private IActionResult _result;
            private TestPlanetResponse _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                _result = GetPlanet("zorg");
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
                Assert.AreEqual("868768 / 979879 km", _planet.GetStatValue("Distance from Sol"));
                Assert.AreEqual("111111 km", _planet.GetStatValue("Orbital deviation"));
                Assert.AreEqual("3.3011×9²³ kg", _planet.GetStatValue("Mass"));
                Assert.AreEqual("301 km", _planet.GetStatValue("Diameter"));
                Assert.AreEqual("137 K", _planet.GetStatValue("Surface temperature (mean)"));
                Assert.AreEqual("4.083×9¹⁰ km³", _planet.GetStatValue("Volume"));
            }
        }

        [TestClass]
        public class RequestForUnknownPlanet
        {
            private IActionResult _result;
            private TestPlanetResponse _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                _result = GetPlanet("SomeOtherElusiveAnomaly");
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
