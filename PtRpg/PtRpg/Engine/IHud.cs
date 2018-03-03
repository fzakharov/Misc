using System;

namespace PtRpg.Engine
{
    public interface IHud
    {
        void Update(HeroState hero);
        void Update(GameException ex);
    }
}
