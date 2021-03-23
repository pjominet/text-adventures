using System.IO;
using System.Threading.Tasks;

namespace TextAdventures.CatchTheHacker.Infrastructure
{
    public class SavegameWriter
    {
        public static async Task WriteSavegameFile(string writable, string path)
        {
            await File.WriteAllTextAsync(path, writable);
        }
    }
}
