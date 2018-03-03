namespace PtRpg.Tests.Unit
{
    public class GameTestsFacade
    {
        private KeyScenarioSelector _scenarioSelector;
        private GameLoop _game;

        public GameTestsFacade(
            KeyScenarioSelector scenarioSelector, 
            IInput input, 
            IInputWriter writer)
        {
            Hero = new HeroState();
            Hud = new MockHud();
            _scenarioSelector = scenarioSelector;
            Writer = writer;
            _game = new GameLoop(Hud, Hero, _scenarioSelector, input);
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