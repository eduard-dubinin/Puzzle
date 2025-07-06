using System.Collections.Generic;
using Project.Window.Abstraction;

namespace Project.Window.Implementation
{
    public class WindowModel
    {
        public IScreenView CurrentScreenView { get; set; }

        public IReadOnlyCollection<IPopupView> PopupViews => _popupViewStack;
        private readonly HashSet<IPopupView> _popupViewStack = new();

        public void AddedPopupToQueue(IPopupView popupView)
        {
            _popupViewStack.Add(popupView);
        }

        public void RemovedPopupFromQueue(IPopupView popupView)
        {
            _popupViewStack.Remove(popupView);
        }
    }
}