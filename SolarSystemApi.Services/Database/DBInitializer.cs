﻿namespace SolarSystemApi.Services
{
    public static class DBInitializer
    {
        public static void Init(ILiteDatabase db)
        {
            using (db)
            {
                var planets = db.GetCollection<PlanetEntity>("planets");

                var planet = new PlanetEntity
                {
                    Name = "Earth"
                };

                planets.Insert(planet);
                planets.EnsureIndex(x => x.Name);
            }
        }
    }
}
