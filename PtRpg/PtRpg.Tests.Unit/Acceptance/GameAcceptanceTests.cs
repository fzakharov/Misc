using FluentAssertions;
using Moq;
using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit.Acceptance
{
    [TestFixture]
    public class GameAcceptanceTests
    {
        public GameTestsFacade Target { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Target = new GameTestsFacade();
        }

        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'w';

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Health
                .Should().Be(Target.Settings.HealthToSet);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }


        [Test]
        public void Should_change_money_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 's';

            // When
            Target.UserPressed(input);

            // Then
            Target.Hero.Money
                .Should().Be(Target.Settings.MoneyToSet);

            Target.Hud.Hero
                .Should().Be(Target.Hero);
        }
    }
}
