using Project.Window.Abstraction;
using TMPro;
using UnityEngine;

namespace Project.Meta.UI.View
{
    public class MainMenuScreenView : WindowView, IScreenView
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        public void SetGold(int gold)
        {
            _goldText.text = $"Gold: {gold}";
        }
    }
}