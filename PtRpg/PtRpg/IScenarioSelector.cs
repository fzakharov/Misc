namespace PtRpg
{
    public interface IScenarioSelector<T>
    {
        IScenario GetByInput(T input);
    }
}