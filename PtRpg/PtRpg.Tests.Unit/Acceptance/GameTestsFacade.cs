using PtRpg.Engine;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private TestInput _input;
        private GameLoop _game;

        public GameTestsFacade()
        {
            _input = new TestInput();
            Hud = new MockHud();
            var bootstrapper = new MsDiBootstrapper();
            _game = bootstrapper.CreateGame(Hud, _input);
            Hero = bootstrapper.Settings.Hero;
            Settings = bootstrapper.Settings;
        }

        public HeroState Hero { get; internal set; }
        public MockHud Hud { get; internal set; }
        public GameConfiguration Settings { get; }

        public void UserPressed(char c)
        {
            _input.Write(c);
            _game.NextStep();
        }
    }
}