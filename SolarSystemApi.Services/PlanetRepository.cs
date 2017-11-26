using System;
using System.Collections.Generic;
using SolarSystemApi.Models;

namespace SolarSystemApi.Services
{
    public interface IPlanetRepository
    {
        IPlanet GetByName(string name);
    }

    public class PlanetRepository : IPlanetRepository
    {
        public IPlanet GetByName(string name)
        {

            var planets = new Dictionary<string, IPlanet>()
            {
                {"earth", new Planet("Earth")}
            };

            name = name.ToLower();
            return planets.GetValueOrDefault(name);
        }
    }
}
