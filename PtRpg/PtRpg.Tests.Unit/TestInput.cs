namespace PtRpg.Tests.Unit
{
    public class TestInput : IInput, IInputWriter
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
