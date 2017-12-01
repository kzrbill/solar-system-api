using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    internal class TestsServiceFactory : IServiceFactory
    {
        public ILiteDatabase CreateDB()
        {
            return new TestDBProxy()
                .WithPlanetEntity(Zorg())
                .WithPlanetEntity(ZorgII());
        }

        private PlanetEntity Zorg() {
            return new PlanetEntity
            {
                Key = "zorg",
                Name = "Zorg",
                ImageUrl = "https://img00.deviantart.net/af4b/i/2014/214/e/2/crazy_planet_by_a_cat_art-d7te9xd.png",
                DiameterKm = 301,
                MinDistanceFromSolKm = 868768,
                MaxDistanceFromSolKm = 979879,
                MassKg = "3.3011×9²³",
                TemperatureMeanKelvin = 137,
                VolumeKm3 = "4.083×9¹⁰",
            };
        }

        private PlanetEntity ZorgII()
        {
            return new PlanetEntity
            {
                Key = "zorg2",
                Name = "ZorgII",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/67/Mining_Planet_with_Opposing_Derricks.png",
                DiameterKm = 76,
                MinDistanceFromSolKm = 1209803,
                MaxDistanceFromSolKm = 8739373,
                MassKg = "5.2309×4²³",
                TemperatureMeanKelvin = 137,
                VolumeKm3 = "1.908×4¹⁰",
            };
        }
    }


}
