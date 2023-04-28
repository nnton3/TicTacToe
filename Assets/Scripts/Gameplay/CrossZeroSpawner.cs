using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay
{
    public class CrossZeroSpawner : MonoBehaviour, ICrossZeroSpawner
    {
        [SerializeField] private Image[] _placeImgs;
        [SerializeField] private Sprite[] _crossSprites, _zeroSprites;
        private Sprite _crossSprite => _crossSprites[Random.Range(0, _crossSprites.Length)];
        private Sprite _zeroSprite => _zeroSprites[Random.Range(0, _zeroSprites.Length)];

        public void Spawn(Vector2Int position, FigureType type)
        {
            var index = position.y * 3 + position.x;
            _placeImgs[index].color = Color.white;
            _placeImgs[index].sprite = (type == FigureType.Cross) ? _crossSprite : _zeroSprite;
        }
    }
}
