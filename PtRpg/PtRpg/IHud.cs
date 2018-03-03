using System;

namespace PtRpg
{
    public interface IHud
    {
        void Update(HeroState hero);
        void Update(GameException ex);
    }
}
