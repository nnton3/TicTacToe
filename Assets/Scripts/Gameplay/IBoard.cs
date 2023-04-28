using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public interface IBoard
    {
        void FillPlace(Vector2Int pos, FigureType type);
        bool IsPlaceFree(Vector2Int pos);
    }
}
