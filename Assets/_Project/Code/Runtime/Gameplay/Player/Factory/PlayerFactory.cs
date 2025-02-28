using System;
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

        public event Action<PlayerView> OnPlayerCreated; 
        
        public PlayerFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public PlayerView CreatePlayer(Vector3 position)
        {
            var prefab = _assetProvider.Load<PlayerView>(Paths.Player);
            
            var playerView = _instantiator.InstantiatePrefabForComponent<PlayerView>(prefab, position, Quaternion.identity,
                null);

            OnPlayerCreated?.Invoke(playerView);
            return playerView;
        }
    }
}