using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;
using System;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class WeaponScenarioTests : MoneyScenarioTestsBase<WeaponScenario, WeaponConditions>
    {
        [Test]
        public void Should_calculate_power_When_Execute()
        {
            // Given
            _cond.Cost = InitMoney;
            _cond.PowerMaxIncrease = 2;
            _cond.PowerMinIncrease = 1;
            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(Probability);

            var delta = CalcDeltaWithProbability(_cond.PowerMinIncrease, _cond.PowerMaxIncrease);

            int expectedPower = InitPower + _cond.PowerMinIncrease + delta;

            int expectedMoney = 0;

            // When
            Target.Execute(_hero);

            // Then
            _hero.Power.Should().Be(expectedPower);
            _hero.Money.Should().Be(expectedMoney);
        }

        [Test]
        public void Should_throw_GameEx_When_Execute_with_not_enough_money()
        {
            TestCase_Should_throw_GameEx_When_Execute_with_not_enough_money();
        }
    }
}