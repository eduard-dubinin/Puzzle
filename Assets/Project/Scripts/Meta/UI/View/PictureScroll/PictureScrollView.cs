using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Meta.UI.View
{
    public class PictureScrollView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _content;
        [SerializeField] private PictureScrollCellView _cellPrefab;

        public IReadOnlyList<PictureScrollCellView> CellViews => _cells;

        private readonly List<PictureScrollCellView> _cells = new();

        public PictureScrollCellView GetCellView()
        {
            var cell = Instantiate(_cellPrefab, _content.transform);
            _cells.Add(cell);

            return cell;
        }

        public void ResetScrollPosition()
        {
            _scrollRect.verticalNormalizedPosition = 1f;
        }
    }
}