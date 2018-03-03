using Moq;
using NUnit.Framework;
using PtRpg.Engine;
using System.Collections.Generic;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameLoopTests : AutoMockerTestsBase<GameLoop>
    {
        private int _key;
        private Mock<IInput> _input;
        private Mock<IScenario> _scenario;
        private Mock<IHud> _hud;
        private Mock<IScenarioSelector> _selector;
        private HeroState _hero;

        [SetUp]
        public void SetUp()
        {
            _key = 42;
            _input = GetMock<IInput>();
            _scenario = GetMock<IScenario>();
            _hud = GetMock<IHud>();
            _selector = GetMock<IScenarioSelector>();

            _hero = new HeroState();
            Use(_hero);

            _input.Setup(i => i.Read())
                .Returns(_key);
        }

        [Test]
        public void Should_Update_Hud_When_in_NextStep_throws_GameException()
        {
            // Given
            var ex = new GameException("expected message");

            _selector
                .Setup(s => s.GetByInput(_key))
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
            _selector
                .Setup(s => s.GetByInput(_key))
                .Returns(_scenario.Object);

            // When
            Target.NextStep();

            // Then
            _scenario.Verify(s => s.Execute(_hero));
            _hud.Verify(h => h.Update(_hero));
        }
    }
}