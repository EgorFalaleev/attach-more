using Runtime.Gameplay.Enemies.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Enemies.Spawner
{
    public class EnemySpawner : ITickable, IEnemySpawner
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IEnemyViewFactory _enemyViewFactory;

        private Transform _spawnCenter;
        private float _timer;
        private bool _canSpawn;

        public EnemySpawner(IEnemyFactory enemyFactory, IEnemyViewFactory enemyViewFactory)
        {
            _enemyFactory = enemyFactory;
            _enemyViewFactory = enemyViewFactory;
        }
        
        public void Tick()
        {
            if (!_canSpawn)
                return;
            
            _timer += Time.deltaTime;

            if (_timer >= 4f)
            {
                var enemy = _enemyFactory.CreateEnemy(GetRandomPosition(_spawnCenter.position, 3f, 10f));
                _enemyViewFactory.CreateView(enemy);
                _timer = 0f;
            }
        }

        public void StartSpawning(Transform spawnCenter)
        {
            _spawnCenter = spawnCenter;
            _canSpawn = true;
        }

        public void StopSpawning()
        {
            _canSpawn = false;
        }

        private Vector3 GetRandomPosition(Vector3 center, float minRadius, float maxRadius)
        {
            var radius = Random.Range(minRadius, maxRadius);
            var randomDirection2D = Random.insideUnitCircle.normalized;
            var randomDirection = new Vector3(randomDirection2D.x, 0f, randomDirection2D.y);

            return center + randomDirection * radius;
        }
    }
}