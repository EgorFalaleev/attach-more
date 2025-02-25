using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;

namespace Runtime.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWeaponSpawner _weaponSpawner;

        public GameLoopState(IPlayerFactory playerFactory, IWeaponSpawner weaponSpawner)
        {
            _playerFactory = playerFactory;
            _weaponSpawner = weaponSpawner;
        }
        
        public void Enter()
        {
            var playerView = _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
            _weaponSpawner.StartSpawning(playerView.Transform);
        }

        public void Exit()
        {
        }
    }
}