using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using System.Collections.Generic;
using System.Linq;

namespace PtRpg.Tests.Unit
{
    public class ClientClass
    {
        public ClientClass(IEnumerable<IScenario> scenarios)
        {
            Scenarios = scenarios.ToArray();
        }

        public IScenario[] Scenarios { get; }
    }

    [TestFixture]
    public class KeyScenarioSelectorTests : AutoMockerTestsBase<KeyScenarioSelector>
    {


        //[Test]
        //public void Should__When_()
        //{
        //    var serviceCollection = new ServiceCollection();
        //    serviceCollection.AddSingleton<IScenario, HealthScenario>();
        //    serviceCollection.AddSingleton<IScenario, MoneyScenario>();
        //    serviceCollection.AddSingleton<ClientClass>();

        //    var prov = serviceCollection.BuildServiceProvider();

        //    var cc = prov.GetService<ClientClass>();

        //    var sc = prov.GetServices<IScenario>();

        //    cc.Scenarios.Should().HaveCount(2);

        //}



        [SetUp]
        public void SetUp()
        {

        }

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