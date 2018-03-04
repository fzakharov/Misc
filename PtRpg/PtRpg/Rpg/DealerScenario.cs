using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class DealerScenario : IScenario
    {
        private DealerConditions _cond;
        private IRandom _random;

        public DealerScenario(DealerConditions cond, IRandom random)
        {
            _cond = cond;
            _random = random;
        }

        public void Execute(HeroState hero)
        {
            if (hero == null)
            {
                throw new System.ArgumentNullException(nameof(hero));
            }

            if (_cond.Cost > hero.Money)
                throw new GameException($"Not enough money. Cost: {_cond.Cost}.");

            hero.MaxHealth = hero.MaxHealth + _cond.MaxHealthMinIncrease +
                (int)((_cond.MaxHealthMaxIncrease - _cond.MaxHealthMinIncrease) *
                    _random.GenerateRealProbability()
                );
            hero.Money -= _cond.Cost;
        }
    }
}