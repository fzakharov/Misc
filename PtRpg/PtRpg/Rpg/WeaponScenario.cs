using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class WeaponScenario : IScenario
    {
        private WeaponConditions _cond;
        private IRandom _random;

        public WeaponScenario(WeaponConditions cond, IRandom random)
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

            hero.Power = hero.Power + _cond.PowerMinIncrease +
                (int)((_cond.PowerMaxIncrease - _cond.PowerMinIncrease) *
                    _random.GenerateRealProbability()
                );
            hero.Money -= _cond.Cost;
            hero.Items++;
        }
    }
}