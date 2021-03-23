using System;
using System.Collections.Generic;
using System.Text;
using TextAdventures.CatchTheHacker.Game.Systems.Network;
using TextAdventures.CatchTheHacker.Game.Systems.OperatingSystem;
using TextAdventures.CatchTheHacker.Infrastructure;

namespace TextAdventures.CatchTheHacker.Game.Characters
{
    public class Player : Character
    {
        public Dictionary<string, Command> KnownCommands { get; set; }
        public int Skill { get; set; }

        public Player(string name, Client client, int skill): base(name, client) {
            Skill = skill;
            InitDefaultCommands();
        }

        private void InitDefaultCommands() {
            var defaultCommands = ConfigLoader.LoadPlayerDefaultCommands();
            KnownCommands = new Dictionary<string, Command>();
            foreach(var command in defaultCommands)
                KnownCommands.Add(command.Name, command);
        }

        public string ListAvailableCommands(string osName) {
            var sb = new StringBuilder();
            sb.Append(osName).Append(": ");
            foreach (var (name, command) in KnownCommands) {
                if (command.OSName == osName)
                    sb.Append(name).Append(' ');
            }
            return sb.ToString();
        }

        public Dictionary<string, Command> GetAvailableCommands() {
            var availableCommands = new Dictionary<string, Command>();
            foreach (var (name, command) in KnownCommands) {
                if (command.OSName == Client.OS.Name)
                    availableCommands.Add(name, command);
            }
            return availableCommands;
        }

        public void LearnCommand(Command cmd) {
            KnownCommands.Add(cmd.Name, cmd);
        }

        public void ChangeOS(string osName, string user) {
            Client.InstallNewOS(osName, user, Skill);
        }
    }
}
