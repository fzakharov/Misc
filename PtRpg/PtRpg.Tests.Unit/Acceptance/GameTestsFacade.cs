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
            Random = new StubRandom();
            Hud = new MockHud();
            var bootstrapper = new MsDiBootstrapper();
            _game = bootstrapper.CreateGame(Hud, _input, Random);
            Hero = bootstrapper.Settings.Hero;
            Settings = bootstrapper.Settings;
        }

        public HeroState Hero { get; }
        public MockHud Hud { get; }
        public StubRandom Random { get; }
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