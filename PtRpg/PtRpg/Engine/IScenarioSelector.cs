namespace PtRpg.Engine
{
    public interface IScenarioSelector
    {
        IScenario GetByInput(int input);
    }
}