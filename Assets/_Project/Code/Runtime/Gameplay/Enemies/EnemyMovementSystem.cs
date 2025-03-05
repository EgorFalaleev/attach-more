using Runtime.Gameplay.Enemies.Provider;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Enemies
{
    public class EnemyMovementSystem : ITickable
    {
        private readonly IEnemiesProvider _enemiesProvider;

        public EnemyMovementSystem(IEnemiesProvider enemiesProvider)
        {
            _enemiesProvider = enemiesProvider;
        }

        public void Tick()
        {
            foreach (var enemy in _enemiesProvider.Enemies)
            {
                enemy.Move(Time.deltaTime);
            }
        }
    }
}