using System;
using Project.Application.Config.Abstraction;
using UnityEngine;

namespace Project.Application.Config.Implementation
{
    [Serializable]
    public class PictureDef : IPictureDef
    {
        [SerializeField] private string _title;
        [SerializeField] private Sprite _previewSprite;
        [SerializeField] private Sprite _fullSprite;
        [SerializeField] private string[] _tags;
        [SerializeField] private int _priceGold;

        public string Title => _title;
        public Sprite PreviewSprite => _previewSprite;
        public Sprite FullSprite => _fullSprite;
        public string[] Tags => _tags;
        public int PriceGold => _priceGold;
    }
}