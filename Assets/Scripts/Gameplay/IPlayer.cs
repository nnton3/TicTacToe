using System;

namespace Assets.Scripts.Gameplay
{
    public interface IPlayer
    {
        bool IsActive { get; }
        event EventHandler OnTurnEnd;

        void StartTurn();
        void SetFigure(FigureType figureType);
    }
}
