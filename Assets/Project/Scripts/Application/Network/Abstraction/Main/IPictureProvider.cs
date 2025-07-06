using System;
using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;
using UnityEngine;

namespace Project.Application.Network.Abstraction
{
    public interface IPictureProvider
    {
        UniTask<Sprite> LoadPreviewSprite(IPictureDef pictureDef, Action<Sprite> onSuccess = null);
        UniTask<Sprite> LoadFullSprite(IPictureDef pictureDef, Action<Sprite> onSuccess = null);
    }
}