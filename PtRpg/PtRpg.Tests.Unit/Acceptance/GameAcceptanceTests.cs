using FluentAssertions;
using NUnit.Framework;
using PtRpg.Rpg;
using System;

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
                hero.Health + (int)(cond.MaxHealthIncrease * Target.Random.RealProbability);

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

            var delta = (int)(Math.Round(
                    (cond.MaxHealthMaxIncrease - cond.MaxHealthMinIncrease) * Target.Random.RealProbability));

            int expectedMaxHealth = hero.MaxHealth + cond.MaxHealthMinIncrease + delta;

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

        [Test]
        public void Should_exec_weapon_scenario_When_ProcessInput_for_weapon()
        {
            // Given
            var cond = Target.Settings.Weapon;
            var hero = Target.Hero;
            hero.Money = cond.Cost;

            var delta = (int)(Math.Round(
                    (cond.PowerMaxIncrease - cond.PowerMinIncrease) * Target.Random.RealProbability));

            int expectedPower = hero.Power + cond.PowerMinIncrease + delta;

            int expectedMoney = 0;

            char input = Target.GetInputByScenario<WeaponScenario>();

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Power
                .Should().Be(expectedPower);

            Target.Hero.Money
                .Should().Be(expectedMoney);
        }

        [Test]
        public void Should_exec_monster_scenario_When_ProcessInput_for_monster()
        {
            // Given
            var cond = Target.Settings.Monster;
            var hero = Target.Hero;
            int expectedHealth = hero.Health - cond.WinHealthLost;
            int expectedMoney = hero.Money + cond.WinMoney;
            Target.Random.RealProbability = 0.1;

            char input = Target.GetInputByScenario<MonsterScenario>();

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Health.Should().Be(expectedHealth);
            Target.Hero.Money.Should().Be(expectedMoney);
        }
    }
}
