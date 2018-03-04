using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class WeaponScenarioTests : AutoMockerTestsBase<WeaponScenario>
    {
        const int InitMoney = 3;
        const int InitPower = 1;
        const double Probability = 0.5;
        private HeroState _hero;
        WeaponConditions _cond;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                Power = InitPower,
            };

            _cond = Get<WeaponConditions>();
        }

        [Test]
        public void Should_calculate_power_When_Execute()
        {
            // Given
            _cond.Cost = InitMoney;
            _cond.PowerMaxIncrease = 100;
            _cond.PowerMinIncrease = 0;
            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(Probability);

            int expectedPower = InitPower + _cond.PowerMinIncrease +
                (int)((_cond.PowerMaxIncrease - _cond.PowerMinIncrease) * Probability);

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
            // Given
            _cond.Cost = InitMoney + 1;

            // When
            var action = Target.Invoking(t => t.Execute(_hero));

            // Then
            action.Should().Throw<GameException>();
            _hero.Money.Should().Be(InitMoney);
            _hero.Power.Should().Be(InitPower);
        }
    }
}