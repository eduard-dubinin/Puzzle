using Cysharp.Threading.Tasks;

namespace Project.Application.Network.Abstraction
{
    public interface INetworkConnection
    {
        UniTask ConnectAsync();
    }
}