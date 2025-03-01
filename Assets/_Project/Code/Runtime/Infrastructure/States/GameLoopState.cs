using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Attachment.Provider;
using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;

namespace Runtime.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWeaponSpawner _weaponSpawner;
        private readonly IAttachableProvider _attachableProvider;
        private readonly IAttachmentController _attachmentController;

        public GameLoopState(IPlayerFactory playerFactory, IWeaponSpawner weaponSpawner, IAttachableProvider attachableProvider, IAttachmentController attachmentController)
        {
            _playerFactory = playerFactory;
            _weaponSpawner = weaponSpawner;
            _attachableProvider = attachableProvider;
            _attachmentController = attachmentController;
        }
        
        public void Enter()
        {
            var playerView = _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
            _attachableProvider.AddAttachable(playerView);
            _attachmentController.CreateTree(playerView);
            
            _weaponSpawner.StartSpawning(playerView.Transform);
        }

        public void Exit()
        {
        }
    }
}