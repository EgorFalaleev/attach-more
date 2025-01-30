using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AttachmentController>().AsSingle().NonLazy();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponSpawner>().AsSingle().NonLazy();
        }
    }
}