using Runtime.Gameplay.Enemies.Provider;
using Runtime.Gameplay.Player.Provider;
using UnityEngine;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IPlayerViewProvider _playerViewProvider;
        private readonly IEnemiesProvider _enemiesProvider;

        public EnemyFactory(IPlayerViewProvider playerViewProvider, IEnemiesProvider enemiesProvider)
        {
            _playerViewProvider = playerViewProvider;
            _enemiesProvider = enemiesProvider;
        }

        public Enemy CreateEnemy(Vector3 position)
        {
            var enemy = new Enemy()
                { Position = position, TargetPosition = _playerViewProvider.PlayerView.transform.position };

            _enemiesProvider.AddEnemy(enemy);
            
            return enemy;
        }
    }
}