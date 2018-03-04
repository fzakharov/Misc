using PtRpg.Engine;
using System.Collections.Generic;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private TestInput _input;
        private GameLoop _game;

        public GameTestsFacade()
        {
            _input = new TestInput();
            Hud = new MockHud();
            var bootstrapper = new MsDiBootstrapper();
            _game = bootstrapper.CreateGame(Hud, _input);
            Hero = bootstrapper.Settings.Hero;
            Settings = bootstrapper.Settings;
        }

        public HeroState Hero { get; internal set; }
        public MockHud Hud { get; internal set; }
        public GameConfiguration Settings { get; }
        public char GetInputByScenario<T>()
        {
            var scenarioName = typeof(T).Name;

            foreach (var b in Settings.Bindings)
            {
                if (b.ScenarioTypeName == scenarioName)
                    return b.Key;
            }

            throw new KeyNotFoundException($"Binding '{scenarioName}' not found");
        }

        public void UserPressed(char c)
        {
            _input.Write(c);
            _game.NextStep();
        }
    }
}