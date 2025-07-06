using Zenject;

namespace Project.Application.Scene
{
    public class ApplicationSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ApplicationSceneInitializer>().AsSingle();
        }
    }
}