using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

        [Test]
        public void Should_throw_When_GetByInput_for_unregistred_key()
        {
            // Given
            char unregistredKey = 'a';
            // When
            var action = Target.Invoking(t => t.GetByInput(unregistredKey));

            // Then
            action.Should().Throw<KeyNotFoundException>();
        }
    }
}