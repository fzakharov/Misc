using System;

namespace PtRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            var selector = new KeyScenarioSelector();
            var hero = new HeroState();
            selector.BindScenario('m', new MoneyScenario { MoneyToSet = 500 });
            selector.BindScenario('h', new HealthScenario { HealthToSet = 42 });
            var hud = new TextHud(Console.Out);


            var game = new GameLoop(hud, hero, selector, new ConsoleInput());

            while (true)
                game.NextStep();
        }
    }

    public class ConsoleInput : IInput
    {
        public int Read()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
