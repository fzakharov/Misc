using FluentAssertions;
using Moq;
using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit.Acceptance
{
    [TestFixture]
    public class GameAcceptanceTests
    {
        public GameTestsFacade Target { get; private set; }
        Mock<IBindings> _bindings = new Mock<IBindings>();
        GameConfiguration _config = new GameConfiguration();

        [SetUp]
        public void SetUp()
        {
            Target = new GameTestsFacade(
                _bindings.Object,
                _config);
        }

        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'w';

            SetupBindings<HealthScenario>(input);

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Health
                .Should().Be(_config.HealthToSet);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }


        [Test]
        public void Should_change_money_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'a';

            SetupBindings<MoneyScenario>(input);

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Money
                .Should().Be(_config.MoneyToSet);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }

        void SetupBindings<T>(char input)
        {
            _bindings.Setup(b => b.Contains(input))
                .Returns(true);
            _bindings.Setup(b => b.GetName(input))
                .Returns(typeof(T).Name);
        }
    }
}
