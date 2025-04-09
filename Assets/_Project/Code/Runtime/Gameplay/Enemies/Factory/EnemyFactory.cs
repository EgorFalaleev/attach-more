using Runtime.Constants;
using Runtime.Gameplay.Player.Provider;
using Runtime.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly IInstantiator _instantiator;

        public EnemyFactory(IAssetProvider assetProvider, IPlayerProvider playerProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _playerProvider = playerProvider;
            _instantiator = instantiator;
        }

        public EnemyView CreateEnemy(Vector3 spawnPoint)
        {
            var prefab = _assetProvider.Load<EnemyView>(Paths.Enemy);
            
            var view = _instantiator.InstantiatePrefabForComponent<EnemyView>(prefab, spawnPoint, Quaternion.identity, null);
            view.Initialize(_playerProvider.Player.transform);
            return view;
        }
    }
}