using Runtime.Gameplay.Enemies.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Enemies.Spawner
{
    public class EnemySpawner : ITickable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IEnemyViewFactory _enemyViewFactory;

        private float _timer;

        public EnemySpawner(IEnemyFactory enemyFactory, IEnemyViewFactory enemyViewFactory)
        {
            _enemyFactory = enemyFactory;
            _enemyViewFactory = enemyViewFactory;
        }
        
        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer >= 1f)
            {
                var enemy = _enemyFactory.CreateEnemy(new Vector3(0f, 1f, 0f));
                _enemyViewFactory.CreateView(enemy);
                _timer = 0f;
            }
        }
    }
}