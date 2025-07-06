using System;
using Cysharp.Threading.Tasks;
using Project.Window.Abstraction;

namespace Project.Window.Implementation
{
    public class WindowSwitcher : IWindowSwitcher
    {
        private readonly WindowModel _windowModel;

        public WindowSwitcher(WindowModel windowModel)
        {
            _windowModel = windowModel;
        }

        public UniTask ShowWindowAsync(IWindowView windowView)
        {
            //await animation
            switch (windowView)
            {
                case IScreenView screenView:
                {
                    foreach (var popupView in _windowModel.PopupViews)
                    {
                        popupView.Hide();
                    }

                    _windowModel.CurrentScreenView?.Hide();

                    _windowModel.CurrentScreenView = screenView;
                    screenView.Show();
                    break;
                }
                case IPopupView popupView:
                    _windowModel.AddedPopupToQueue(popupView);
                    popupView.Show();
                    break;
                default:
                    throw new ArgumentException($"Not a valid window view:{windowView.GetType()}");
            }

            return UniTask.CompletedTask;
        }

        public UniTask HideWindowAsync(IWindowView windowView)
        {
            //await animation
            switch (windowView)
            {
                case IScreenView screenView:
                {
                    if (_windowModel.CurrentScreenView == screenView)
                    {
                        _windowModel.CurrentScreenView = null;
                    }

                    break;
                }
                case IPopupView popupView:
                    _windowModel.RemovedPopupFromQueue(popupView);
                    break;
                default:
                    throw new ArgumentException($"Not a valid window view:{windowView.GetType()}");
            }

            windowView.Hide();

            return UniTask.CompletedTask;
        }
    }
}