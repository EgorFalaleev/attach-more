using Zenject;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyViewFactory : IEnemyViewFactory
    {
        private readonly EnemyView _enemyPrefab;
        private readonly IInstantiator _instantiator;

        public EnemyViewFactory(EnemyView enemyPrefab, IInstantiator instantiator)
        {
            _enemyPrefab = enemyPrefab;
            _instantiator = instantiator;
        }

        public EnemyView CreateView(Enemy enemy)
        {
            var view = _instantiator.InstantiatePrefabForComponent<EnemyView>(_enemyPrefab);
            view.Initialize(enemy);
            return view;
        }
    }
}