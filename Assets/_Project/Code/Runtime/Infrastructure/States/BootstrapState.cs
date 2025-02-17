using Runtime.Gameplay.Player.Factory;
using UnityEngine;

namespace Runtime.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IPlayerFactory _playerFactory;

        public BootstrapState(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void Enter()
        {
            _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
        }

        public void Exit()
        {
        }
    }
}