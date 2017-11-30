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
        private readonly IServiceFactory _serviceFactory;
        public PlanetsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        // GET api/planets
        [HttpGet]
        public IEnumerable<IPlanet> Get()
        {
            return new Planet[] { };
        }

        // GET api/planets/earth
        [HttpGet("{planetName}")]
        public IActionResult Get(string planetName)
        {
            var repo = new PlanetRepository(_serviceFactory.CreateDB());

            IPlanet planet = repo.GetByKey(planetName);
            if (null != planet) {
                return Ok(planet);
            }

            return NotFound(planetName);
        }
    }

   
}
