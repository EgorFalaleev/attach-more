using UnityEngine;

namespace Runtime.Infrastructure.Assets
{
    public interface IAssetProvider
    {
        GameObject Load(string path);
        T Load<T>(string path) where T : Component;
    }
}