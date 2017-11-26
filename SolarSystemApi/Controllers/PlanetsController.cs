using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolarSystemApi.Controllers
{
    public class Planet : ISolarAnomaly
    {
        private readonly string _planetName;
        public Planet(string planetName) {
            _planetName = planetName;
        }

        public string Name => _planetName;
    }

    public interface ISolarAnomaly  {
        string Name { get; }
    }

    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        // GET api/planets
        [HttpGet]
        public IEnumerable<ISolarAnomaly> Get()
        {
            return new ISolarAnomaly[] { new Planet("somePlanet") };
        }

        // GET api/planets/earth
        [HttpGet("{planetName}")]
        public IActionResult Get(string planetName)
        {
            var planets = new Dictionary<string, ISolarAnomaly>()
            {
                {"Earth", new Planet("Earth")}
            };

            var planet = planets.GetValueOrDefault(planetName);
            if (null != planet) {
                return Ok(planet);
            }

            return NotFound(planetName);
        }
    }
}
