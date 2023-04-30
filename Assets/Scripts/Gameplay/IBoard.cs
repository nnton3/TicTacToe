using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public interface IBoard
    {
        FigureType[][] PlacesMatrix { get; }
        void FillPlace(Vector2Int pos, FigureType type);
        bool IsPlaceFree(Vector2Int pos);
    }
}
