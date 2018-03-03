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
            _tw.WriteLine("Health: {0}\nMoney: {1}", hero.Health, hero.Money);
        }

        public void Update(GameException ex)
        {
            _tw.WriteLine(ex.Message);
        }
    }
}