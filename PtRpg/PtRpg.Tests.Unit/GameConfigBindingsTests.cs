using FluentAssertions;
using NUnit.Framework;
using PtRpg.Engine;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameConfigBindingsTests : AutoMockerTestsBase<GameConfigBindings>
    {
        [Test]
        public void Should_throw_GameException_When_GetName_for_unbinded_scenario()
        {
            // Given
            char key = 'w';

            // When 
            var action = Target.Invoking(t => t.GetName(key));

            // Then
            action.Should()
                .Throw<GameException>()
                .And
                .Message.Should().Contain($"'{key}'");
        }

        [Test]
        public void Should_return_expected_When_GetName_for_binded_scenario()
        {
            // Given
            char key = 'w';
            string expected = "SomeScenarioTypeName";

            SetConfigBinding(key, expected);

            // When // Then
            Target.GetName(key)
                .Should().Be(expected);
        }

        [Test]
        public void Should_false_When_not_Contains()
        {
            // Given
            char unbindedKey = 'w';

            // When // Then
            Target.Contains(unbindedKey)
                .Should().BeFalse();
        }

        [Test]
        public void Should_true_When_Contains()
        {
            // Given
            char key = 'w';
            SetConfigBinding(key, "SomeScenarioTypeName");

            // When // Then
            Target.Contains(key)
                .Should().BeTrue();
        }

        private void SetConfigBinding(char key, string scenarioTypeName)
        {
            Get<GameConfiguration>()
                .Bindings = new[] { new KeyBinding { Key = key, ScenarioTypeName = scenarioTypeName } };
        }
    }
}