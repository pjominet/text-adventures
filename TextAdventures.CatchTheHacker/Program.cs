using System.IO;
using Microsoft.Extensions.Configuration;

namespace TextAdventures.CatchTheHacker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("Configs", "appsettings.json"), false, true)
                .Build();
        }
    }
}
