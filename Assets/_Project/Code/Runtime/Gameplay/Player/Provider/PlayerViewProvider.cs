namespace Runtime.Gameplay.Player.Provider
{
    public class PlayerViewProvider : IPlayerViewProvider
    {
        private readonly PlayerView _playerView;

        public PlayerView PlayerView => _playerView;

        public PlayerViewProvider(PlayerView playerView)
        {
            _playerView = playerView;
        }        
    }
}