using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg.Tests.Unit.Acceptance
{
    public class GameTestsFacade
    {
        private TestInput _input;
        private GameLoop _game;

        public GameTestsFacade(GameConfiguration configuration)
        {
            Hero = new HeroState();
            Hud = new MockHud();
            _input = new TestInput();

            var sp = CreateServiceProvider(Hero, Hud, _input, configuration);

            _game = sp.GetService<GameLoop>();
        }

        public HeroState Hero { get; internal set; }
        public MockHud Hud { get; internal set; }

        public void UserPressed(int c)
        {
            _input.Write(c);
            _game.NextStep();
        }

        private ServiceProvider CreateServiceProvider(
            HeroState hero, 
            IHud hud, 
            IInput input, 
            GameConfiguration conig)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<GameLoop>()
                .AddSingleton<IBindings, GameConfigBindings>()
                .AddSingleton<IScenarioSelector, TypeNameScenarioSelector>()
                .AddSingleton<IScenario, HealthScenario>()
                .AddSingleton<IScenario, MoneyScenario>()
                .AddSingleton(hero)
                .AddSingleton(hud)
                .AddSingleton(input)
                .AddSingleton(conig);

            return serviceCollection.BuildServiceProvider();
        }
    }
}