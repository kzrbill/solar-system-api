using System;

namespace SolarSystemApi.Services
{
    public class PlanetEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string ImageUrl { get; set; }
        public long MinDistanceFromSolKm { get; set; }
        public long MaxDistanceFromSolKm { get; set; }
        public string MassKg { get; set; }
        public uint DiameterKm { get; set; }
        public uint TemperatureMeanKelvin { get; set; }
        public string VolumeKm3 { get; set; }
    }
}
