using PtRpg.Engine;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class MockHud : IHud
    {
        public HeroState Hero { get; private set; }

        public void Show(IScenario scenario)
        {
        }

        public void ShowScenarios(GameConfiguration config)
        {
        }

        public void Update(HeroState hero)
        {
            Hero = hero;
        }

        public void Update(GameException ex)
        {
            
        }
    }
}