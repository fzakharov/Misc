using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;
using System;
using System.Collections.Generic;

namespace PtRpg
{
    public class KeyScenarioSelector : IScenarioSelector
    {
        private readonly IEnumerable<IScenario> _scenarios;
        private readonly IBindings _bindings;

        public KeyScenarioSelector(IEnumerable<IScenario> scenarios, IBindings bindings)
        {
            _scenarios = scenarios;
            _bindings = bindings;
        }

        public IScenario GetByInput(int input)
        {
            if (!_bindings.Contains(input))
                throw new GameException(
                    $"Unsupported command '{char.ConvertFromUtf32(input)}'");

            var name = _bindings.GetName(input);
            foreach (var item in _scenarios)
            {
                if (item.GetType().Name == name)
                    return item;
            }

            throw new GameException($"Unknown scenario {name}.");
        }
    }
}