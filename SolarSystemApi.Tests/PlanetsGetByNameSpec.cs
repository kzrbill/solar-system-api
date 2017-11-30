using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarSystemApi.Controllers;
using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    internal class TestsServiceFactory : IServiceFactory
    {
        public ILiteDatabase CreateDB()
        {
            return new TestDBProxy()
                .WithPlanetEntity(new PlanetEntity() { Key = "zorg", Name = "Zorg" })
                .WithPlanetEntity(new PlanetEntity() { Key = "zorg2", Name = "ZorgII" });
        }
    }


    public class PlanetsGetByNameSpec
    {
        private static IActionResult _result;

        private static void GetPlanet(string planetName) {
            var planetsController = new PlanetsController(new TestsServiceFactory());
            _result = planetsController.Get(planetName);
        }

        [TestClass]
        public class RequestForUnknownPlanet
        {
            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("SomeOtherElusiveAnomaly");
            }

            [TestMethod]
            public void NoFoundStatusResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(NotFoundObjectResult));
            }
        }

        [TestClass]
        public class RequestForPlanetInSolarSystem
        {
            private dynamic _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("zorg");
                _planet = (_result as OkObjectResult).Value;
            }

            [TestMethod]
            public void OkResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(OkObjectResult));
            }

            [TestMethod]
            public void ProvidesAllEarthlyData()
            {
                Assert.AreEqual("Zorg", _planet.Name);
            }
        }
    }


}
