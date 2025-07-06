using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;
using Project.Application.Network.Abstraction;
using Project.Utility;
using Zenject;

namespace Project.Application.Scene
{
    public class ApplicationSceneInitializer : IInitializable
    {
        private readonly IConfigLoader _configLoader;
        private readonly SceneLoader _sceneLoader;
        private readonly ISceneConfig _sceneConfig;
        private readonly INetworkConnection _networkConnection;

        public ApplicationSceneInitializer(IConfigLoader configLoader,
            SceneLoader sceneLoader,
            ISceneConfig sceneConfig,
            INetworkConnection networkConnection)
        {
            _configLoader = configLoader;
            _sceneLoader = sceneLoader;
            _sceneConfig = sceneConfig;
            _networkConnection = networkConnection;
        }

        public void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
            await _networkConnection.ConnectAsync();
            await _configLoader.LoadAsync();
            await _sceneLoader.LoadSceneAsync(_sceneConfig.MetaSceneName, true);
        }
    }
}