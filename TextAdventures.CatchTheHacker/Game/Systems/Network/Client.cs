using System.Collections.Generic;
using TextAdventures.CatchTheHacker.Game.Systems.OperatingSystem;

namespace TextAdventures.CatchTheHacker.Game.Systems.Network
{
    public class Client
    {
        public string IP { get; set; }
        public OS OS { get; set; }
        public IEnumerable<string> KnownHosts { get; set; }

        public Client(string user)
        {
            IP = Network.GetRandomIP();
            OS = OS.GetRandomOS(user);
            KnownHosts = new List<string>();
        }

        public Client(string osName, string user, int accessLevel) {
            IP = Network.GetRandomIP();
            OS = new OS(osName, user, accessLevel);
            KnownHosts = new List<string>();
        }

        public void InstallNewOS(string osName, string user, int accessLevel) {
            OS = new OS(osName, user, accessLevel);
        }

        public override string ToString()
        {
            return $"OS: {OS.Name}, IP: {IP}";
        }
    }
}
