using System;
using System.Collections.Generic;
using TextAdventures.CatchTheHacker.Game.Systems.FileSystem;

namespace TextAdventures.CatchTheHacker.Game.Systems.OperatingSystem
{
    public class OS
    {
        public string Name { get; set; }
        public Dictionary<string, Command> CommandSet { get; set; }
        public Node FsRoot { get; set; }
        public string User { get; set; }
        public int AccessLevel { get; set; }

        public OS(string name, string user, int accessLevel)
        {
            Name = name;
            User = user;
            AccessLevel = accessLevel;
        }

        public static OS GetRandomOS(string user) {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var osChoice = rnd.Next(3);
            var minAllowedAccessLevel = 1 /*+ DIFFICULTY*/;
            var accessLevel = rnd.Next(/*MAX_ALLOWED_ACCESSLEVEL - */minAllowedAccessLevel) + minAllowedAccessLevel;

            return osChoice switch
            {
                0 => new OS("DOORS", user, accessLevel),
                1 => new OS("OSY", user, accessLevel),
                _ => new OS("LOONIX", user, accessLevel)
            };
        }
    }
}
