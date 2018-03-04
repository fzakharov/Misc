using System;

namespace PtRpg.Engine
{
    public interface IHud
    {
        // todo show help
        void Update(HeroState hero);
        void Update(GameException ex);
        void Show(IScenario scenario);
    }
}
