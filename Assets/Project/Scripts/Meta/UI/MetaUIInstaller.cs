using Project.Meta.UI.Presenter;
using Project.Meta.UI.View;
using Project.Utility;
using UnityEngine;
using Zenject;

namespace Project.Meta.UI
{
    public class MetaUIInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuScreenView _mainMenuScreenView;
        [SerializeField] private PictureScrollView _pictureScrollView;
        [SerializeField] private OpeningCorePopupView _openingCorePopupView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfInstance(_mainMenuScreenView);
            Container.BindInterfacesAndSelfInstance(_pictureScrollView);
            Container.BindInterfacesAndSelfInstance(_openingCorePopupView);

            Container.BindInterfacesTo<MainMenuScreenPresenter>().AsSingle();
            Container.BindInterfacesTo<PictureScrollPresenter>().AsSingle();
            Container.BindInterfacesTo<OpeningCorePopupPresenter>().AsSingle();
        }
    }
}