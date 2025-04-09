using UnityEngine;

namespace Runtime.Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        EnemyView CreateEnemy(Vector3 spawnPoint);
    }
}