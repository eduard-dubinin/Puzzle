using Cysharp.Threading.Tasks;
using Project.Application.Domain.Abstraction;
using Project.Application.Network.Abstraction;
using UnityEngine;

namespace Project.Application.Network.Implementation
{
    public class NetworkConnection : INetworkConnection
    {
        private readonly ICurrencyModel _currencyModel;

        public NetworkConnection(ICurrencyModel currencyModel)
        {
            _currencyModel = currencyModel;
        }

        public async UniTask ConnectAsync()
        {
            await UniTask.WaitForSeconds(0.5f); //fake loading

            _currencyModel.Increment(Random.Range(500, 1000));
        }
    }
}