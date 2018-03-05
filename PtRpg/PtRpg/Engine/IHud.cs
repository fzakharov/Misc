using System.Collections.Generic;

namespace PtRpg.Engine
{
    public interface IHud
    {
        void Update(HeroState hero);
        void Update(GameException ex);
        void Show(IScenario scenario);
        void ShowScenarios(GameConfiguration config);
    }
}
