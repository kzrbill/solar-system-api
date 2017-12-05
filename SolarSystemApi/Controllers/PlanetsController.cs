using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarSystemApi.Services;

namespace SolarSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        private readonly IPlanetRepository _repo;
        public PlanetsController(IServiceFactory serviceFactory)
        {
            _repo = new PlanetRepository(serviceFactory.CreateDB());
        }

        // GET api/planets
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<IPlanet> planets = _repo.GetAll();
            return Ok(new { planets });
        }

        // GET api/planets/earth
        [HttpGet("{planetName}")]
        public IActionResult Get(string planetName)
        {
            IPlanet planet = _repo.GetByName(planetName);
            if (null != planet) {
                return Ok(planet);
            }

            return NotFound($"Planet {planetName} not found in Solar System");
        }
    }

   
}
