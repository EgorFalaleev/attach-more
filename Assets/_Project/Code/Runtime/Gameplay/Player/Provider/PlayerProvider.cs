using Runtime.Gameplay.Player.Factory;

namespace Runtime.Gameplay.Player.Provider
{
    public class PlayerProvider : IPlayerProvider
    {
        private Player _player;

        public Player Player => _player;

        public PlayerProvider(IPlayerFactory playerFactory)
        {
            playerFactory.OnPlayerViewCreated += player => { _player = player; };
        }        
    }
}