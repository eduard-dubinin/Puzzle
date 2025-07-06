using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Meta.UI.View
{
    public class PictureScrollCellView : MonoBehaviour
    {
        [SerializeField] private Image _previewImage;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _tagsText;
        [SerializeField] private TextMeshProUGUI _unlockText;
        [SerializeField] private Button _selectButton;

        public Button SelectButton => _selectButton;

        public void SetPreviewImage(Sprite previewSprite)
        {
            _previewImage.sprite = previewSprite;
        }

        public void SetTitle(string title)
        {
            _titleText.text = title;
        }

        public void SetTags(string[] tags)
        {
            _tagsText.text = $"Tags: {string.Join(", ", tags)}";
        }

        public void SetLockedText(int priceGold)
        {
            _unlockText.text = $"Price gold: {priceGold}";
        }

        public void SetUnlockText()
        {
            _unlockText.text = $"Unlocked!";
        }
    }
}