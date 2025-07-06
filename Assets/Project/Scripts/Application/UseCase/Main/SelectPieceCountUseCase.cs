using System;
using System.Linq;
using Project.Application.Config.Abstraction;
using Project.Application.Domain.Abstraction;
using Zenject;

namespace Project.Application.UseCase
{
    public class SelectPieceCountUseCase : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IPuzzleModel _puzzleModel;
        private readonly IPuzzleConfig _puzzleConfig;

        public SelectPieceCountUseCase(SignalBus signalBus, IPuzzleModel puzzleModel,
            IPuzzleConfig puzzleConfig)
        {
            _signalBus = signalBus;
            _puzzleModel = puzzleModel;
            _puzzleConfig = puzzleConfig;
        }

        public void Initialize()
        {
            _puzzleModel.SelectPieceCount(_puzzleConfig.PiecesCount.First());
            _signalBus.Subscribe<SelectPieceCountSignal>(SelectPieceCountSignalHandler);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SelectPieceCountSignal>(SelectPieceCountSignalHandler);
        }

        private void SelectPieceCountSignalHandler(SelectPieceCountSignal signal)
        {
            _puzzleModel.SelectPieceCount(signal.SelectedPieceCount);
        }
    }
}