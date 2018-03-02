namespace PtRpg.Tests.Unit
{
    public class GameTestsFacade
    {
        private KeyScenarioSelector _scenarioSelector;

        public GameTestsFacade(KeyScenarioSelector scenarioSelector)
        {
            Hero = new HeroState();
            _scenarioSelector = scenarioSelector;
        }

        public HeroState Hero { get; internal set; }
        public IHud Hud { get; internal set; }

        public void UserPressed(char c)
        {
            var scenario = _scenarioSelector.GetByInput(c);
            scenario.Execute(Hero);
        }
    }
}