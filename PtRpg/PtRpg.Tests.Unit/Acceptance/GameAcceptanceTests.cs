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

        [SetUp]
        public void SetUp()
        {
            Target = new GameTestsFacade();
        }


        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput_for_healer()
        {
            // Given
            var cond = Target.Settings.Healer;
            var hero = Target.Hero;
            hero.Money = cond.Cost;
            hero.MaxHealth += cond.MaxHealthIncrease;

            int expectedHealth =
                hero.Health + (int)(cond.MaxHealthIncrease * Target.Random.RandomValue);

            int expectedMoney = 0;

            char input = Target.GetInputByScenario<HealerScenario>();

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Health
                .Should().Be(expectedHealth);

            Target.Hero.Money
                .Should().Be(expectedMoney);
        }


        [Test]
        public void Should_change_money_to_expeted_When_ProcessInput()
        {
            // Given
            char input = Target.GetInputByScenario<MoneyScenario>();

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Money
                .Should().Be(Target.Settings.MoneyToSet);
        }
    }
}
