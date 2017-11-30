using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SolarSystemApi.Services
{
    internal class PlanetsJsonFile
    {
        public static PlanetsJsonFile Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("SolarSystemApi.Services.Resources.Planets.json");
            var jsonStr = new StreamReader(resourceStream, Encoding.UTF8).ReadToEnd();

            return new PlanetsJsonFile(jsonStr);
        }

        private readonly JToken _json;
        private PlanetsJsonFile(string json)
        {
            _json = JObject.Parse(json);
        }

        public JToken Json()
        {
            return _json;
        }
    }
}
