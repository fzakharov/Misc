using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameLoopTests : AutoMockerTestsBase<GameLoop>
    {

        [Test]
        public void Should_execute_scenario_and_updates_hud_When_NextStep()
        {
            // Given
            var key = 42;
            var hero = new HeroState();
            Use(hero);

            var scenario = GetMock<IScenario>();

            GetMock<IInput>().Setup(i => i.Read())
                .Returns(key);

            GetMock<IScenarioSelector<int>>()
                .Setup(s => s.GetByInput(key))
                .Returns(scenario.Object);

            // When
            Target.NextStep();

            // Then
            scenario.Verify(s => s.Execute(hero));
            GetMock<IHud>().Verify(h => h.Update(hero));
        }
    }
}