﻿using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;
using System;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class MoneyScenarioTestsBase<TScenario, TCond> : AutoMockerTestsBase<TScenario>
        where TScenario : MoneyScenarioBase<TCond> where TCond : MoneyConditions
    {
        protected HeroState _hero;
        protected TCond _cond;

        protected const int InitMoney = 3;
        protected const int InitHealth = 100;
        protected const int InitMaxHealth = 110;
        protected const int InitPower = 1;
        protected const int InitItems = 1;
        protected const double Probability = 0.5;

        [SetUp]
        public void MstSetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                Health = InitHealth,
                MaxHealth = InitMaxHealth,
                Power = InitPower,
                Items = InitItems
            };

            _cond = Get<TCond>();
        }

        protected int CalcDeltaWithProbability(int minIncrease, int maxIncrease)
        {
            return (int)(Math.Round((maxIncrease - minIncrease) * Probability));
        }

        protected void TestCase_Should_throw_GameEx_When_Execute_with_not_enough_money()
        {
            // Given
            _cond.Cost = InitMoney + 1;

            // When
            var action = Target.Invoking(t => t.Execute(_hero));

            // Then
            action.Should().Throw<GameException>();

            _hero.Money.Should().Be(InitMoney);
            _hero.Health.Should().Be(InitHealth);
            _hero.MaxHealth.Should().Be(InitMaxHealth);
            _hero.Power.Should().Be(InitPower);
            _hero.Items.Should().Be(InitItems);
        }
    }
}