using Runtime.Gameplay.Player.Factory;
using Runtime.Gameplay.Player.Provider;
using Runtime.Gameplay.Weapon.Spawner;
using UnityEngine;

namespace Runtime.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly WeaponSpawner _weaponSpawner;

        private PlayerViewProvider _playerViewProvider;
        
        public BootstrapState(IPlayerFactory playerFactory, WeaponSpawner weaponSpawner)
        {
            _playerFactory = playerFactory;
            _weaponSpawner = weaponSpawner;
        }
        
        public void Enter()
        {
            var playerView = _playerFactory.CreatePlayer(new Vector3(0,1.05f,0));
            _weaponSpawner._spawnCenter = playerView.Transform;
            _playerViewProvider = new PlayerViewProvider(playerView);
        }

        public void Exit()
        {
        }
    }
}