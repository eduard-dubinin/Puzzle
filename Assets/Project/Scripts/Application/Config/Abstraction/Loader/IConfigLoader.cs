using Cysharp.Threading.Tasks;

namespace Project.Application.Config.Abstraction
{
    public interface IConfigLoader
    {
        UniTask LoadAsync();
    }
}