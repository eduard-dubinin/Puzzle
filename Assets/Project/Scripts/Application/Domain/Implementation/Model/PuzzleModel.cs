using Project.Application.Domain.Abstraction;

namespace Project.Application.Domain.Implementation
{
    public class PuzzleModel : IPuzzleModel
    {
        public int SelectedPieceCount { get; private set; }

        public void SelectPieceCount(int pieceCount)
        {
            SelectedPieceCount = pieceCount;
        }
    }
}