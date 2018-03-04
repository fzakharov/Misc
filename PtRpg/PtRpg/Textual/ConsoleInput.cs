using PtRpg.Engine;
using System;

namespace PtRpg
{
    public class ConsoleInput : IInput
    {
        public char Read()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
