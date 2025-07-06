using System.Collections.Generic;
using Project.Application.Config.Abstraction;
using Project.Application.Domain.Abstraction;

namespace Project.Application.Domain.Implementation
{
    public class PictureModel : IPictureModel
    {
        public IPictureDef SelectedPictureDef { get; private set; }
        
        private readonly HashSet<IPictureDef> _unlockPicturesSet = new ();

        public void SelectPictureDef(IPictureDef pictureDef)
        {
            SelectedPictureDef = pictureDef;
        }

        public void UnlockPicture(IPictureDef pictureDef)
        {
            _unlockPicturesSet.Add(pictureDef);
        }

        public bool IsUnlockPicture(IPictureDef pictureDef)
        {
            if (pictureDef.PriceGold <= 0) return true;
            if (_unlockPicturesSet.Contains(pictureDef)) return true;

            return false;
        }
    }
}