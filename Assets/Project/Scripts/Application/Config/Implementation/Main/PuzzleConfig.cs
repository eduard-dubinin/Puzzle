using System.Collections.Generic;
using Project.Application.Config.Abstraction;
using UnityEngine;

namespace Project.Application.Config.Implementation
{
    [CreateAssetMenu(fileName = nameof(PuzzleConfig), menuName = "Project/Config/" + nameof(PuzzleConfig))]
    public class PuzzleConfig : ScriptableObject, IPuzzleConfig
    {
        [SerializeField] private int[] _piecesCount;

        public IReadOnlyList<int> PiecesCount => _piecesCount;
    }
}