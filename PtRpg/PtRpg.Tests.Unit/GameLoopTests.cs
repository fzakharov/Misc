using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameLoopTests : AutoMockerTestsBase<GameLoop>
    {
        private Mock<IInput> _input;
        private Mock<IScenario> _scenario;
        private Mock<IHud> _hud;
        private HeroState _hero;

        [SetUp]
        public void SetUp()
        {
            _input = GetMock<IInput>();
            _scenario = GetMock<IScenario>();
            _hud = GetMock<IHud>();

            _hero = new HeroState();
            Use(_hero);
        }

        [Test]
        public void Should_Update_Hud_When_in_NextStep_throws_GameException()
        {
            // Given
            var key = 42;
            var ex = new GameException("expected message");

            GetMock<IInput>().Setup(i => i.Read())
                .Returns(key);

            GetMock<IScenarioSelector<int>>()
                .Setup(s => s.GetByInput(key))
                .Throws(ex);

            // When
            Target.NextStep();

            // Then
            _hud.Verify(h => h.Update(It.Is<GameException>(e => e.Message == ex.Message)));
        }


        [Test]
        public void Should_execute_scenario_and_updates_hud_When_NextStep()
        {
            // Given
            var key = 42;

            _input.Setup(i => i.Read())
                .Returns(key);

            GetMock<IScenarioSelector<int>>()
                .Setup(s => s.GetByInput(key))
                .Returns(_scenario.Object);

            // When
            Target.NextStep();

            // Then
            _scenario.Verify(s => s.Execute(_hero));
            _hud.Verify(h => h.Update(_hero));
        }
    }
}