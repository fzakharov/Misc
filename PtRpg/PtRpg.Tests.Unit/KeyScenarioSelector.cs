using System;

namespace PtRpg.Tests.Unit
{
    public class KeyScenarioSelector
    {
        private char _input;
        private IScenario _scenario;

        public IScenario GetByInput(char input)
        {
            return _scenario;
        }

        internal void BindScenario(char input, IScenario scenario)
        {
            _input = input;
            _scenario = scenario;
        }
    }
}