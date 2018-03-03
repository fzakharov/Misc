using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private GameLoop _game;

        public GameTestsFacade(IInput input, IInputWriter writer, IBindings bindings, IScenario[] scenarios)
        {
            Hero = new HeroState();
            Hud = new MockHud();
            Writer = writer;
            _game = new GameLoop(
                Hud, 
                Hero, 
                new KeyScenarioSelector(scenarios, bindings), 
                input);
        }

        public HeroState Hero { get; internal set; }
        public MockHud Hud { get; internal set; }
        public IInputWriter Writer { get; private set; }

        public void UserPressed(int c)
        {
            Writer.Write(c);
            _game.NextStep();
        }
    }
}