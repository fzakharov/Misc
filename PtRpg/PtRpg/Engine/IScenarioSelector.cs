namespace PtRpg.Engine
{
    public interface IScenarioSelector
    {
        IScenario GetByInput(char input);
    }
}