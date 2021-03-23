using System.Collections.Generic;
using TextAdventures.CatchTheHacker.Game.Characters;
using TextAdventures.CatchTheHacker.Game.Systems.Network;

namespace TextAdventures.CatchTheHacker.Game
{
    public class Game
    {
        private Player player;
        private Hacker hacker;
        private Network network;

        private Dictionary<string, string> initConfig;

        public Game()
        {
            //initConfig = ConfigLoader.LoadSetupConfig();
        }
    }
}
