using Runtime.Gameplay.Player.Factory;

namespace Runtime.Gameplay.Player.Provider
{
    public class PlayerViewProvider : IPlayerViewProvider
    {
        private PlayerView _playerView;

        public PlayerView PlayerView => _playerView;

        public PlayerViewProvider(IPlayerFactory playerFactory)
        {
            playerFactory.OnPlayerCreated += playerView => { _playerView = playerView; };
        }        
    }
}