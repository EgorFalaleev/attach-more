using Runtime.Gameplay.Enemies;
using Runtime.Gameplay.Enemies.Factory;
using Runtime.Gameplay.Enemies.Spawner;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyView;
        
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().NonLazy();
            Container.Bind<IEnemyViewFactory>().To<EnemyViewFactory>().AsSingle().WithArguments(_enemyView).NonLazy();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }
    }
}