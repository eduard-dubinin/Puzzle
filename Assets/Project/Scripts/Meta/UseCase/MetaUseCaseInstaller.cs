using Zenject;

namespace Project.Scripts.Meta.UseCase
{
    public class MetaUseCaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoreUseCase>().AsSingle();
        }
    }
}