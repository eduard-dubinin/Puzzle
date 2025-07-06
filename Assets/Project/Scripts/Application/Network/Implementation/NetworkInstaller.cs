using Zenject;

namespace Project.Application.Network.Implementation
{
    public class NetworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NetworkConnection>().AsSingle();
            Container.BindInterfacesTo<PictureProvider>().AsSingle();
        }
    }
}