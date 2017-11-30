using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarSystemApi.Models;
using SolarSystemApi.Services;

namespace SolarSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        private readonly IPlanetRepository _planetRepo;
        public PlanetsController(IServiceFactory serviceFactory)
        {
            _planetRepo = new PlanetRepository(serviceFactory.CreateDB());
        }

        // GET api/planets
        [HttpGet]
        public IEnumerable<IPlanet> Get()
        {
            return new IPlanet[] { };
        }

        // GET api/planets/earth
        [HttpGet("{planetName}")]
        public IActionResult Get(string planetName)
        {
            IPlanet planet = _planetRepo.GetByName(planetName);
            if (null != planet) {
                return Ok(planet);
            }

            return NotFound(planetName);
        }
    }

   
}
