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


        [TestCase(0.44d, 0.4d, false)]
        [TestCase(0.45d, 0.4d, false)]
        [TestCase(0.46d, 0.4d, true)]

        [TestCase(0.69d, 0.7d, false)]
        [TestCase(0.70d, 0.7d, false)]
        [TestCase(0.71d, 0.7d, true)]
        public void Should_use_hero_lucky_When_it_less_then_MaxProbability(
            double monsterProbability,
            double minProbability,
            bool isMonsterWon)
        {
            // Given
            _hero.Power = 1;
            _cond.MaxProbability = 0.7;
            _cond.MinProbability = minProbability;
            _cond.PowerFactor = 0.05;

            GetMock<IRandom>().Setup(r => r.GenerateRealProbability())
                .Returns(monsterProbability);


            // When // Then
            Target.IsWonVs(_hero, _cond).Should().Be(isMonsterWon);

        }
    }
}