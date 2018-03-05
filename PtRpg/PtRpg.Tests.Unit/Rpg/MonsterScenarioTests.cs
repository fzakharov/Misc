using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;
using FluentAssertions;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class MonsterScenarioTests : AutoMockerTestsBase<MonsterScenario>
    {
        const int InitMoney = 3;
        const int InitHealth = 100;
        const double Probability = 0.5;
        private HeroState _hero;
        MonsterConditions _cond;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroState
            {
                Money = InitMoney,
                Health = InitHealth
            };

            _cond = Get<MonsterConditions>();
        }

        void SetupMonsterWon(bool isMonsterWon)
        {
            GetMock<IMonster>()
                .Setup(m => m.IsWonVs(_hero, _cond))
                .Returns(isMonsterWon);
        }

        [Test]
        public void Should_win_When_Execute()
        {
            // Given
            _cond.WinMoney = 5;
            _cond.WinHealthLost = 10;
            int expectedMoney = InitMoney + _cond.WinMoney;
            int expectedHealth = InitHealth - _cond.WinHealthLost;

            SetupMonsterWon(false);

            // When
            Target.Execute(_hero);

            // Then
            _hero.Health.Should().Be(expectedHealth);
            _hero.Money.Should().Be(expectedMoney);
        }

        [Test]
        public void Should_loss_When_Execute()
        {
            // Given
            _cond.LossHealthLost = 40;
            int expectedHealth = InitHealth - _cond.LossHealthLost;

            SetupMonsterWon(true);

            // When
            Target.Execute(_hero);

            // Then
            _hero.Health.Should().Be(expectedHealth);
            _hero.Money.Should().Be(InitMoney);
        }
    }
}