using System;
using System.Collections.Generic;
using LiteDB;
using SolarSystemApi.Services;
using System.Linq;

namespace SolarSystemApi.Services
{
    public interface IPlanetRepository
    {
        IPlanet GetByName(string key);
        IEnumerable<IPlanet> GetAll();
    }

    public class PlanetRepository : IPlanetRepository
    {
        ILiteDatabase _db;
        public PlanetRepository(ILiteDatabase db){
            _db = db;
        }

        public IEnumerable<IPlanet> GetAll()
        {
            var planets = _db.GetCollection<PlanetEntity>("planets");
            var results = planets.Find(Query.All(Query.Ascending)).OrderBy(p => p.MinDistanceFromSolKm);

            return results.Select((e) => Planet.WithEntity(e));
        }

        public IPlanet GetByName(string name)
        {
            var planets = _db.GetCollection<PlanetEntity>("planets");
            var results = planets.Find(p => (bool)(p.Name.ToLower() == name.ToLower()));

            if (!results.Any()) return null;

            var entity = results.First();
            return Planet.WithEntity(entity);
        }
    }


}
