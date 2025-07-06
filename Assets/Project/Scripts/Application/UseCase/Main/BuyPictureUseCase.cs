using System;
using Project.Application.Domain.Abstraction;
using UnityEngine;
using Zenject;

namespace Project.Application.UseCase
{
    public class BuyPictureUseCase : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ICurrencyModel _currencyModel;
        private readonly IPictureModel _pictureModel;

        public BuyPictureUseCase(SignalBus signalBus, 
            ICurrencyModel currencyModel,
            IPictureModel pictureModel)
        {
            _signalBus = signalBus;
            _currencyModel = currencyModel;
            _pictureModel = pictureModel;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<BuyPictureSignal>(BuyPictureSignalHandler);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<BuyPictureSignal>(BuyPictureSignalHandler);
        }

        private void BuyPictureSignalHandler(BuyPictureSignal signal)
        {
            var pictureDef = signal.PictureDef;
            if (pictureDef.PriceGold > _currencyModel.Gold.Value)
            {
                Debug.LogWarning($"Can't buy picture {pictureDef.Title}");
                return;
            }

            _currencyModel.Decrease(signal.PictureDef.PriceGold);
            _pictureModel.UnlockPicture(pictureDef);
            
            _signalBus.Fire(new UnlockPictureSignal(signal.PictureDef));
        }
    }
}