using Project.Core.UI.Presenter;
using Project.Core.UI.View;
using Project.Utility;
using UnityEngine;
using Zenject;

namespace Project.Core.UI
{
    public class CoreUIInstaller : MonoInstaller
    {
        [SerializeField] private CoreScreenView _coreScreenView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfInstance(_coreScreenView);

            Container.BindInterfacesTo<CoreScreenPresenter>().AsSingle();
        }
    }
}