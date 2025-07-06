using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.Utility
{
    public class SceneLoader
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public async UniTask LoadSceneAsync(string sceneName, bool fastLoad)
        {
            if (fastLoad) Application.backgroundLoadingPriority = ThreadPriority.High;
            await _zenjectSceneLoader.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (fastLoad) Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;

            SetActiveScene(sceneName);

            await UniTask.NextFrame(); //for initialize
        }

        public async UniTask UnloadSceneAsync(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName);
        }

        private void SetActiveScene(string sceneName)
        {
            var nextScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(nextScene);
        }
    }
}