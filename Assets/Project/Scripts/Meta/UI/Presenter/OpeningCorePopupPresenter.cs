using System;
using Cysharp.Threading.Tasks;
using NUnit.Framework.Internal;
using Project.Application.Config.Abstraction;
using Project.Application.Domain.Abstraction;
using Project.Application.Network.Abstraction;
using Project.Meta.UI.View;
using Project.Window.Abstraction;
using UnityEngine;
using Zenject;

namespace Project.Meta.UI.Presenter
{
    public class OpeningCorePopupPresenter : IInitializable, IDisposable
    {
        private readonly OpeningCorePopupView _openingCorePopupView;
        private readonly SignalBus _signalBus;
        private readonly IWindowSwitcher _windowSwitcher;
        private readonly IPuzzleConfig _puzzleConfig;
        private readonly IPictureProvider _pictureProvider;
        private readonly ICurrencyModel _currencyModel;
        private readonly IPictureModel _pictureModel;

        public OpeningCorePopupPresenter(OpeningCorePopupView openingCorePopupView,
            SignalBus signalBus,
            IWindowSwitcher windowSwitcher,
            IPuzzleConfig puzzleConfig,
            IPictureProvider pictureProvider,
            ICurrencyModel currencyModel,
            IPictureModel pictureModel)
        {
            _openingCorePopupView = openingCorePopupView;
            _signalBus = signalBus;
            _windowSwitcher = windowSwitcher;
            _puzzleConfig = puzzleConfig;
            _pictureProvider = pictureProvider;
            _currencyModel = currencyModel;
            _pictureModel = pictureModel;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SelectPictureSignal>(SelectPictureSignalHandler);
            _openingCorePopupView.CloseButton.onClick.AddListener(CloseButtonClickHandler);
            _openingCorePopupView.PlayButton.onClick.AddListener(PlayButtonClickHandler);
            _openingCorePopupView.BuyButton.onClick.AddListener(BuyButtonClickHandler);

            _openingCorePopupView.UpdatePiecesCount(_puzzleConfig.PiecesCount);
            _openingCorePopupView.PiecesCountDropdown.onValueChanged.AddListener(PiecesCountDropdownChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SelectPictureSignal>(SelectPictureSignalHandler);
            _openingCorePopupView.CloseButton.onClick.RemoveAllListeners();
            _openingCorePopupView.PlayButton.onClick.RemoveAllListeners();
            _openingCorePopupView.BuyButton.onClick.RemoveAllListeners();
            _openingCorePopupView.PiecesCountDropdown.onValueChanged.RemoveAllListeners();
        }

        private void SelectPictureSignalHandler(SelectPictureSignal signal)
        {
            var pictureDef = signal.SelectedPictureDef;
            _pictureProvider.LoadFullSprite(pictureDef,
                fullSprite => { _openingCorePopupView.SetFullPictureSprite(fullSprite); }).Forget();

            UpdateButtons(pictureDef);

            _windowSwitcher.ShowWindowAsync(_openingCorePopupView).Forget();
        }

        private void UpdateButtons(IPictureDef selectedPicture)
        {
            var isUnlockPicture = _pictureModel.IsUnlockPicture(selectedPicture);
            _openingCorePopupView.BuyButton.gameObject.SetActive(!isUnlockPicture);
            _openingCorePopupView.PlayButton.gameObject.SetActive(isUnlockPicture);

            if (!isUnlockPicture)
            {
                var canBuy = _currencyModel.Gold.Value >= selectedPicture.PriceGold;
                _openingCorePopupView.SetBuyButtonText(selectedPicture.PriceGold, canBuy);
            }
        }

        private void CloseButtonClickHandler()
        {
            _windowSwitcher.HideWindowAsync(_openingCorePopupView).Forget();
        }

        private void PlayButtonClickHandler()
        {
            _signalBus.Fire(new EnterCoreSignal());
        }

        private void BuyButtonClickHandler()
        {
            _signalBus.Fire(new BuyPictureSignal(_pictureModel.SelectedPictureDef));
            UpdateButtons(_pictureModel.SelectedPictureDef);
        }

        private void PiecesCountDropdownChanged(int index)
        {
            var piecesCount = _puzzleConfig.PiecesCount[index];
            _signalBus.Fire(new SelectPieceCountSignal(piecesCount));
        }
    }
}