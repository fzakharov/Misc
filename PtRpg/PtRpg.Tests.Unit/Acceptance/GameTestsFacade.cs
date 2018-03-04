using PtRpg.Engine;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private TestInput _input;
        private GameLoop _game;

        public GameTestsFacade(GameConfiguration configuration)
        {
            Hero = new HeroState();
            Hud = new MockHud();
            _input = new TestInput();
            var bootstrapper = new MsDiBootstrapper();
            _game = bootstrapper.CreateGame(Hero, Hud, _input, configuration);

        }

        public HeroState Hero { get; internal set; }
        public MockHud Hud { get; internal set; }

        public void UserPressed(char c)
        {
            _input.Write(c);
            _game.NextStep();
        }
    }
}