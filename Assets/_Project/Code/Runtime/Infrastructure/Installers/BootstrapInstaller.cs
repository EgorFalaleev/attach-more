using Runtime.Infrastructure.States;
using Runtime.Infrastructure.States.StateMachine;
using Runtime.Services;
using Zenject;

namespace Runtime.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindSelf();
            BindStates();
            BindStateMachine();
            BindServices();
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
    }
}