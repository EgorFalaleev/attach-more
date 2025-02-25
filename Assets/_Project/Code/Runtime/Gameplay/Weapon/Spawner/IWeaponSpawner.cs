using UnityEngine;

namespace Runtime.Gameplay.Weapon.Spawner
{
    public interface IWeaponSpawner
    {
        void StartSpawning(Transform spawnCenter);
        void StopSpawning();
    }
}