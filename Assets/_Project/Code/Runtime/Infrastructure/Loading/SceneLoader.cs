using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Runtime.Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadAsync(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                return;
            }

            var loadOperation = SceneManager.LoadSceneAsync(sceneName);

            await loadOperation;
            
            onLoaded?.Invoke();
        }
    }
}