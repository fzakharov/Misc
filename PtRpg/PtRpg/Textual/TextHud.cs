using PtRpg.Engine;
using System.IO;

namespace PtRpg.Textual
{
    public class TextHud : IHud
    {
        TextWriter _tw;

        public TextHud(TextWriter tw)
        {
            _tw = tw;
        }

        public void Update(HeroState hero)
        {
            _tw.WriteLine();
            _tw.WriteLine($"MaxHealth: {hero.MaxHealth}");
            _tw.WriteLine($"Health: {hero.Health}");
            _tw.WriteLine($"Power: {hero.Power}");
            _tw.WriteLine($"Money: {hero.Money}");
            _tw.WriteLine($"Items: {hero.Items}");
        }

        public void Update(GameException ex)
        {
            _tw.WriteLine();
            _tw.WriteLine(ex.Message);
        }
    }
}