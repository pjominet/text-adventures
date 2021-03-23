using System;
using TextAdventures.CatchTheHacker.Game.Systems.Network;
using TextAdventures.CatchTheHacker.Infrastructure;

namespace TextAdventures.CatchTheHacker.Game.Characters
{
    public class NPC : Character
    {
        public int Wallet { get; set; }

        public NPC(int userId) : base(null, null) {
            Name = ConfigLoader.LoadGenericUsers(userId);
            Client = new Client(Name);
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            Wallet = rnd.Next(90) + 10;
        }

        protected NPC(string name, Client client, int wallet) : base(name, client)
        {
            Wallet = wallet;
        }

        public override string ToString()
        {
            return $"NAME={Name}, COMPUTER=({Client}), WALLET: {Wallet}";
        }
    }
}
