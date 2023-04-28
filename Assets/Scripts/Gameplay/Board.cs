using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class Board : IBoard
    {
        private Dictionary<Vector2Int, FigureType> _places;
        private ICrossZeroSpawner _spawner;
        private readonly int _boardSize = 9, _lineSize = 3;

        public Board()
        {
            _places = new Dictionary<Vector2Int, FigureType>(_boardSize);
            for (int i = 0; i < _boardSize; i++)
            {
                var pos = new Vector2Int(i % _lineSize, i / _lineSize);
                _places.Add(pos, FigureType.None);
            }
        }

        public void Inject(ICrossZeroSpawner spawner)
        {
            _spawner = spawner;
        }

        public void FillPlace(Vector2Int pos, FigureType type)
        {
            _places[pos] = type;
            _spawner.Spawn(pos, type);
        }

        public bool IsPlaceFree(Vector2Int pos) => _places[pos] == FigureType.None;
        public Vector2Int GetFreePosition() => _places.First(p => p.Value == FigureType.None).Key;
    }
}
