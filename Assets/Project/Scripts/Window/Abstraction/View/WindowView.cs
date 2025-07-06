using UnityEngine;

namespace Project.Window.Abstraction
{
    public abstract class WindowView : MonoBehaviour, IWindowView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}