using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

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
        protected const int InitMaxHealth = 100;
        protected const double Probability = 0.5;

        [SetUp]
        public void MstSetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                Health = InitHealth,
                MaxHealth = InitMaxHealth,
            };

            _cond = Get<TCond>();
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
        }
    }
}