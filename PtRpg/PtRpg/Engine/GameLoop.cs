namespace PtRpg.Engine
{
    public class GameLoop
    {
        private readonly IHud _hud;
        private readonly HeroState _hero;
        private readonly IScenarioSelector _selector;
        private IInput _input;
        private GameConfiguration _config;
        
        public GameLoop(IHud hud, HeroState hero, IScenarioSelector selector, IInput input, GameConfiguration config)
        {
            _hud = hud;
            _hero = hero;
            _selector = selector;
            _input = input;
            _config = config;
        }

        public bool NextStep()
        {
            try
            {
                _hud.Update(_hero);
                _hud.ShowScenarios(_config);

                var input = _input.Read();
                var scenario = _selector.GetByInput(input);
                _hud.Show(scenario);

                scenario.Execute(_hero);
            }
            catch (GameException ex)
            {
                _hud.Update(ex);
            }

            if (_hero.Health <= 0)
            {
                _hud.Update(_hero);
                return false;
            }

            return true;
        }
    }
}