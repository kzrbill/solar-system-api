using System;
using System.Collections.Generic;
using LiteDB;
using SolarSystemApi.Models;

namespace SolarSystemApi.Services
{
    public interface IPlanetRepository
    {
        IPlanet GetByName(string name);
    }

    public class PlanetRepository : IPlanetRepository
    {
        ILiteDatabase _db;
        public PlanetRepository(ILiteDatabase db){
            _db = db;
        }

        public IPlanet GetByName(string name)
        {
 
            var customers = _db.GetCollection<PlanetEntity>("planets");
            var results = customers.Find(x => x.Name.ToLower() == name.ToLower());
            // TODO: return the one planet
 

            var planetsJson = PlanetsJsonFile
                .Load()
                .Json();

            foreach(var planetToken in planetsJson["planets"]) {
                var planetName = planetToken.Value<string>("name").ToLower();
                if (planetName == name.ToLower()) {
                    return Planet.WithToken(planetToken);
                }
            }

            return null;
        }
    }


}
