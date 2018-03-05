using PtRpg.Engine;
using System;

namespace PtRpg.Rpg
{
    public class HealerScenario : MoneyScenarioBase<HealerConditions>
    {
        private readonly IRandom _random;

        public HealerScenario(HealerConditions cond, IRandom random)
            : base(cond)
        {
            _random = random;
        }

        protected override void ExecuteScenario(HeroState hero)
        {
            var delta = _cond.MaxHealthIncrease * _random.GenerateRealProbability();
            hero.Health = Math.Min(hero.Health + (int)delta, hero.MaxHealth);
        }
    }
}