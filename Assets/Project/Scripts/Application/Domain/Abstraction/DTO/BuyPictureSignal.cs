using Project.Application.Config.Abstraction;

namespace Project.Application.Domain.Abstraction
{
    public struct BuyPictureSignal
    {
        public IPictureDef PictureDef { get; }

        public BuyPictureSignal(IPictureDef pictureDef)
        {
            PictureDef = pictureDef;
        }
    }
}