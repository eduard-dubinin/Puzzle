using Project.Application.UseCase;
using Zenject;

namespace Project.Scripts.Application.UseCase
{
    public class ApplicationUseCaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SelectPictureUseCase>().AsSingle();
            Container.BindInterfacesTo<SelectPieceCountUseCase>().AsSingle();
            Container.BindInterfacesTo<BuyPictureUseCase>().AsSingle();
        }
    }
}