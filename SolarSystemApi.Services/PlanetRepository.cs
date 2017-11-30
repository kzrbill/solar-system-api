using System;
using System.Collections.Generic;
using LiteDB;
using SolarSystemApi.Models;
using System.Linq;

namespace SolarSystemApi.Services
{
    public interface IPlanetRepository
    {
        IPlanet GetByKey(string key);
    }

    public class PlanetRepository : IPlanetRepository
    {
        ILiteDatabase _db;
        public PlanetRepository(ILiteDatabase db){
            _db = db;
        }

        public IPlanet GetByKey(string key)
        {
            var customers = _db.GetCollection<PlanetEntity>("planets");
            var results = customers.Find(x => x.Key.Contains(key.ToLower()));
            if (!results.Any()) return null;

            var entity = results.First();
            return Planet.WithEntity(entity);
        }
    }


}
