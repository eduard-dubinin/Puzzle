using Project.Application.Config.Abstraction;

namespace Project.Application.Domain.Abstraction
{
    public struct UnlockPictureSignal
    {
        public IPictureDef PictureDef { get; }

        public UnlockPictureSignal(IPictureDef pictureDef)
        {
            PictureDef = pictureDef;
        }
    }
}