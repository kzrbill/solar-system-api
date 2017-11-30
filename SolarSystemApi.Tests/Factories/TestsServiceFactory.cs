using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    internal class TestsServiceFactory : IServiceFactory
    {
        public ILiteDatabase CreateDB()
        {
            return new TestDBProxy()
                .WithPlanetEntity(new PlanetEntity() { Key = "zorg", Name = "Zorg" })
                .WithPlanetEntity(new PlanetEntity() { Key = "zorg2", Name = "ZorgII" });
        }
    }


}
