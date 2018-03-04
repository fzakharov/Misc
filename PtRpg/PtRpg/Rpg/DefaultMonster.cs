using PtRpg.Engine;
using System;

namespace PtRpg.Rpg
{
    public class DefaultMonster : IMonster
    {
        private readonly IRandom _random;

        public DefaultMonster(IRandom random)
        {
            _random = random;
        }

        public bool IsWonVs(HeroState hero, MonsterConditions cond)
        {
            if (hero == null)
            {
                throw new System.ArgumentNullException(nameof(hero));
            }

            if (cond == null)
            {
                throw new System.ArgumentNullException(nameof(cond));
            }

            var heroProabability = Math.Min(
                cond.MinProbability + hero.Power * cond.PowerFactor,
                cond.MaxProbability);

            return heroProabability < _random.GenerateRealProbability();
        }
    }
}