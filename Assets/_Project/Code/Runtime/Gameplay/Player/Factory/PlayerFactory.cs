using Runtime.Services.Input;

namespace Runtime.Gameplay.Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IInputService _inputService;

        public PlayerFactory(IInputService inputService)
        {
            _inputService = inputService;
        }

        // TODO add player config
        public Player CreatePlayer() => 
            new(_inputService, 5f);
    }
}