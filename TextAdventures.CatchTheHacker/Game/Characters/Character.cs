using TextAdventures.CatchTheHacker.Game.Systems.Network;

namespace TextAdventures.CatchTheHacker.Game.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public Client Client { get; set; }

        protected Character(string name, Client client)
        {
            Name = name;
            Client = client;
        }

        public override string ToString()
        {
            return $"NAME={Name}, COMPUTER=({Client})";
        }
    }
}
