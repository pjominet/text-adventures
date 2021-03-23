using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TextAdventures.CatchTheHacker.Game.Characters;

namespace TextAdventures.CatchTheHacker.Game.Systems.Network
{
    public class Network
    {
        public Dictionary<string, Client> AddressTable { get; set; }

        public Network(int size)
        {
            AddressTable = new Dictionary<string, Client>();
            for (var i = 0; i < size; i++)
            {
                var client = new NPC(i).Client;
                AddressTable.Add(client.IP, client);
            }

            CreateMeshTopology();
        }

        public void AddClient(Client computer)
        {
            AddressTable.Add(computer.IP, computer);
        }

        public Client GetClient(string ip)
        {
            return AddressTable.ContainsKey(ip) ? AddressTable[ip] : null;
        }

        public static string GetRandomIP()
        {
            const int min = 10;
            const int max = 250;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var parts = new int[4];
            for (var i = 0; i < parts.Length; i++)
                parts[i] = rnd.Next(max - min) + min;

            return string.Join('.', parts);
        }

        private void CreateMeshTopology()
        {
            foreach (var (ip, client) in AddressTable)
            {
                var knownHosts = new List<string>();
                for (var i = 0; i < 4 /*- DIFFICULTY*/; i++)
                    knownHosts.Add(ip);

                client.KnownHosts = knownHosts;
            }
        }

        private bool IsValidIP(string ip)
        {
            return Regex.IsMatch(ip, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
        }

        public bool IsComputerAt(string ip)
        {
            return IsValidIP(ip) && AddressTable.ContainsKey(ip);

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var index = 0;
            foreach (var (ip, client) in AddressTable)
            {
                sb.Append(ip);
                if (++index % 4 == 0)
                    sb.Append('\n');
                else sb.Append("  ");
            }
            return sb.ToString();
        }
    }
}
