using Microsoft.Extensions.DependencyInjection;
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


            //var serviceProvider = new ServiceCollection()
            //.AddSingleton<IFooService, FooService>()
            //.AddSingleton<IBarService, BarService>()
            //.BuildServiceProvider();


            //var selector = new KeyScenarioSelector();
            //var hero = new HeroState();
            //selector.BindScenario('m', new MoneyScenario { MoneyToSet = 500 });
            //selector.BindScenario('h', new HealthScenario { HealthToSet = 42 });
            //var hud = new TextHud(Console.Out);

            //var game = new GameLoop(hud, hero, selector, new ConsoleInput());

            //while (true)
            //    game.NextStep();
        }
    }
}
