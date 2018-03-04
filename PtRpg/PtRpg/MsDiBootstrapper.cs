using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PtRpg.Engine;
using PtRpg.Rpg;
using System.IO;

namespace PtRpg
{
    public class MsDiBootstrapper
    {
        const string AppSettingsFileName = "appsettings.json";
        const string AppSettingsSectionName = "Game";

        public GameConfiguration Settings { get; private set; }

        public GameLoop CreateGame(
            IHud hud,
            IInput input)
        {
            Settings = LoadSettingsFromAppConfig();

            var services = new ServiceCollection();
            services
                .AddSingleton<GameLoop>()
                .AddSingleton<IBindings, GameConfigBindings>()
                .AddSingleton<IScenarioSelector, TypeNameScenarioSelector>()
                .AddSingleton<IScenario, HealthScenario>()
                .AddSingleton<IScenario, MoneyScenario>()
                .AddSingleton(hud)
                .AddSingleton(input)
                .AddSingleton(Settings.Bindings)
                .AddSingleton(Settings.Hero)
                .AddSingleton(Settings);

            return services.BuildServiceProvider().GetService<GameLoop>();
        }

        private GameConfiguration LoadSettingsFromAppConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppSettingsFileName, optional: false, reloadOnChange: false);

            var configuration = builder.Build();

            var gameConf = new GameConfiguration();
            configuration.GetSection(AppSettingsSectionName).Bind(gameConf);

            return gameConf;
        }
    }
}