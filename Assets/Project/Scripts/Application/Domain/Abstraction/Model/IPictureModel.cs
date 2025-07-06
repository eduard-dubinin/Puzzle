using Project.Application.Config.Abstraction;

namespace Project.Application.Domain.Abstraction
{
    public interface IPictureModel
    {
        IPictureDef SelectedPictureDef { get; }

        void SelectPictureDef(IPictureDef pictureDef);
        
        void UnlockPicture(IPictureDef pictureDef);
        bool IsUnlockPicture(IPictureDef pictureDef);
    }
}