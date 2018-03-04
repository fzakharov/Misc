using PtRpg.Engine;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class TestInput : IInput
    {
        char _input;

        public char Read()
        {
            return _input;
        }

        public void Write(char c)
        {
            _input = c;
        }
    }
}
