using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public interface IWinConditionChecker
    {
        bool IsWinConditionAchived(Vector2Int lastTurn);
    }
}
