using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    public class TestDBProxy : ILiteDatabase
    {
        TestDBCollection<PlanetEntity> _planets;
        public TestDBProxy() {
            _planets = new TestDBCollection<PlanetEntity>();
        }


        internal TestDBProxy WithPlanetEntity(PlanetEntity planetEntity)
        {
            _planets.Insert(planetEntity);
            return this;
        }

        public IDBCollectionProxy<EntityType> GetCollection<EntityType>(string typeName)
        {
            return _planets as IDBCollectionProxy<EntityType>;
        }

        public void Dispose()
        {
        }
    }
}
