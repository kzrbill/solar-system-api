using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarSystemApi.Controllers;
using SolarSystemApi.Services;

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
        public class RequestForUnknownPlanet
        {
            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("SomeElusiveAnomaly");
            }

            [TestMethod]
            public void NoFoundStatusResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(NotFoundObjectResult));
            }
        }

        [TestClass]
        public class RequestForKnownPlanet
        {
            private dynamic _planet; 

            [TestInitialize]
            public void BeforEach()
            {
                GetPlanet("earth");
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
                Assert.AreEqual("Earth", _planet.Name);
                Assert.AreEqual("123", _planet.DistanceFromSol);
            }
        }
    }

    internal class TestsServiceFactory : IServiceFactory
    {
        public ILiteDatabase CreateDB()
        {
            return new TestDBProxy();
        }
    }
}
