using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.Application.Config.Abstraction;
using Project.Application.Domain.Abstraction;
using Project.Application.Network.Abstraction;
using Project.Meta.UI.View;
using Zenject;

namespace Project.Meta.UI.Presenter
{
    public class PictureScrollPresenter : IInitializable, IDisposable
    {
        private readonly PictureScrollView _pictureScrollView;
        private readonly IPictureConfig _pictureConfig;
        private readonly SignalBus _signalBus;
        private readonly IPictureProvider _pictureProvider;
        private readonly IPictureModel _pictureModel;

        private readonly Dictionary<IPictureDef, PictureScrollCellView> _cellViewByPictureDefs = new();

        public PictureScrollPresenter(PictureScrollView pictureScrollView,
            IPictureConfig pictureConfig,
            SignalBus signalBus,
            IPictureProvider pictureProvider,
            IPictureModel pictureModel)
        {
            _pictureScrollView = pictureScrollView;
            _pictureConfig = pictureConfig;
            _signalBus = signalBus;
            _pictureProvider = pictureProvider;
            _pictureModel = pictureModel;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ExitCoreSignal>(ExitCoreSignalHandler);
            _signalBus.Subscribe<UnlockPictureSignal>(UnlockPictureSignalHandler);

            foreach (var pictureDef in _pictureConfig.AllPictureDefs)
            {
                var cellView = _pictureScrollView.GetCellView();
                _cellViewByPictureDefs.Add(pictureDef, cellView);

                cellView.SetTitle(pictureDef.Title);
                cellView.SetTags(pictureDef.Tags);
                UpdateCellLockedText(cellView, pictureDef);

                cellView.SelectButton.onClick.AddListener(() =>
                {
                    _signalBus.Fire(new SelectPictureSignal(pictureDef));
                });

                _pictureProvider
                    .LoadPreviewSprite(pictureDef, previewSprite => { cellView.SetPreviewImage(previewSprite); })
                    .Forget();
            }
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ExitCoreSignal>(ExitCoreSignalHandler);
            _signalBus.Unsubscribe<UnlockPictureSignal>(UnlockPictureSignalHandler);

            foreach (var cellView in _pictureScrollView.CellViews)
            {
                cellView.SelectButton.onClick.RemoveAllListeners();
            }
            
            _cellViewByPictureDefs.Clear();
        }

        private void ExitCoreSignalHandler(ExitCoreSignal signal)
        {
            _pictureScrollView.ResetScrollPosition();
        }

        private void UnlockPictureSignalHandler(UnlockPictureSignal signal)
        {
            var cellView = _cellViewByPictureDefs[signal.PictureDef];
            UpdateCellLockedText(cellView, signal.PictureDef);
        }

        private void UpdateCellLockedText(PictureScrollCellView cellView, IPictureDef pictureDef)
        {
            if (_pictureModel.IsUnlockPicture(pictureDef))
            {
                cellView.SetUnlockText();
            }
            else
            {
                cellView.SetLockedText(pictureDef.PriceGold);
            }
        }
    }
}