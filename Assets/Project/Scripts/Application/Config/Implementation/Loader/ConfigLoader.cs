using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;

namespace Project.Application.Config.Implementation
{
    public class ConfigLoader : IConfigLoader
    {
        public async UniTask LoadAsync()
        {
            await UniTask.WaitForSeconds(1f); //fake loading
        }
    }
}