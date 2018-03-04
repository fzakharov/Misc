using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class HealerScenario : IScenario
    {
        private readonly GameConfiguration _configuration;

        public HealerScenario(GameConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Execute(HeroState hero)
        {
            hero.Health = _configuration.HealthToSet;
        }
    }
}