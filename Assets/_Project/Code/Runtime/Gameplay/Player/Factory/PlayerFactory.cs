using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;

namespace Runtime.Gameplay.Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerView _playerView;
        private readonly IInstantiator _instantiator;

        public PlayerFactory(PlayerView playerView, IInstantiator instantiator)
        {
            _playerView = playerView;
            _instantiator = instantiator;
        }

        public void CreatePlayer(Vector3 position)
        {
            _instantiator.InstantiatePrefabForComponent<PlayerView>(_playerView, position, Quaternion.identity, null);
        }
    }
}