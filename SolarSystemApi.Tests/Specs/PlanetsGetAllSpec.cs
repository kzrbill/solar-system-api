using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SolarSystemApi.Controllers;

namespace SolarSystemApi.Tests
{
    public class PlanetsGetAllSpec
    {
        private static IActionResult _result;

        private static void GetAll()
        {
            var planetsController = new PlanetsController(new TestsServiceFactory());
            _result = planetsController.Get();
        }

        [TestClass]
        public class RequestForAllPlanetInSolarSystem
        {
            private JArray _planets;

            [TestInitialize]
            public void BeforEach()
            {
                GetAll();

                var responseObject = (_result as OkObjectResult).Value;
                var responseJson = JToken.FromObject(responseObject);
                _planets = (JArray)responseJson["planets"];
            }

            [TestMethod]
            public void OkResponse()
            {
                Assert.IsInstanceOfType(_result, typeof(OkObjectResult));
            }

            [TestMethod]
            public void ProvidesCorrectNumberOfObjects()
            {
                Assert.AreEqual(2, _planets.Count);
            }

            [TestMethod]
            public void ObjectsInResponseHaveBasicPlanetData()
            {
                Assert.AreEqual("Zorg", _planets[0]["Name"]);
                Assert.AreEqual("ZorgII", _planets[1]["Name"]);
            }
        }
    }


}
