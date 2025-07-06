namespace Project.Application.Domain.Abstraction
{
    public struct SelectPieceCountSignal
    {
        public int SelectedPieceCount { get; }

        public SelectPieceCountSignal(int selectedPieceCount)
        {
            SelectedPieceCount = selectedPieceCount;
        }
    }
}