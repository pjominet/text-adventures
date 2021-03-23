namespace TextAdventures.CatchTheHacker.Infrastructure.Settings
{
    public class SetupSettings
    {
        public int Difficulty { get; set; }
        public int MaxAllowedAccessLevel { get; set; }
        public int Sudo => MaxAllowedAccessLevel + 1;
        public int NetworkSize { get; set; }
        public int Turns { get; set; }
    }
}
