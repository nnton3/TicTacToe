using System;

namespace Assets.Scripts.Gameplay
{
    public class AIPlayer : IPlayer
    {
        public event EventHandler OnTurnEnd;
        public bool IsActive => _isActive;
        private bool _isActive;
        private FigureType _figureType;

        public void StartTurn()
        {
            
        }

        public void SetFigure(FigureType figureType) => figureType = _figureType;
    }
}
