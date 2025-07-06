namespace Project.Application.Domain.Abstraction
{
    public interface IPuzzleModel
    {
        int SelectedPieceCount { get; }

        void SelectPieceCount(int pieceCount);
    }
}