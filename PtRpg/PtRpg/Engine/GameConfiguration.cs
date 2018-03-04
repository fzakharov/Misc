namespace PtRpg.Engine
{
    public class GameConfiguration
    {
        public HeroState Hero { get; set; }
        public int HealthToSet { get; set; }
        public int MoneyToSet { get; set; }

        public KeyBinding[] Bindings { get; set; }
    }

    public class KeyBinding
    {
        public char Key { get; set; }
        public string ScenarioTypeName { get; set; }
    }
}