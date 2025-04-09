using Runtime.Gameplay.Weapons.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapons.Spawner
{
    public class WeaponSpawner : ITickable, IWeaponSpawner
    {
        private readonly IWeaponFactory _weaponFactory;
        
        private Transform _spawnCenter;
        private bool _canSpawn;
        private float _spawnCooldown = 5f;
        private float _timeFromLastSpawn;
        private float _spawnRadius = 5f;
        
        public WeaponSpawner(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }
        
        public void Tick()
        {
            if (!_canSpawn)
                return;
            
            _timeFromLastSpawn += Time.deltaTime;

            if (_timeFromLastSpawn >= _spawnCooldown)
            {
                _timeFromLastSpawn = 0f;
                var randomPosition = GetRandomPositionAroundPoint(_spawnCenter.position);
                _weaponFactory.CreateWeapon(randomPosition);
            }
        }

        public void StartSpawning(Transform spawnCenter)
        {
            _spawnCenter = spawnCenter;
            _canSpawn = true;
        }

        public void StopSpawning() =>
            _canSpawn = false;
        
        private Vector3 GetRandomPositionAroundPoint(Vector3 point)
        {
            var randomOffset = Random.insideUnitCircle * _spawnRadius;

            return new Vector3(
                point.x + randomOffset.x,
                1f,
                point.z + randomOffset.y
            );
        }
    }
}