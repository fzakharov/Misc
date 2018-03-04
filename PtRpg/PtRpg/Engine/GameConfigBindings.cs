namespace PtRpg.Engine
{
    public class GameConfigBindings : IBindings
    {
        private readonly GameConfiguration _config;

        public GameConfigBindings(GameConfiguration config)
        {
            _config = config;
        }

        public bool Contains(char input)
        {
            foreach (var b in _config.Bindings)
            {
                if (b.Key == input)
                    return true;
            }

            return false;
        }

        public string GetName(char input)
        {
            foreach (var b in _config.Bindings)
            {
                if (b.Key == input)
                    return b.ScenarioTypeName;
            }

            throw new GameException($"Scenario for '{input}' not found.");
        }
    }
}