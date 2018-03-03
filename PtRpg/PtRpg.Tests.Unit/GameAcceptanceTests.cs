using FluentAssertions;
using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameAcceptanceTests
    {
        private KeyScenarioSelector _scenarioSelector;

        public GameTestsFacade Target { get; private set; }
        

        [SetUp]
        public void SetUp()
        {
            _scenarioSelector = new KeyScenarioSelector();
            Target = new GameTestsFacade(_scenarioSelector);
        }

        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'w';
            int expectedHealth = 42;

            var scenario = new HealthScenario();
            scenario.HealthToSet = expectedHealth;
            _scenarioSelector.BindScenario(input, scenario);

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

            var scenario = new MoneyScenario();
            scenario.MoneyToSet = expectedMoney;
            _scenarioSelector.BindScenario(input, scenario);

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
