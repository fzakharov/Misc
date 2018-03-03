using PtRpg.Engine;
using System;

namespace PtRpg
{
    public class ConsoleInput : IInput
    {
        public int Read()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
