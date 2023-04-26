using UnityEngine;

namespace Assets.Scripts.Services
{
    public class ScreenBlockerService : MonoBehaviour, IScreenBlockerService
    {
        [SerializeField] private GameObject _view;

        public void Show()
        {
            _view.SetActive(true);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }
    }
}
