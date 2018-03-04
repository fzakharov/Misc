using PtRpg.Engine;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class StubRandom : IRandom
    {
        public double RandomValue { get; set; } = 0.5;

        public double GenerateRealProbability()
        {
            return RandomValue;
        }
    }
}