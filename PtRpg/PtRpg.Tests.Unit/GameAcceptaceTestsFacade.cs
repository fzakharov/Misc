using System;

namespace PtRpg.Tests.Unit
{
    public class GameAcceptaceTestsFacade
    {
        public GameAcceptaceTestsFacade()
        {
            Hero = new HeroState();
        }

        public HeroState Hero { get; internal set; }

        internal void ProcessInput(char input)
        {
            Hero.Health = 42;
        }
    }
}