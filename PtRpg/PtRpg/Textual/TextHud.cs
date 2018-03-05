using PtRpg.Engine;
using System.IO;

namespace PtRpg.Textual
{
    public class TextHud : IHud
    {
        TextWriter _tw;

        public TextHud(TextWriter tw)
        {
            _tw = tw;
        }

        public void Show(IScenario scenario)
        {
            if (scenario == null)
            {
                throw new System.ArgumentNullException(nameof(scenario));
            }

            _tw.Write($" - {scenario.GetType().Name}");
            _tw.WriteLine();
        }

        public void ShowScenarios(GameConfiguration config)
        {
            if (config == null)
            {
                throw new System.ArgumentNullException(nameof(config));
            }

            _tw.WriteLine("Scenarios:");
            foreach (var b in config.Bindings)
            {
                _tw.WriteLine($"{b.Key} - {b.ScenarioTypeName}");
            }

            _tw.WriteLine();
        }

        public void Update(HeroState hero)
        {
            if (hero == null)
            {
                throw new System.ArgumentNullException(nameof(hero));
            }

            _tw.WriteLine($"MaxHealth: {hero.MaxHealth}");
            _tw.WriteLine($"Health: {hero.Health}");
            _tw.WriteLine($"Power: {hero.Power}");
            _tw.WriteLine($"Money: {hero.Money}");
            _tw.WriteLine($"Items: {hero.Items}");
            _tw.WriteLine();
        }

        public void Update(GameException ex)
        {
            if (ex == null)
            {
                throw new System.ArgumentNullException(nameof(ex));
            }

            _tw.WriteLine();
            _tw.WriteLine(ex.Message);
            _tw.WriteLine();
        }
    }
}