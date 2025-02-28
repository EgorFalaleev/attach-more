using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Player.Provider;
using Runtime.Gameplay.Weapon.Factory;
using Runtime.Gameplay.Weapon.Spawner;
using Runtime.Infrastructure.Assets;
using Runtime.Infrastructure.Loading;
using Runtime.Infrastructure.States;
using Runtime.Infrastructure.States.StateMachine;
using Runtime.Services.Input;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindSelf();
            BindStates();
            BindStateMachine();
            BindServices();
            BindFactories();
            BindPlayerViewProvider();
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
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
        }

        private void BindPlayerViewProvider() =>
            Container.Bind<IPlayerViewProvider>().To<PlayerViewProvider>().AsSingle();

        private void BindSpawners()
        {
            Container.BindInterfacesAndSelfTo<WeaponSpawner>().AsSingle();
        }
    }
}