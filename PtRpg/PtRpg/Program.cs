using PtRpg.Engine;
using PtRpg.Textual;
using System;

namespace PtRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            var boot = new MsDiBootstrapper();

            Console.Write("Start game? (y = yes):"); // todo move restart to game loop with tests?
            var key = Console.ReadLine();

            while (key == "y")
            {
                var game = boot.CreateGame(
                    new TextHud(Console.Out),
                    new ConsoleInput(),
                    new DotNetRandom());

                while (game.NextStep()) ;

                Console.Write("You dead. Restart game? (y = yes):");
                key = Console.ReadLine();
            }
        }
    }
}
