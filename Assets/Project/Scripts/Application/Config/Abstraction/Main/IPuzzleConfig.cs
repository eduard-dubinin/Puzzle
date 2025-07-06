using System.Collections.Generic;

namespace Project.Application.Config.Abstraction
{
    public interface IPuzzleConfig
    {
        IReadOnlyList<int> PiecesCount { get; }
    }
}