using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapon.Spawner
{
    public class WeaponSpawner : ITickable
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly Transform _playerTransform;

        private float _spawnCooldown = 1f;
        private float _timeFromLastSpawn;
        private float _spawnRadius = 5f;
        
        public WeaponSpawner(IWeaponFactory weaponFactory, PlayerView playerView)
        {
            _weaponFactory = weaponFactory;
            _playerTransform = playerView.transform;
            Debug.Log("ctor");
        }
        
        public void Tick()
        {
            Debug.Log("Tick");
            _timeFromLastSpawn += Time.deltaTime;

            if (_timeFromLastSpawn >= _spawnCooldown)
            {
                _timeFromLastSpawn = 0f;
                var randomPosition = GetRandomPositionAroundPlayer();
                _weaponFactory.CreateWeapon(randomPosition);
            }
        }
        
        private Vector3 GetRandomPositionAroundPlayer()
        {
            var randomOffset = Random.insideUnitCircle * _spawnRadius;
            var playerPosition = _playerTransform.position;

            return new Vector3(
                playerPosition.x + randomOffset.x,
                1f,
                playerPosition.z + randomOffset.y
            );
        }
    }
}