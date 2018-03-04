using PtRpg.Engine;
using System;

namespace PtRpg.Rpg
{
    public class HealerScenario : IScenario
    {
        private HealerConditions _cond;
        private readonly IRandom _random;

        public HealerScenario(HealerConditions cond, IRandom random)
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

            hero.Money -= _cond.Cost;
            var delta = _cond.MaxHealthIncrease * _random.GenerateRealProbability();

            hero.Health = Math.Min(hero.Health + (int)delta, hero.MaxHealth);
        }
    }
}