using FluentAssertions;
using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class GameAcceptanceTests
    {
        public GameAcceptaceTestsFacade Target { get; private set; }

        [SetUp]
        public void SetUp() {
            Target = new GameAcceptaceTestsFacade();
        }

        [Test]
        public void Should_change_health_to_expeted_When_ProcessInput()
        {
            // Given
            const char input = 'w';
            int expected = 42;

            // When
            Target.ProcessInput(input);

            // Then
            Target.Hero.Health.Should().Be(expected);
        }
    }
}
