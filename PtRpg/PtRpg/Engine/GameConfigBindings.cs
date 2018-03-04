namespace PtRpg.Engine
{
    public class GameConfigBindings : IBindings
    {
        private readonly KeyBinding[] _bindings;

        public GameConfigBindings(GameConfiguration config)
        {
            _bindings = config.Bindings ?? new KeyBinding[0];
        }

        public bool Contains(char input)
        {
            foreach (var b in _bindings)
            {
                if (b.Key == input)
                    return true;
            }

            return false;
        }

        public string GetName(char input)
        {
            foreach (var b in _bindings)
            {
                if (b.Key == input)
                    return b.ScenarioTypeName;
            }

            throw new GameException($"Scenario for '{input}' not found.");
        }
    }
}