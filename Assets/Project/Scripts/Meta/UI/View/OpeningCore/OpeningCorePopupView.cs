using System.Collections.Generic;
using System.Linq;
using Project.Window.Abstraction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Meta.UI.View
{
    public class OpeningCorePopupView : WindowView, IPopupView
    {
        [SerializeField] private Image _fullPictureImage;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _buyButtonText;
        [SerializeField] private TMP_Dropdown _piecesCountDropdown;

        public Button CloseButton => _closeButton;
        public Button PlayButton => _playButton;
        public Button BuyButton => _buyButton;
        public TMP_Dropdown PiecesCountDropdown => _piecesCountDropdown;

        public void SetFullPictureSprite(Sprite fullPictureSprite)
        {
            _fullPictureImage.sprite = fullPictureSprite;
        }

        public void UpdatePiecesCount(IReadOnlyList<int> piecesCount)
        {
            _piecesCountDropdown.ClearOptions();

            var piecesCountString = piecesCount.Select(pieceCount => pieceCount.ToString()).ToList();
            _piecesCountDropdown.AddOptions(piecesCountString);
        }

        public void SetBuyButtonText(int priceGold, bool canBuy)
        {
            _buyButtonText.text = $"Buy ({priceGold})";
            
            var color = canBuy ? Color.black : Color.red;
            _buyButtonText.color = color;
        }
    }
}