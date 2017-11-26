using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolarSystemApi.Controllers
{
    public class Planet : IPlanet
    {
        private readonly string _planetName;
        public Planet(string planetName) {
            _planetName = planetName;
        }

        public string Name => _planetName;
    }

    public interface IPlanet  {
        string Name { get; }
    }

    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        // GET api/planets
        [HttpGet]
        public IEnumerable<IPlanet> Get()
        {
            return new IPlanet[] { new Planet("somePlanet") };
        }

        // GET api/planets/earth
        [HttpGet("{planetName}")]
        public IActionResult Get(string planetName)
        {
            var planets = new Dictionary<string, IPlanet>()
            {
                {"earth", new Planet("Earth")}
            };

            planetName = planetName.ToLower();
            var planet = planets.GetValueOrDefault(planetName);
            if (null != planet) {
                return Ok(planet);
            }

            return NotFound(planetName);
        }
    }
}
