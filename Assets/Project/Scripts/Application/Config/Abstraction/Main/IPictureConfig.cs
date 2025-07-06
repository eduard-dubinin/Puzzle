using System.Collections.Generic;

namespace Project.Application.Config.Abstraction
{
    public interface IPictureConfig
    {
        IReadOnlyList<IPictureDef> AllPictureDefs { get; }
    }
}