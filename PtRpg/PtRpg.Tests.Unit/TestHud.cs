namespace PtRpg.Tests.Unit
{
    public class TestHud : IHud
    {
        public HeroState Hero { get; private set; }

        public void Update(HeroState hero)
        {
            Hero = hero;
        }
    }
}