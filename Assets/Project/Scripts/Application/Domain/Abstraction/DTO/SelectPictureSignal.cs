using Project.Application.Config.Abstraction;

namespace Project.Application.Domain.Abstraction
{
    public struct SelectPictureSignal
    {
        public IPictureDef SelectedPictureDef { get; }

        public SelectPictureSignal(IPictureDef selectedPictureDef)
        {
            SelectedPictureDef = selectedPictureDef;
        }
    }
}