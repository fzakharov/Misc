using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class WeaponScenario : MoneyScenarioBase<WeaponConditions>
    {
        private IRandom _random;

        public WeaponScenario(WeaponConditions cond, IRandom random)
            : base(cond)
        {
            _random = random;
        }

        protected override void ExecuteScenario(HeroState hero)
        {
            hero.Power = hero.Power + _cond.PowerMinIncrease +
                (int)((_cond.PowerMaxIncrease - _cond.PowerMinIncrease) *
                    _random.GenerateRealProbability());
        }
    }
}