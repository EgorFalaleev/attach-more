using Runtime.Gameplay.Enemies.Spawner;
using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;

namespace Runtime.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly WeaponSpawner _weaponSpawner;
        private readonly EnemySpawner _enemySpawner;

        public BootstrapState(IPlayerFactory playerFactory, WeaponSpawner weaponSpawner, EnemySpawner enemySpawner)
        {
            _playerFactory = playerFactory;
            _weaponSpawner = weaponSpawner;
            _enemySpawner = enemySpawner;
        }
        
        public void Enter()
        {
            var playerView = _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
            _weaponSpawner._spawnCenter = playerView.Transform;
        }

        public void Exit()
        {
        }
    }
}