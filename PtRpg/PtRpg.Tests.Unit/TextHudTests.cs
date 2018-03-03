using FluentAssertions;
using NUnit.Framework;
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
    }
}