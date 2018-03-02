using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class KeyScenarioSelectorTests
    {
        public KeyScenarioSelector Target { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Target = new KeyScenarioSelector();
        }

        [Test]
        public void Should_return_expected_scenario_When_GetByInput_for_registred_key()
        {
            // Given
            const char input = 'w';
            var expected = Mock.Of<IScenario>();
            Target.BindScenario(input, expected);
            Target.BindScenario('q', Mock.Of<IScenario>());

            // When
            var actual = Target.GetByInput(input);

            // Then
            actual.Should().Be(expected);
        }
    }
}