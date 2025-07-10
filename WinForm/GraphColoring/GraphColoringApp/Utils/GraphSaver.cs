using System.IO;
using Newtonsoft.Json;
using GraphColoringApp.Models;

namespace GraphColoringApp.Utils
{
    public static class GraphSaver
    {
        public static void Save(string path, GraphData data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public static GraphData Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<GraphData>(json);
        }
    }
}
