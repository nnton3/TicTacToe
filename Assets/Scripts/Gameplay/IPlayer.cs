using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public interface IPlayer
    {
        bool IsActive { get; }
        FigureType FigureType { get; }
        event EventHandler<Vector2Int> OnTurnEnd;

        void StartTurn();
        void SetFigure(FigureType figureType);
    }
}
