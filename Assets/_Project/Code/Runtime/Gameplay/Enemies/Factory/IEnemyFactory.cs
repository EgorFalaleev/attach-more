using UnityEngine;

namespace Runtime.Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(Vector3 spawnPoint);
    }
}