using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class DealerScenarioTests : AutoMockerTestsBase<DealerScenario>
    {
        const int InitMoney = 3;
        const int InitHealth = 100;
        const int InitMaxHealth = 100;
        const double Probability = 0.5;
        private HeroState _hero;
        DealerConditions _cond;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                Health = InitHealth,
                MaxHealth = InitMaxHealth,
            };

            _cond = Get<DealerConditions>();
        }

        [Test]
        public void Should_calculate_max_health_When_Execute()
        {
            // Given
            _cond.Cost = InitMoney;
            _cond.MaxHealthMaxIncrease = 100;
            _cond.MaxHealthMinIncrease = 0;
            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(Probability);

            int expectedMoney = 0;
            int expectedMaxHealth =
                InitMaxHealth +
                (int)((_cond.MaxHealthMaxIncrease - _cond.MaxHealthMinIncrease) * Probability);

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
            // Given
            _cond.Cost = InitMoney + 1;

            // When
            var action = Target.Invoking(t => t.Execute(_hero));

            // Then
            action.Should().Throw<GameException>();
            _hero.Money.Should().Be(InitMoney);
            _hero.Health.Should().Be(InitHealth);
            _hero.MaxHealth.Should().Be(InitMaxHealth);
        }
    }
}