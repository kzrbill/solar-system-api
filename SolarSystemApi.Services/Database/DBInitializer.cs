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
                    Name = "Mercury",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Mercury_in_color_-_Prockter07-edit1.jpg",
                    DiameterKm = 4879,
                    MinDistanceFromSolKm = 46001200,
                    MaxDistanceFromSolKm = 69816900,
                    MassKg = "3.3011×10²³",
                    TemperatureMeanKelvin = 440,
                    VolumeKm3 = "6.083×10¹⁰",
                },
                new PlanetEntity {
                    Key = "venus",
                    Name = "Venus",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Venus-real_color.jpg",
                    DiameterKm = 12104,
                    MinDistanceFromSolKm = 107477000,
                    MaxDistanceFromSolKm = 108939000,
                    MassKg = "4.8675×10²⁴",
                    TemperatureMeanKelvin = 737,
                    VolumeKm3 = "9.2843×10¹¹",
                },
                new PlanetEntity {
                    Key = "earth",
                    Name = "Earth",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/97/The_Earth_seen_from_Apollo_17.jpg",
                    DiameterKm = 12742,
                    MinDistanceFromSolKm = 147095000,
                    MaxDistanceFromSolKm = 152100000,
                    MassKg = "5.97237×10²⁴",
                    TemperatureMeanKelvin = 288,
                    VolumeKm3 = "1.08321×10¹²",
                },
                new PlanetEntity {
                    Key = "mars",
                    Name = "Mars",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/02/OSIRIS_Mars_true_color.jpg",
                    DiameterKm = 6779,
                    MinDistanceFromSolKm = 206669000,
                    MaxDistanceFromSolKm = 249209300,
                    MassKg = "6.4171×10²³",
                    TemperatureMeanKelvin = 208,
                    VolumeKm3 = "1.6318×10¹¹",
                },
                new PlanetEntity {
                    Key = "jupiter",
                    Name = "Jupiter",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2b/Jupiter_and_its_shrunken_Great_Red_Spot.jpg",
                    DiameterKm = 139822,
                    MinDistanceFromSolKm = 740573600,
                    MaxDistanceFromSolKm = 816520800,
                    MassKg = "1.8986×10²⁷",
                    TemperatureMeanKelvin = 163,
                    VolumeKm3 = "1.43128×10¹⁵",
                },
                new PlanetEntity {
                    Key = "saturn",
                    Name = "Saturn",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Saturn_during_Equinox.jpg",
                    DiameterKm = 116464,
                    MinDistanceFromSolKm = 1353572956,
                    MaxDistanceFromSolKm = 1513325783,
                    MassKg = "5.6846×10²⁶",
                    TemperatureMeanKelvin = 133,
                    VolumeKm3 = "8.2713×10¹⁴",
                },
                new PlanetEntity {
                    Key = "uranus",
                    Name = "Uranus",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Uranus2.jpg",
                    DiameterKm = 50724,
                    MinDistanceFromSolKm = 2748938461,
                    MaxDistanceFromSolKm = 3004419704,
                    MassKg = "8.68×10²⁵",
                    TemperatureMeanKelvin = 78,
                    VolumeKm3 = "",
                },
                new PlanetEntity {
                    Key = "neptune",
                    Name = "Neptune",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/56/Neptune_Full.jpg",
                    DiameterKm = 49244 ,
                    MinDistanceFromSolKm = 4452940833,
                    MaxDistanceFromSolKm = 4553946490,
                    MassKg = "1.0243×10²⁶",
                    TemperatureMeanKelvin = 73,
                    VolumeKm3 = "6.254×10¹³",
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
