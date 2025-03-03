using UnityEngine;

namespace Runtime.Gameplay.Enemies.Spawner
{
    public interface IEnemySpawner
    {
        void StartSpawning(Transform spawnCenter);
        void StopSpawning();
    }
}