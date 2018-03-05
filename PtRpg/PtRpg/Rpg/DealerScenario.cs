using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class DealerScenario : MoneyScenarioBase<DealerConditions>
    {
        private IRandom _random;

        public DealerScenario(DealerConditions cond, IRandom random)
            : base(cond)
        {
            _random = random;
        }

        protected override void ExecuteScenario(HeroState hero)
        {
            hero.MaxHealth = hero.MaxHealth + _cond.MaxHealthMinIncrease +
                (int)((_cond.MaxHealthMaxIncrease - _cond.MaxHealthMinIncrease) *
                    _random.GenerateRealProbability());
        }
    }
}