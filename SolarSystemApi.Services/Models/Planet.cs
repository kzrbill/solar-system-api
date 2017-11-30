using System;
using Newtonsoft.Json.Linq;

namespace SolarSystemApi.Services
{
    public interface IPlanet
    {
        string Name { get; }
    }

    public class Planet : IPlanet
    {
        public static IPlanet WithEntity(PlanetEntity entity)
        {
            var planet = new Planet();
            planet._planetName = entity.Name;
            return planet;
        }

        private string _planetName;
        public string Name => _planetName;

        private string _distanceFromSol;
        public string DistanceFromSol => _distanceFromSol;
    }
}
