using Runtime.Constants;
using Runtime.Infrastructure.Loading;
using Runtime.Infrastructure.States.StateMachine;

namespace Runtime.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter() => 
            await _sceneLoader.LoadAsync(Scenes.Gameplay, EnterGameLoopState);

        public void Exit()
        {
        }

        private void EnterGameLoopState() => 
            _gameStateMachine.Enter<GameLoopState>();
    }
}