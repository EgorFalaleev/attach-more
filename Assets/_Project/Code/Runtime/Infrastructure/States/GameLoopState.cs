using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Attachment.Provider;
using Runtime.Gameplay.Enemies;
using Runtime.Gameplay.Enemies.Spawner;
using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Weapons.Spawner;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.States
{
    public class GameLoopState : IState, ITickable
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWeaponSpawner _weaponSpawner;
        private readonly IAttachableProvider _attachableProvider;
        private readonly IAttachmentController _attachmentController;
        private readonly IEnemySpawner _enemySpawner;
        private readonly EnemyMovementSystem _enemyMovementSystem;

        public GameLoopState(
            IPlayerFactory playerFactory, 
            IWeaponSpawner weaponSpawner, 
            IAttachableProvider attachableProvider, 
            IAttachmentController attachmentController,
            IEnemySpawner enemySpawner,
            EnemyMovementSystem enemyMovementSystem)
        {
            _playerFactory = playerFactory;
            _weaponSpawner = weaponSpawner;
            _attachableProvider = attachableProvider;
            _attachmentController = attachmentController;
            _enemySpawner = enemySpawner;
            _enemyMovementSystem = enemyMovementSystem;
        }
        
        public void Enter()
        {
            var playerView = _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
            _attachableProvider.AddAttachable(playerView);
            _attachmentController.CreateTree(playerView);
            
            _weaponSpawner.StartSpawning(playerView.Transform);
            _enemySpawner.StartSpawning(playerView.Transform);
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            _enemyMovementSystem.Tick();
        }
    }
}