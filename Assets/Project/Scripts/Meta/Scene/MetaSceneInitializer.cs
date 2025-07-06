using Cysharp.Threading.Tasks;
using Project.Meta.UI.View;
using Project.Window.Abstraction;
using Zenject;

namespace Project.Meta
{
    public class MetaSceneInitializer : IInitializable
    {
        private readonly MainMenuScreenView _mainMenuScreenView;
        private readonly IWindowSwitcher _windowSwitcher;

        public MetaSceneInitializer(MainMenuScreenView mainMenuScreenView, IWindowSwitcher windowSwitcher)
        {
            _mainMenuScreenView = mainMenuScreenView;
            _windowSwitcher = windowSwitcher;
        }

        public void Initialize()
        {
            _windowSwitcher.ShowWindowAsync(_mainMenuScreenView).Forget();
        }
    }
}