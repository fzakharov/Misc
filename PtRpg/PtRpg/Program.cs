using PtRpg.Engine;
using PtRpg.Rpg;
using PtRpg.Textual;
using System;

namespace PtRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            var hero = new HeroState();
            GameConfiguration config = new GameConfiguration
            {
                Bindings = new[] {
                    new KeyBinding{
                        Key = 'h',
                        ScenarioTypeName = typeof(HealthScenario).Name
                    },
                    new KeyBinding{
                        Key = 'm',
                        ScenarioTypeName = typeof(MoneyScenario).Name
                    }
                }
            };

            var bs = new MsDiBootstrapper();
            var game = bs.CreateGame(
                                hero,
                                new TextHud(Console.Out),
                                new ConsoleInput(),
                                config);

            while (true)
                game.NextStep();
        }
    }
}
