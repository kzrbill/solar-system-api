using System;
using Newtonsoft.Json.Linq;

namespace SolarSystemApi.Models
{
    public interface IPlanet
    {
        string Name { get; }
    }

    public class Planet : IPlanet
    {
        public static IPlanet WithToken(JToken planetJson)
        {
            var planet = new Planet();
            planet._planetName = (string)planetJson["name"];
            return planet;
        }

        private string _planetName;
        public string Name => _planetName;

        private string _distanceFromSol;
        public string DistanceFromSol => _distanceFromSol;
    }
}
