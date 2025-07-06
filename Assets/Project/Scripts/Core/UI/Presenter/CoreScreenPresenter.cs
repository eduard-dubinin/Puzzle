using System;
using Cysharp.Threading.Tasks;
using Project.Application.Domain.Abstraction;
using Project.Application.Network.Abstraction;
using Project.Core.UI.View;
using Zenject;

namespace Project.Core.UI.Presenter
{
    public class CoreScreenPresenter : IInitializable, IDisposable
    {
        private readonly CoreScreenView _coreScreenView;
        private readonly IPictureModel _pictureModel;
        private readonly IPuzzleModel _puzzleModel;
        private readonly SignalBus _signalBus;
        private readonly IPictureProvider _pictureProvider;

        public CoreScreenPresenter(CoreScreenView coreScreenView,
            IPictureModel pictureModel,
            IPuzzleModel puzzleModel,
            SignalBus signalBus,
            IPictureProvider pictureProvider)
        {
            _coreScreenView = coreScreenView;
            _pictureModel = pictureModel;
            _puzzleModel = puzzleModel;
            _signalBus = signalBus;
            _pictureProvider = pictureProvider;
        }

        public void Initialize()
        {
            _pictureProvider.LoadFullSprite(_pictureModel.SelectedPictureDef, fullSprite =>
            {
                _coreScreenView.SetFullPictureSprite(fullSprite);
            }).Forget();
            
            _coreScreenView.SetPieceCountText(_puzzleModel.SelectedPieceCount);
            _coreScreenView.ExitButton.onClick.AddListener(() => { _signalBus.Fire(new ExitCoreSignal()); });
        }

        public void Dispose()
        {
            _coreScreenView.ExitButton.onClick.RemoveAllListeners();
        }
    }
}