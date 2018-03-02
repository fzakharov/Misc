namespace PtRpg.Tests.Unit
{
    public class GameAcceptaceTestsFacade
    {
        private KeyScenarioSelector _scenarioSelector;

        public GameAcceptaceTestsFacade()
        {
            Hero = new HeroState();
            _scenarioSelector = new KeyScenarioSelector();
        }

        public HeroState Hero { get; internal set; }

        public void ProcessInput(char input)
        {
             var scenario = _scenarioSelector.GetByInput(input);
            scenario.Execute(Hero);
        }
    }
}