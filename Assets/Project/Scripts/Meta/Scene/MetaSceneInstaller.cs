using Zenject;

namespace Project.Meta
{
    public class MetaSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MetaSceneInitializer>().AsSingle();
        }
    }
}