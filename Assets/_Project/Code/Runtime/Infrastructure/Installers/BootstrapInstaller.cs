using Runtime.Gameplay.Weapon;
using Runtime.Gameplay.Weapon.Factory;
using Runtime.Infrastructure.States;
using Runtime.Infrastructure.States.StateMachine;
using Runtime.Services;
using UnityEngine;
using Zenject;

namespace Runtime.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private WeaponView _weaponPrefab;
        
        public override void InstallBindings()
        {
            BindSelf();
            BindStates();
            BindStateMachine();
            BindServices();
            BindFactories();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IWeaponFactory>().To<WeaponFactory>().AsSingle().WithArguments(_weaponPrefab).NonLazy();
        }
    }
}