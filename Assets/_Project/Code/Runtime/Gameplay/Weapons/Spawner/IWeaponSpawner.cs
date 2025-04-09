using UnityEngine;

namespace Runtime.Gameplay.Weapons.Spawner
{
    public interface IWeaponSpawner
    {
        void StartSpawning(Transform spawnCenter);
        void StopSpawning();
    }
}