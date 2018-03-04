using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class HealerScenarioTests : AutoMockerTestsBase<HealerScenario>
    {
        const int InitMoney = 3;
        const int InitHealth = 100;
        const int MaxHealth = 110;
        const double Probability = 0.5;
        private HeroState _hero;
        HealerConditions _cond;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                MaxHealth = MaxHealth,
                Health = InitHealth
            };

            _cond = Get<HealerConditions>();
        }

        [TestCase(3, 10, 105, 0)]
        [TestCase(3, 50, MaxHealth, 0)]
        public void Should__When_Execute(int cost, int increase, int expectedHealth, int expectedMoney)
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
            // Given
            _cond.Cost = InitMoney + 1;

            // When
            var action = Target.Invoking(t => t.Execute(_hero));

            // Then
            action.Should().Throw<GameException>();
            _hero.Money.Should().Be(InitMoney);
            _hero.Health.Should().Be(InitHealth);
        }
    }
}