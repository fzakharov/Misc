using PtRpg.Engine;

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
                throw new System.ArgumentNullException(nameof(hero));
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
    }
}