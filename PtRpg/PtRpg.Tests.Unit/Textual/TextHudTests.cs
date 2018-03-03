using FluentAssertions;
using NUnit.Framework;
using PtRpg.Engine;
using PtRpg.Textual;
using System.IO;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class TextHudTests
    {
        private StringWriter _tw;

        public TextHud Target { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _tw = new StringWriter();
            Target = new TextHud(_tw);
        }

        [Test]
        public void Should_write_hero_state_When_Update()
        {
            // Given
            var hero = new HeroState { Health = 42, Money = 500 };

            // When
            Target.Update(hero);

            // Then
            var s = _tw.GetStringBuilder().ToString()
                .Should().ContainAll(new[] {
                    "Health",
                    hero.Money.ToString(),
                    "Money",
                    hero.Health.ToString() });
        }

        [Test]
        public void Should_write_GameException_message_When_Update()
        {
            // Given
            var expected = "expected error message";

            // When
            Target.Update(new GameException(expected));

            // Then
            var s = _tw.GetStringBuilder().ToString()
                .Should().Contain(expected);
        }
    }
}