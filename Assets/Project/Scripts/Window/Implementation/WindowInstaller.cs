using Zenject;

namespace Project.Window.Implementation
{
    public class WindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WindowSwitcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<WindowModel>().AsSingle();
        }
    }
}