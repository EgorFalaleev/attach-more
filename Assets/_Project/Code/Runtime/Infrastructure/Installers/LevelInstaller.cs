using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Attachment.Collisions;
using Runtime.Gameplay.Attachment.Provider;
using Runtime.Gameplay.Enemies;
using Runtime.Gameplay.Enemies.Factory;
using Runtime.Gameplay.Enemies.Spawner;
using Runtime.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private EnemyView _enemyView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<AttachableProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AttachableCollisionsRegistry>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AttachmentController>().AsSingle().NonLazy();
            
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().NonLazy();
            Container.Bind<IEnemyViewFactory>().To<EnemyViewFactory>().AsSingle().WithArguments(_enemyView).NonLazy();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }
    }
}