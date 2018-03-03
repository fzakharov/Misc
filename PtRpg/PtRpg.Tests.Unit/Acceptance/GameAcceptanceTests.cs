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
        private HealthScenario _healthScenario;
        private MoneyScenario _moneyScenario;

        [SetUp]
        public void SetUp()
        {
            _healthScenario = new HealthScenario();
            _moneyScenario = new MoneyScenario();
            var input = new TestInput();
            Target = new GameTestsFacade(
                input,
                input,
                _bindings.Object,
                new IScenario[] { _healthScenario, _moneyScenario });
        }

        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'w';
            int expectedHealth = 42;

            _healthScenario.HealthToSet = expectedHealth;

            _bindings.Setup(b => b.Contains(input))
                .Returns(true);
            _bindings.Setup(b => b.GetName(input))
                .Returns(_healthScenario.GetType().Name);

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Health
                .Should().Be(expectedHealth);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }

        [Test]
        public void Should_change_money_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'a';
            int expectedMoney = 24;

            _bindings.Setup(b => b.Contains(input))
                .Returns(true);
            _bindings.Setup(b => b.GetName(input))
                .Returns(_moneyScenario.GetType().Name);

            _moneyScenario.MoneyToSet = expectedMoney;

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Money
                .Should().Be(expectedMoney);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }
    }
}
