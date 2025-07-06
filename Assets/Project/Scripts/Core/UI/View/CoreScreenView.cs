using Project.Window.Abstraction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Core.UI.View
{
    public class CoreScreenView : WindowView, IScreenView
    {
        [SerializeField] private Image _fullPictureImage;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TextMeshProUGUI _pieceCountText;

        public Button ExitButton => _exitButton;

        public void SetFullPictureSprite(Sprite fullPictureSprite)
        {
            _fullPictureImage.sprite = fullPictureSprite;
        }

        public void SetPieceCountText(int pieceCount)
        {
            _pieceCountText.text = $"Piece Count:{pieceCount.ToString()}";
        }
    }
}