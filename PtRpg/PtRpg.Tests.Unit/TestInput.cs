﻿namespace PtRpg.Tests.Unit
{
    public class TestInput : IInput, IInputWriter
    {
        int _input;

        public int Read()
        {
            return _input;
        }

        public void Write(int c)
        {
            _input = c;
        }
    }
}
