using System;
using Project.Application.Domain.Abstraction;
using Zenject;

namespace Project.Application.UseCase
{
    public class SelectPictureUseCase : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IPictureModel _pictureModel;

        public SelectPictureUseCase(SignalBus signalBus,
            IPictureModel pictureModel)
        {
            _signalBus = signalBus;
            _pictureModel = pictureModel;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SelectPictureSignal>(SelectPictureSignalHandler);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SelectPictureSignal>(SelectPictureSignalHandler);
        }

        private void SelectPictureSignalHandler(SelectPictureSignal signal)
        {
            _pictureModel.SelectPictureDef(signal.SelectedPictureDef);
        }
    }
}