using System.Collections.Generic;

namespace PtRpg
{
    public class KeyScenarioSelector
    {
        Dictionary<int, IScenario> _bindings = new Dictionary<int, IScenario>();

        public IScenario GetByInput(int input)
        {
            return _bindings[input];
        }

        public void BindScenario(int input, IScenario scenario)
        {
            _bindings[input] = scenario;
        }
    }
}