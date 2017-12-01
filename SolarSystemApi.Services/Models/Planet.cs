using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SolarSystemApi.Services
{
    public interface IPlanet
    {
        string Name { get; }
        string ImageUrl { get; }
        IList<IPlanetStat> Stats { get; }
    }

    public interface IPlanetStat
    {
        string Name { get; }
        object Value { get; }
    }

    public class Planet : IPlanet
    {
        private PlanetEntity _entity;
        private IList<IPlanetStat> _stats;

        public static IPlanet WithEntity(PlanetEntity entity)
        {
            var planet = new Planet
            {
                _entity = entity,
                _stats = new List<IPlanetStat>() 
            };

            planet
            .AddStat(new PlanetStat()
            {
                Name = "DistanceFromSol",
                Value = $"{entity.MinDistanceFromSolKm} / {entity.MaxDistanceFromSolKm} km"
            })
            .AddStat(new PlanetStat()
            {
                Name = "OrbitalDeviation",
                Value = $"{(entity.MaxDistanceFromSolKm - entity.MinDistanceFromSolKm)} km"
            })
            .AddStat(new PlanetStat()
            {
                Name = "Mass",
                Value = $"{entity.MassKg} kg"
            })
            .AddStat(new PlanetStat()
            {
                Name = "Diameter",
                Value = $"{entity.DiameterKm} km"
            })
            .AddStat(new PlanetStat()
            {
                Name = "Surface Temperature (mean)",
                Value = $"{entity.TemperatureMeanKelvin} K"
            })
            .AddStat(new PlanetStat()
            {
                Name = "Volume",
                Value = $"{entity.VolumeKm3} km³"
            });;

            return planet;
        }


        private Planet AddStat(IPlanetStat stat){
            _stats.Add(stat);
            return this;
        }

        public string Name => _entity.Name;
        public string ImageUrl => _entity.ImageUrl;
        public IList<IPlanetStat> Stats => _stats;
    }

    public class PlanetStat : IPlanetStat
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
