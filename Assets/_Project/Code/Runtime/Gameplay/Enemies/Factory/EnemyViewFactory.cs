using Runtime.Constants;
using Runtime.Infrastructure.Assets;
using Zenject;

namespace Runtime.Gameplay.Enemies.Factory
{
    public class EnemyViewFactory : IEnemyViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public EnemyViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public EnemyView CreateView(Enemy enemy)
        {
            var prefab = _assetProvider.Load<EnemyView>(Paths.Enemy);
            
            var view = _instantiator.InstantiatePrefabForComponent<EnemyView>(prefab);
            view.Initialize(enemy);
            return view;
        }
    }
}