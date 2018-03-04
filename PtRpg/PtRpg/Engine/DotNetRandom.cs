using System;

namespace PtRpg.Engine
{
    public class DotNetRandom : IRandom
    {
        private Random _random;

        public DotNetRandom()
        {
            _random = new Random();
        }

        public double GenerateRealProbability()
        {
            return _random.NextDouble();
        }
    }
}