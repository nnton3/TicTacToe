using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class HumanPlayer : IPlayer, IDisposable
    {
        public bool IsActive => _isActive;
        public FigureType FigureType => _figureType;
        public event EventHandler<Vector2Int> OnTurnEnd;
        private bool _isActive;
        private IBoard _board;
        private IBoardView _boardView;
        private FigureType _figureType;

        public HumanPlayer(IBoard board, IBoardView boardView)
        {
            _board = board;
            _boardView = boardView;
            _boardView.OnSelectPlace += SelectPlaceHandler;
        }

        private async void SelectPlaceHandler(object sender, Vector2Int pos)
        {
            if (!IsActive) return;
            if (!_board.IsPlaceFree(pos)) return;

            _isActive = false;
            _board.FillPlace(pos, _figureType);

            await Task.Delay(500);

            OnTurnEnd?.Invoke(this, pos);
        }

        public void StartTurn()
        {
            _isActive = true;
        }

        public void SetFigure(FigureType figureType) => _figureType = figureType;

        public void Dispose()
        {
            _boardView.OnSelectPlace -= SelectPlaceHandler;
        }
    }
}
