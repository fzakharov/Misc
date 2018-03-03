using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class HealthScenario : IScenario
    {
        private readonly GameConfiguration _configuration;

        public HealthScenario(GameConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Execute(HeroState hero)
        {
            hero.Health = _configuration.HealthToSet;
        }
    }
}