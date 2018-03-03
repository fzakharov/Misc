using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private GameLoop _game;

        public GameTestsFacade(IBindings bindings, GameConfiguration configuration)
        {
            Hero = new HeroState();
            Hud = new MockHud();
            var input = new TestInput();
            Writer = input;
            _game = new GameLoop(
                Hud, 
                Hero, 
                new KeyScenarioSelector(
                    new IScenario[] {
                        new HealthScenario(configuration),
                        new MoneyScenario(configuration) }, 
                    bindings), 
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