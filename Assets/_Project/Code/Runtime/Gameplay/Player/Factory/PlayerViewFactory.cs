using System;
using Runtime.Constants;
using Runtime.Infrastructure.Assets;
using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;

namespace Runtime.Gameplay.Player.Factory
{
    public class PlayerViewFactory : IPlayerViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public event Action<PlayerView> OnPlayerViewCreated; 
        
        public PlayerViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public PlayerView CreatePlayerView(Player player, Vector3 spawnPosition)
        {
            var prefab = _assetProvider.Load<PlayerView>(Paths.Player);
            
            var playerView = _instantiator.InstantiatePrefabForComponent<PlayerView>(prefab, spawnPosition, Quaternion.identity,
                null);
            playerView.Initialize(player);

            OnPlayerViewCreated?.Invoke(playerView);
            return playerView;
        }
    }
}