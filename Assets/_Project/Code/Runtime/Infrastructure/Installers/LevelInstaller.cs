using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Attachment.Collisions;
using Runtime.Gameplay.Attachment.Provider;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Transform _spawnPoint;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<AttachableProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AttachableCollisionsRegistry>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AttachmentController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponSpawner>().AsSingle().NonLazy();
        }
    }
}