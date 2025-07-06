using Project.Application.Domain.Abstraction;
using Project.Utility;
using Zenject;

namespace Project.Application.Domain.Implementation
{
    public class ApplicationDomainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindSignalBus();
            Container.DeclareSignal<SelectPictureSignal>();
            Container.DeclareSignal<SelectPieceCountSignal>();
            Container.DeclareSignal<EnterCoreSignal>();
            Container.DeclareSignal<ExitCoreSignal>();
            Container.DeclareSignal<BuyPictureSignal>();
            Container.DeclareSignal<UnlockPictureSignal>();

            Container.BindInterfacesTo<PictureModel>().AsSingle();
            Container.BindInterfacesTo<PuzzleModel>().AsSingle();
            Container.BindInterfacesTo<CurrencyModel>().AsSingle();
        }
    }
}