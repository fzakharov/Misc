using System;
using System.Collections.Generic;

namespace PtRpg.Tests.Unit
{
    public class KeyScenarioSelector
    {
        Dictionary<char, IScenario> _bindings = new Dictionary<char, IScenario>();

        public IScenario GetByInput(char input)
        {
            return _bindings[input];
        }

        public void BindScenario(char input, IScenario scenario)
        {
            _bindings[input] = scenario;
        }
    }
}