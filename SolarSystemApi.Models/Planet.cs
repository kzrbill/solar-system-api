using System;

namespace SolarSystemApi.Models
{
    public interface IPlanet
    {
        string Name { get; }
    }

    public class Planet : IPlanet
    {
        private readonly string _planetName;
        public Planet(string planetName)
        {
            _planetName = planetName;
        }

        public string Name => _planetName;
    }
}
