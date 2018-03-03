using System.Collections.Generic;

namespace PtRpg
{
    public class KeyScenarioSelector : IScenarioSelector<int>
    {
        Dictionary<int, IScenario> _bindings = new Dictionary<int, IScenario>();

        public IScenario GetByInput(int input)
        {
            if (!_bindings.ContainsKey(input))
                throw new GameException(
                    $"Unsupported command '{char.ConvertFromUtf32(input)}'");

            return _bindings[input];
        }

        public void BindScenario(int input, IScenario scenario)
        {
            _bindings[input] = scenario;
        }
    }
}