using FluentAssertions;
using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class DefaultMonsterTests : AutoMockerTestsBase<DefaultMonster>
    {
        HeroState _hero;
        MonsterConditions _cond;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroState
            {
            };

            _cond = new MonsterConditions();
        }


        [TestCase(0.44, false)]
        [TestCase(0.45, false)]
        [TestCase(0.46, true)]
        public void Should_use_hero_lucky_When_it_less_then_MaxProbability(double monsterProbability, bool isMonsterWon)
        {
            // Given
            _hero.Power = 1;
            _cond.MaxProbability = 0.7;
            _cond.MinProbability = 0.4;
            _cond.PowerFactor = 0.05;

            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(monsterProbability);


            // When // Then
            Target.IsWonVs(_hero, _cond).Should().Be(isMonsterWon);

        }

        [TestCase(0.69, false)]
        [TestCase(0.70, true)]
        [TestCase(0.71, true)]
        public void Should_use_MaxProbability_When_it_less_then_hero_lucky(double monsterProbability, bool isMonsterWon)
        {
            // Given
            _hero.Power = 1;
            _cond.MaxProbability = 0.7;
            _cond.MinProbability = 0.7;
            _cond.PowerFactor = 0.05;

            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(monsterProbability);


            // When // Then
            Target.IsWonVs(_hero, _cond).Should().Be(isMonsterWon);

        }
    }
}