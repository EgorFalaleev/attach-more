using Runtime.Gameplay.Weapon.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapon.Spawner
{
    public class WeaponSpawner : ITickable
    {
        public Transform _spawnCenter;
        private readonly IWeaponFactory _weaponFactory;

        private float _spawnCooldown = 5f;
        private float _timeFromLastSpawn;
        private float _spawnRadius = 5f;
        
        public WeaponSpawner(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }
        
        public void Tick()
        {
            if (_spawnCenter == null)
                return;
            
            _timeFromLastSpawn += Time.deltaTime;

            if (_timeFromLastSpawn >= _spawnCooldown)
            {
                _timeFromLastSpawn = 0f;
                var randomPosition = GetRandomPositionAroundPoint(_spawnCenter.position);
                _weaponFactory.CreateWeapon(randomPosition);
            }
        }
        
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