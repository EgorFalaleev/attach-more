using UnityEngine;

namespace Runtime.Infrastructure.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Load(string path) => 
            Resources.Load<GameObject>(path);

        public T Load<T>(string path) where T : Component => 
            Resources.Load<T>(path);
    }
}