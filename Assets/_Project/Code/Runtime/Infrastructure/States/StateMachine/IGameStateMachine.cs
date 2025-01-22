namespace Runtime.Infrastructure.States.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}