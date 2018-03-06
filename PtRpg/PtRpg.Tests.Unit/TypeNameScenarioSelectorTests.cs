using FluentAssertions;
using Moq;
using NUnit.Framework;
using PtRpg.Engine;
using System.Collections.Generic;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class TypeNameScenarioSelectorTests : AutoMockerTestsBase<TypeNameScenarioSelector>
    {
        [Test]
        public void Should_return_expected_scenario_When_GetByInput()
        {
            // Given
            const char input = 'w';
            var expected = Mock.Of<IScenario>();
            var bindings = GetMock<IBindings>();
            bindings.Setup(b => b.Contains(input))
                .Returns(true);

            bindings.Setup(b => b.GetName(input))
                .Returns(expected.GetType().Name);

            Use<IEnumerable<IScenario>>(new[] { expected });

            // When
            var actual = Target.GetByInput(input);

            // Then
            actual.Should().Be(expected);
        }

        [Test]
        public void Should_throw_GameException_When_GetByInput_for_unregistred_key()
        {
            // Given
            char unregistredKey = 'a';
            // When
            var action = Target.Invoking(t => t.GetByInput(unregistredKey));

            // Then
            action.Should()
                .Throw<GameException>()
                .WithMessage($"Unsupported command '{unregistredKey}'");
        }
    }
}