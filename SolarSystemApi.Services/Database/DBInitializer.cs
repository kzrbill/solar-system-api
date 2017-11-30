using LiteDB;
using System.Linq;
using System.Collections.Generic;

namespace SolarSystemApi.Services
{
    public static class DBInitializer
    {
        public static void Init(ILiteDatabase db)
        {
            var planets = db.GetCollection<PlanetEntity>("planets");
            if (AlreadySeeded(planets)) return;

            var entities = new List<PlanetEntity>()
            {
                new PlanetEntity {
                    Key = "mercury",
                    Name = "Mercury"
                },
                new PlanetEntity {
                    Key = "venus",
                    Name = "Venus"
                },
                new PlanetEntity {
                    Key = "earth",
                    Name = "Earth"
                },
                new PlanetEntity {
                    Key = "mars",
                    Name = "Mars"
                },
            };

            foreach(var entity in entities) {
                planets.Insert(entity); 
            }

            planets.EnsureIndex(x => x.Key);
        }

        public static bool AlreadySeeded(IDBCollectionProxy<PlanetEntity> collection)
        {
            return collection.Find(Query.All()).Count() > 1;
        }
    }
}
