using Cysharp.Threading.Tasks;

namespace Project.Window.Abstraction
{
    public interface IWindowSwitcher
    {
        UniTask ShowWindowAsync(IWindowView windowView);
        UniTask HideWindowAsync(IWindowView windowView);
    }
}