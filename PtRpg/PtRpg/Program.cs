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
            var boot = new MsDiBootstrapper();

            var game = boot.CreateGame(
                new TextHud(Console.Out),
                new ConsoleInput(),
                new DotNetRandom());

            while (true)
                game.NextStep();
        }
    }
}
