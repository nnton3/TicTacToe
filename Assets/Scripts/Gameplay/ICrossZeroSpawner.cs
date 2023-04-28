using UnityEngine;

public enum FigureType { None, Cross, Zero }

public interface ICrossZeroSpawner
{
    void Spawn(Vector2Int position, FigureType type);
}
