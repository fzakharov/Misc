namespace PtRpg.Engine
{
    public interface IBindings
    {
        bool Contains(char input);
        string GetName(char input);
    }
}