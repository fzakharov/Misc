using PtRpg.Engine;

namespace PtRpg.Rpg
{
    public class HealthScenario : IScenario
    {
        public int HealthToSet;

        public void Execute(HeroState hero)
        {
            hero.Health = HealthToSet;
        }
    }
}