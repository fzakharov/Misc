using PtRpg.Engine;
using System;

namespace PtRpg.Rpg
{
    public abstract class MoneyScenarioBase<T>
        : IScenario where T : MoneyConditions
    {
        protected T _cond;

        protected MoneyScenarioBase(T cond)
        {
            _cond = cond;
        }

        public void Execute(HeroState hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException(nameof(hero));
            }
            Check(hero);
            ExecuteScenario(hero);
            TakeMoney(hero);

        }

        protected virtual void Check(HeroState hero)
        {
            if (_cond.Cost > hero.Money)
                throw new GameException($"Not enough money. Cost: {_cond.Cost}.");
        }

        protected abstract void ExecuteScenario(HeroState hero);

        protected virtual void TakeMoney(HeroState hero)
        {
            hero.Money -= _cond.Cost;
        }

        protected static int CalcNewValueInRangeWithProbability(int value, int minIncrease, int maxIncrease, double probability)
        {
            return value + minIncrease +
                (int)Math.Round(((maxIncrease - minIncrease) * probability));
        }
    }
}