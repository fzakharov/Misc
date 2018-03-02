namespace PtRpg
{
    public class MoneyScenario : IScenario
    {
        public int MoneyToSet { get; set; }

        public void Execute(HeroState hero)
        {
            hero.Money = MoneyToSet;
        }
    }
}