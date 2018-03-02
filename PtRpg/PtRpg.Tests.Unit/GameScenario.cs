using System;

namespace PtRpg.Tests.Unit
{
    public class GameScenario
    {
        internal void Execute(HeroState hero)
        {
            hero.Health = 42;
        }
    }
}