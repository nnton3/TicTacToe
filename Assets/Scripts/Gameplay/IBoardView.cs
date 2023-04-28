using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public interface IBoardView
    {
        event EventHandler<Vector2Int> OnSelectPlace;
    }
}
