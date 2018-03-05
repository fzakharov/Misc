using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class DealerScenarioTests : MoneyScenarioTestsBase<DealerScenario, DealerConditions>
    {
        [Test]
        public void Should_calculate_max_health_When_Execute()
        {
            // Given
            _cond.Cost = InitMoney;
            _cond.MaxHealthMaxIncrease = 100;
            _cond.MaxHealthMinIncrease = 0;
            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(Probability);

            var delta = CalcDeltaWithProbability(_cond.MaxHealthMinIncrease, _cond.MaxHealthMaxIncrease);

            int expectedMaxHealth = InitMaxHealth + _cond.MaxHealthMinIncrease + delta;

            int expectedMoney = 0;

            // When
            Target.Execute(_hero);

            // Then
            _hero.MaxHealth.Should().Be(expectedMaxHealth);
            _hero.Money.Should().Be(expectedMoney);
            _hero.Health.Should().Be(InitHealth);
        }

        [Test]
        public void Should_throw_GameEx_When_Execute_with_not_enough_money()
        {
            // Given // When // Then
            TestCase_Should_throw_GameEx_When_Execute_with_not_enough_money();
        }
    }
}