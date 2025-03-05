using Zenject;

namespace Runtime.Infrastructure.States.StateMachine
{
    public class GameStateMachine : IGameStateMachine, ITickable
    {
        private IState _activeState;

        private readonly DiContainer _container;

        public GameStateMachine(DiContainer container)
        {
            _container = container;
        }

        public void Tick()
        {
            if (_activeState is ITickable tickableState)
                tickableState.Tick();
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        private IState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            var state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState => 
            _container.Resolve<TState>();
    }
}