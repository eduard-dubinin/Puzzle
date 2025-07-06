using Zenject;

namespace Project.Core.Scene
{
    public class CoreSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoreSceneInitializer>().AsSingle();
        }
    }
}