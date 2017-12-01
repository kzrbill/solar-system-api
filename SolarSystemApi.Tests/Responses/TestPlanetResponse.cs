using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SolarSystemApi.Tests
{
    internal class TestPlanetResponse
    {
        public static TestPlanetResponse FromResponseObject(IActionResult result)
        {
            var okResult = result as OkObjectResult;
            if (okResult == null)
                return null;

            var jsonStr = JsonConvert.SerializeObject(okResult.Value);
            return JsonConvert.DeserializeObject<TestPlanetResponse>(jsonStr);
        }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<TestStatResponse> Stats { get; set; }

        internal object GetStatValue(string statName)
        {
            return Stats.Find(s => s.Name == statName).Value;
        }
    }
}
