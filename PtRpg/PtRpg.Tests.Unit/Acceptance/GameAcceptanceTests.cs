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
        public void Should_exec_healer_scenario_When_ProcessInput_for_healer()
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
        public void Should_exec_dealer_scenario_When_ProcessInput_for_dealer()
        {
            // Given
            var cond = Target.Settings.Dealer;
            var hero = Target.Hero;
            hero.Money = cond.Cost;

            int expectedMaxHealth =
                hero.MaxHealth
                + (int)((cond.MaxHealthMaxIncrease - cond.MaxHealthMinIncrease)
                * Target.Random.RandomValue);

            int expectedMoney = 0;

            char input = Target.GetInputByScenario<DealerScenario>();

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.MaxHealth
                .Should().Be(expectedMaxHealth);

            Target.Hero.Money
                .Should().Be(expectedMoney);
        }
    }
}
