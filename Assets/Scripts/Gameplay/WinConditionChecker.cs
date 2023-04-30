using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class WinConditionChecker : IWinConditionChecker
    {
        private IBoard _board;
        private readonly int _lineSize = 3;

        public void Inject(IBoard board)
        {
            _board = board;
        }

        public bool IsWinConditionAchived(Vector2Int lastTurn)
        {
            var placesInfo = _board.PlacesMatrix;

            //Check line
            var tmpFigure = placesInfo[lastTurn.x][lastTurn.y];
            if (CheckRowsCols(tmpFigure, placesInfo) || CheckDiagonal(tmpFigure, placesInfo))
                return true;

            return false;    
        }

        private bool CheckRowsCols(FigureType figure, FigureType[][] places)
        {
            for (int col = 0; col < _lineSize; col++)
            {
                bool cols = true;
                bool rows = true;
                for (int row = 0; row < _lineSize; row++)
                {
                    if (places[col][row] != figure) cols = false;
                    if (places[row][col] != figure) rows = false;
                }

                if (cols || rows) 
                    return true;
            }

            return false;
        }

        private bool CheckDiagonal(FigureType figure, FigureType[][] places)
        {
            var toRight = true;
            var toLeft = true;

            for (int i = 0; i < _lineSize; i++)
            {
                if (places[i][i] != figure) toRight = false;
                if (places[_lineSize - i - 1][i] != figure) toLeft = false;
            }

            return toRight || toLeft;
        }
    }
}
