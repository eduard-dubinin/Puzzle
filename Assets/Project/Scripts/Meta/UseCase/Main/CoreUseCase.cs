using System;
using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;
using Project.Application.Domain.Abstraction;
using Project.Meta.UI.View;
using Project.Utility;
using Project.Window.Abstraction;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Meta.UseCase
{
    public class CoreUseCase : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly SceneLoader _sceneLoader;
        private readonly ISceneConfig _sceneConfig;
        private readonly IWindowSwitcher _windowSwitcher;
        private readonly MainMenuScreenView _mainMenuScreenView;
        private readonly IPictureModel _pictureModel;

        public CoreUseCase(SignalBus signalBus,
            SceneLoader sceneLoader,
            ISceneConfig sceneConfig,
            IWindowSwitcher windowSwitcher,
            MainMenuScreenView mainMenuScreenView,
            IPictureModel pictureModel)
        {
            _signalBus = signalBus;
            _sceneLoader = sceneLoader;
            _sceneConfig = sceneConfig;
            _windowSwitcher = windowSwitcher;
            _mainMenuScreenView = mainMenuScreenView;
            _pictureModel = pictureModel;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnterCoreSignal>(EnterCoreSignalHandler);
            _signalBus.Subscribe<ExitCoreSignal>(ExitCoreSignalHandler);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnterCoreSignal>(EnterCoreSignalHandler);
            _signalBus.Unsubscribe<ExitCoreSignal>(ExitCoreSignalHandler);
        }

        private void EnterCoreSignalHandler(EnterCoreSignal signal)
        {
            var selectedPictureDef = _pictureModel.SelectedPictureDef;
            if (!_pictureModel.IsUnlockPicture(_pictureModel.SelectedPictureDef))
            {
                Debug.LogError($"Can't start core with selected picture:{selectedPictureDef.Title}");
                return;
            }
            
            _sceneLoader.LoadSceneAsync(_sceneConfig.CoreSceneName, false).Forget();
        }

        private void ExitCoreSignalHandler(ExitCoreSignal signal)
        {
            ExitCoreAsync().Forget();
        }

        private async UniTask ExitCoreAsync()
        {
            await _windowSwitcher.ShowWindowAsync(_mainMenuScreenView);
            await _sceneLoader.UnloadSceneAsync(_sceneConfig.CoreSceneName);
        }
    }
}