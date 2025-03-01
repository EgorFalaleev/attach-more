using Runtime.Gameplay.Attachment;
using Runtime.Gameplay.Attachment.Collisions;
using Runtime.Gameplay.Attachment.Provider;
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
            BindServices();
            BindFactories();
            BindSpawners();
            BindStates();
            BindStateMachine();
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
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IPlayerViewProvider>().To<PlayerViewProvider>().AsSingle();
            Container.Bind<IAttachableProvider>().To<AttachableProvider>().AsSingle();
            Container.Bind<IAttachableCollisionsRegistry>().To<AttachableCollisionsRegistry>().AsSingle();
            Container.Bind<IAttachmentController>().To<AttachmentController>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle();
        }

        private void BindSpawners()
        {
            Container.BindInterfacesAndSelfTo<WeaponSpawner>().AsSingle();
        }
    }
}