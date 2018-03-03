namespace PtRpg.Tests.Unit
{
    public class MockHud : IHud
    {
        public HeroState Hero { get; private set; }

        public void Update(HeroState hero)
        {
            Hero = hero;
        }

        public void Update(GameException ex)
        {
            throw new System.NotImplementedException();
        }
    }
}