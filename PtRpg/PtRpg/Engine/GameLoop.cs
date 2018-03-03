namespace PtRpg.Engine
{
    public class GameLoop
    {
        private readonly IHud _hud;
        private readonly HeroState _hero;
        private readonly IScenarioSelector _selector;
        private IInput _input;

        public GameLoop(IHud hud, HeroState hero, IScenarioSelector selector, IInput input)
        {
            _hud = hud;
            _hero = hero;
            _selector = selector;
            _input = input;
        }

        public void NextStep()
        {
            try
            {
                var input = _input.Read();
                var scenario = _selector.GetByInput(input);
                scenario.Execute(_hero);
                _hud.Update(_hero);
            }
            catch(GameException ex)
            {
                _hud.Update(ex);
            }
        }
    }
}