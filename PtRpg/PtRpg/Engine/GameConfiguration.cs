namespace PtRpg.Engine
{
    public class GameConfiguration
    {
        public int HealthToSet = 42;
        public int MoneyToSet = 500;

        public KeyBinding[] Bindings = new KeyBinding[0];
    }

    public class KeyBinding
    {
        public char Key;
        public string ScenarioTypeName;
    }
}