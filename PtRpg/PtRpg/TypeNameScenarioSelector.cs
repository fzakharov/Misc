using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;
using System;
using System.Collections.Generic;

namespace PtRpg
{
    public class TypeNameScenarioSelector : IScenarioSelector
    {
        private readonly IEnumerable<IScenario> _scenarios;
        private readonly IBindings _bindings;

        public TypeNameScenarioSelector(IEnumerable<IScenario> scenarios, IBindings bindings)
        {
            _scenarios = scenarios;
            _bindings = bindings;
        }

        public IScenario GetByInput(char input)
        {
            if (!_bindings.Contains(input))
                throw new GameException(
                    $"Unsupported command '{input}'");

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