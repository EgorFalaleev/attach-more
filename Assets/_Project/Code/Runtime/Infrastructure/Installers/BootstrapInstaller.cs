using Runtime.Gameplay.Player;
using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Weapon;
using Runtime.Gameplay.Weapon.Factory;
using Runtime.Gameplay.Weapon.Spawner;
using Runtime.Infrastructure.Assets;
using Runtime.Infrastructure.Loading;
using Runtime.Infrastructure.States;
using Runtime.Infrastructure.States.StateMachine;
using Runtime.Services.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private WeaponView _weaponPrefab;
        [SerializeField] private PlayerView _playerView;
        
        public override void InstallBindings()
        {
            BindSelf();
            BindStates();
            BindStateMachine();
            BindServices();
            BindFactories();
            BindSpawners();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle().WithArguments(_weaponPrefab).NonLazy();
        }

        private void BindSpawners()
        {
            Container.BindInterfacesAndSelfTo<WeaponSpawner>().AsSingle();
        }
    }
}