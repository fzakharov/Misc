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
            hero.Power = CalcNewValueInRangeWithProbability(
                hero.Power, 
                _cond.PowerMinIncrease, 
                _cond.PowerMaxIncrease, 
                _random.GenerateRealProbability());
        }
    }
}