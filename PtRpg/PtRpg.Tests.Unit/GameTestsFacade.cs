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

        public void ProcessInput(char input)
        {
             var scenario = _scenarioSelector.GetByInput(input);
            scenario.Execute(Hero);
        }
    }
}