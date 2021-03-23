using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextAdventures.CatchTheHacker.Game.Systems.OperatingSystem;

namespace TextAdventures.CatchTheHacker.Infrastructure
{
    public class ConfigLoader
    {
        private const string CONFIG_ROOT = "Configs";

        public static List<Command> LoadCommandSet(string os)
        {
            var configPath = Path.Combine(CONFIG_ROOT, $"{os.ToLower()}_cs.config");
            var commandSet = new List<Command>();

            try
            {
                var lines = File.ReadAllLines(configPath);
                const string pattern = @"([a-z]+):(.*):(.+)";
                var regex = new Regex(pattern, RegexOptions.Compiled);
                foreach (var line in lines)
                {
                    var match = regex.Match(line);
                    if (!match.Success) continue;

                    var paramString = match.Groups[2].Value;
                    string[] @params = null;
                    if (!string.IsNullOrWhiteSpace(paramString))
                        @params = paramString.Split(',');

                    commandSet.Add(new Command(match.Groups[1].Value, @params, match.Groups[3].Value, os));
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("No file found at: " + configPath);
                Environment.Exit(1);
            }

            return commandSet;
        }

        public static List<Command> LoadPlayerDefaultCommands()
        {
            var configPath = Path.Combine(CONFIG_ROOT, "player_defaults.config");
            var defaultCommandSet = new List<Command>();

            try
            {
                var lines = File.ReadAllLines(configPath);
                const string pattern = @"([A-Z]+):(.*)";

                var regex = new Regex(pattern, RegexOptions.Compiled);
                foreach (var line in lines)
                {
                    var match = regex.Match(line);
                    if (!match.Success) continue;

                    var os = match.Groups[1].Value;
                    var commandSet = LoadCommandSet(os);
                    var defaultCommands = match.Groups[2].Value.Split(',');

                    foreach (var defaultCommand in defaultCommands)
                    {
                        defaultCommandSet.AddRange(commandSet.Where(command => defaultCommand.Equals(command.Name)));
                    }
                }
            } catch (IOException e) {
                Console.Error.WriteLine("No file found at: " + configPath);
                Environment.Exit(1);
            }
            return defaultCommandSet;
        }

        public static string LoadGenericUsers(int userId)
        {
            var configPath = Path.Combine(CONFIG_ROOT, "users.list");
            var userName = "";
            var lineNbr = 0;

            try
            {
                var lines = File.ReadAllLines(configPath);
                foreach (var line in lines)
                {
                    userName = line;
                    if (lineNbr++ == userId) break;
                }
            } catch (IOException e) {
                Console.Error.WriteLine("No user list found at: " + configPath);
            }

            return userName;
        }
    }
}
