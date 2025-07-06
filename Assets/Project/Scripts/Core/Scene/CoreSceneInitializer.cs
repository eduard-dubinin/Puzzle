using Cysharp.Threading.Tasks;
using Project.Core.UI.View;
using Project.Window.Abstraction;
using Zenject;

namespace Project.Core.Scene
{
    public class CoreSceneInitializer : IInitializable
    {
        private readonly IWindowSwitcher _windowSwitcher;
        private readonly CoreScreenView _coreScreenView;

        public CoreSceneInitializer(IWindowSwitcher windowSwitcher, CoreScreenView coreScreenView)
        {
            _windowSwitcher = windowSwitcher;
            _coreScreenView = coreScreenView;
        }

        public void Initialize()
        {
            _windowSwitcher.ShowWindowAsync(_coreScreenView).Forget();
        }
    }
}