using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;
using PtRpg.Rpg;

namespace PtRpg
{
    public class MsDiBootstrapper
    {
        public GameLoop CreateGame(
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

            return serviceCollection.BuildServiceProvider().GetService<GameLoop>();
        }
    }
}