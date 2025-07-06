using System;
using Cysharp.Threading.Tasks.Linq;
using Project.Application.Domain.Abstraction;
using Project.Meta.UI.View;
using Zenject;

namespace Project.Meta.UI.Presenter
{
    public class MainMenuScreenPresenter : IInitializable, IDisposable
    {
        private readonly MainMenuScreenView _mainMenuScreenView;
        private readonly ICurrencyModel _currencyModel;

        public MainMenuScreenPresenter(MainMenuScreenView mainMenuScreenView, 
            ICurrencyModel currencyModel)
        {
            _mainMenuScreenView = mainMenuScreenView;
            _currencyModel = currencyModel;
        }

        public void Initialize()
        {
            _currencyModel.Gold.Subscribe(GoldChange);
        }

        public void Dispose()
        {
        }

        private void GoldChange(int gold)
        {
            _mainMenuScreenView.SetGold(gold);
        }
    }
}