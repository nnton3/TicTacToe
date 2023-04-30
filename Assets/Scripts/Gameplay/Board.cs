using System.Collections.Immutable;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class Board : IBoard
    {
        public FigureType[][] PlacesMatrix => _placesMatrix;
        private FigureType[][] _placesMatrix;
        private ICrossZeroSpawner _spawner;
        private readonly int _lineSize = 3;

        public Board()
        {
            _placesMatrix = new FigureType[_lineSize][];
            for (int i = 0; i < _lineSize; i++)
            {
                _placesMatrix[i] = new FigureType[_lineSize]; 
                for (int j = 0; j < _lineSize; j++)
                    _placesMatrix[i][j] = FigureType.None;
            }
        }

        public void Inject(ICrossZeroSpawner spawner)
        {
            _spawner = spawner;
        }

        public void FillPlace(Vector2Int pos, FigureType type)
        {
            _placesMatrix[pos.x][pos.y] = type;
            _spawner.Spawn(pos, type);
        }

        public bool IsPlaceFree(Vector2Int pos) => _placesMatrix[pos.x][pos.y] == FigureType.None;
        
        public Vector2Int GetFreePosition()
        {
            for (int i = 0; i < _lineSize; i++)
                for (int j = 0; j < _lineSize; j++)
                    if (_placesMatrix[i][j] == FigureType.None)
                        return new Vector2Int(i, j);

            return new Vector2Int(-1, -1);
        }
    }
}
