using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class MoneyScenario : IScenario
    {
        private readonly GameConfiguration _configuration;

        public MoneyScenario(GameConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Execute(HeroState hero)
        {
            hero.Money = _configuration.MoneyToSet;
        }
    }
}