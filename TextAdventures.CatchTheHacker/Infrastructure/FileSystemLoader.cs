using System.IO;
using Newtonsoft.Json;
using TextAdventures.CatchTheHacker.Game.Systems.FileSystem;

namespace TextAdventures.CatchTheHacker.Infrastructure
{
    public class FileSystemLoader
    {
        private const string CONFIG_ROOT = "Configs";

        public static Node ParseFileSystem(string osName) {
            var configPath = Path.Combine(CONFIG_ROOT, $"{osName.ToLower()}_fs.json");

            var json = File.ReadAllText(configPath);

            return JsonConvert.DeserializeObject<Node>(json);
        }
    }
}
