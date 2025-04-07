using Runtime.Gameplay.Enemies.Provider;
using Runtime.Gameplay.Player.Provider;
using UnityEngine;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemiesProvider _enemiesProvider;

        public EnemyFactory(IPlayerProvider playerProvider, IEnemiesProvider enemiesProvider)
        {
            _playerProvider = playerProvider;
            _enemiesProvider = enemiesProvider;
        }

        public Enemy CreateEnemy(Vector3 position)
        {
            var enemy = new Enemy()
                { Position = position, Target = _playerProvider.Player.transform };

            _enemiesProvider.AddEnemy(enemy);
            
            return enemy;
        }
    }
}