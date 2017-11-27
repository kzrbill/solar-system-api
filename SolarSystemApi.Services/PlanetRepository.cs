using System;
using System.Collections.Generic;
using SolarSystemApi.Models;

namespace SolarSystemApi.Services
{

    // https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=Earth
    // https://www.wikidata.org/w/api.php?action=wbgetentities&sites=enwiki&props=claims&titles=Earth

    public interface IPlanetRepository
    {
        IPlanet GetByName(string name);
    }

    public class PlanetRepository : IPlanetRepository
    {
        public IPlanet GetByName(string name)
        {
            // var planetsJson = new PlanetsJson("PlanetsJson");

            var planets = new Dictionary<string, IPlanet>()
            {
                {"earth", new Planet("Earth")}
            };

            name = name.ToLower();
            return planets.GetValueOrDefault(name);
        }
    }
}
