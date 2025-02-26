using Runtime.Constants;
using Runtime.Infrastructure.Assets;
using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;

namespace Runtime.Gameplay.Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public PlayerFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public PlayerView CreatePlayer(Vector3 position)
        {
            var playerView = _assetProvider.Load<PlayerView>(Paths.Player);
            return _instantiator.InstantiatePrefabForComponent<PlayerView>(playerView, position, Quaternion.identity,
                null);
        }
    }
}