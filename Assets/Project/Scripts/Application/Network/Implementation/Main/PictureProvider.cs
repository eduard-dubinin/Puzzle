using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;
using Project.Application.Network.Abstraction;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Application.Network.Implementation
{
    public class PictureProvider : IPictureProvider
    {
        private readonly HashSet<IPictureDef> _loadedPictureDefs = new();

        public async UniTask<Sprite> LoadPreviewSprite(IPictureDef pictureDef, Action<Sprite> onSuccess = null)
        {
            pictureDef = await FakeLoadPicture(pictureDef);
            onSuccess?.Invoke(pictureDef.PreviewSprite);
            return pictureDef.PreviewSprite;
        }

        public async UniTask<Sprite> LoadFullSprite(IPictureDef pictureDef, Action<Sprite> onSuccess = null)
        {
            pictureDef = await FakeLoadPicture(pictureDef);
            onSuccess?.Invoke(pictureDef.FullSprite);
            return pictureDef.FullSprite;
        }

        private async UniTask<IPictureDef> FakeLoadPicture(IPictureDef pictureDef)
        {
            if (_loadedPictureDefs.Contains(pictureDef))
            {
                return pictureDef;
            }

            var randomDuration = Random.Range(0, 1.5f);
            await UniTask.WaitForSeconds(randomDuration); //fake loading

            _loadedPictureDefs.Add(pictureDef);
            return pictureDef;
        }
    }
}