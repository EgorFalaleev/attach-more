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

        public event Action<Player> OnPlayerViewCreated; 
        
        public PlayerFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public Player CreatePlayer(Vector3 spawnPosition)
        {
            var prefab = _assetProvider.Load<Player>(Paths.Player);
            
            var player = _instantiator.InstantiatePrefabForComponent<Player>(prefab, spawnPosition, Quaternion.identity,
                null);

            OnPlayerViewCreated?.Invoke(player);
            return player;
        }
    }
}