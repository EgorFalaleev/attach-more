using System;
using Cysharp.Threading.Tasks;

namespace Runtime.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        UniTask LoadAsync(string sceneName, Action onLoaded = null);
    }
}