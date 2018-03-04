using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg
{
    public class GameConfiguration
    {
        public HeroState Hero { get; set; }

        public HealerConditions Healer { get; set; }
        public DealerConditions Dealer { get; set; }

        public KeyBinding[] Bindings { get; set; }
    }
}