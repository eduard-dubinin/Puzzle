using Zenject;

namespace Project.Utility
{
    public class UtilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        }
    }
}