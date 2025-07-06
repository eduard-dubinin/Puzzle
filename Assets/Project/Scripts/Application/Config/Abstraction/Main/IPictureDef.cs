using UnityEngine;

namespace Project.Application.Config.Abstraction
{
    public interface IPictureDef
    {
        string Title { get; }
        Sprite PreviewSprite { get; }
        Sprite FullSprite { get; }
        string[] Tags { get; }
        int PriceGold { get; }
    }
}