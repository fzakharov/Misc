using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class HealerScenarioTests : MoneyScenarioTestsBase<HealerScenario, HealerConditions>
    {
        [TestCase(3, 10, 105, 0)]
        [TestCase(3, 50, InitMaxHealth, 0)]
        public void Should_calculate_health_When_Execute(int cost, int increase, int expectedHealth, int expectedMoney)
        {
            // Given
            _cond.Cost = cost;
            _cond.MaxHealthIncrease = increase;
            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(Probability);

            // When
            Target.Execute(_hero);

            // Then
            _hero.Health.Should().Be(expectedHealth);
            _hero.Money.Should().Be(expectedMoney);
        }

        [Test]
        public void Should_throw_GameEx_When_Execute_with_not_enough_money()
        {
            // Given // When // Then
            TestCase_Should_throw_GameEx_When_Execute_with_not_enough_money();
        }
    }
}