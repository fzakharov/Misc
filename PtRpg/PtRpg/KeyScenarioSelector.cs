using PtRpg.Engine;
using System;
using System.Collections.Generic;

namespace PtRpg
{
    public class KeyScenarioSelector : IScenarioSelector
    {
        Dictionary<int, IScenario> _bindings = new Dictionary<int, IScenario>();

        public IScenario GetByInput(int input)
        {
            if (!_bindings.ContainsKey(input))
                throw new GameException(
                    $"Unsupported command '{char.ConvertFromUtf32(input)}'");

            return _bindings[input];
        }

        internal void BindScenario(char v, MoneyScenario moneyScenario)
        {
            throw new NotImplementedException();
        }

        public void BindScenario(int input, IScenario scenario)
        {
            _bindings[input] = scenario;
        }
    }
}