using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class MonsterScenario : IScenario
    {
        private MonsterConditions _cond;
        private IRandom _random;
        private IMonster _monster;

        public MonsterScenario(MonsterConditions cond, IMonster monster, IRandom random)
        {
            _cond = cond;
            _random = random;
            _monster = monster;
        }

        public void Execute(HeroState hero)
        {
            if (hero == null)
            {
                throw new System.ArgumentNullException(nameof(hero));
            }

            if (_monster.IsWonVs(hero, _cond))
            {
                hero.Health -= _cond.LossHealthLost;
            }
            else
            {
                hero.Health -= _cond.WinHealthLost;
                hero.Money += _cond.WinMoney;
            }
        }
    }
}