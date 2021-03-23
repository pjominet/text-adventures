using TextAdventures.CatchTheHacker.Game.Systems.Network;

namespace TextAdventures.CatchTheHacker.Game.Characters
{
    public class Hacker : NPC
    {
        public Hacker(string name, Client client) : base(name, client, 0) { }

        public void StealCoins(NPC npc, int amount)
        {
            Wallet += amount;
            npc.Wallet -= amount;
        }
    }
}
