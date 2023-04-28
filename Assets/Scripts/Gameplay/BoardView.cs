using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay
{
    public class BoardView : MonoBehaviour, IBoardView
    {
        public event EventHandler<Vector2Int> OnSelectPlace;
        [SerializeField] private Button[] _btns;
        private readonly int _boardSize = 9, _lineSize = 3;

        private void Awake()
        {
            for (int i = 0; i < _boardSize; i++)
            {
                var index = i;
                var pos = new Vector2Int(i % _lineSize, i / _lineSize);
                _btns[index].onClick.AddListener(() => OnSelectPlace?.Invoke(_btns[index], pos));
            }
        }
    }
}
