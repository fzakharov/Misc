using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public interface IMonster
    {
        bool IsWonVs(HeroState hero, MonsterConditions cond);
    }
}