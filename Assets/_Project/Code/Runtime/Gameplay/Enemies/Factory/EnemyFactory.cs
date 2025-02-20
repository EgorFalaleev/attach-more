using Runtime.Gameplay.Player.Provider;
using UnityEngine;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IPlayerViewProvider _playerViewProvider;

        public EnemyFactory(IPlayerViewProvider playerViewProvider)
        {
            _playerViewProvider = playerViewProvider;
        }

        public Enemy CreateEnemy(Vector3 position)
        {
            return new Enemy
            {
                Position = position,
                TargetPosition = _playerViewProvider.PlayerView.transform.position
            };
        }
    }
}