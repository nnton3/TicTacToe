using System.Collections;
using Assets.Scripts.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services
{
    public class LoadScreenService : MonoBehaviour, ILoadScreenService
    {
        public float AnimTime => _animTime;
        [SerializeField] private CanvasGroup _view;
        [SerializeField] private Image _backImg;
        [SerializeField] private TMP_Text _info;
        [SerializeField] private Slider _progressBar;
        private Coroutine _animRoutine;
        private readonly float _animTime;
        private bool _isVisible;
        private IProgressProcess _progressProcess;

        public void Inject(ISceneLoadService sceneLoader)
        {
            if (sceneLoader is IProgressProcess progressProcess)
                _progressProcess = progressProcess;
            else
                Debug.LogError($"Scene loader not implement IProgressProcess interface");
        }

        public void Show(SceneLoadConfig loadData)
        {
            if (_isVisible) return;
            _isVisible = true;

            if (_animRoutine != null)
                StopCoroutine(_animRoutine);

            _view.gameObject.SetActive(true);
            _backImg.sprite = loadData.Backs[0];
            _info.text = loadData.LoadTags[0];
            _animRoutine = StartCoroutine(ShowRoutine());
        }

        private IEnumerator ShowRoutine()
        {
            iTween.ValueTo(gameObject, iTween.Hash(
                "from", 0f,
                "to", 1f,
                "time", _animTime,
                "onupdate", "UpdateViewAlpha"));
            yield return new WaitForSeconds(_animTime);
            _animRoutine = null;
        }

        public void Hide()
        {
            if (!_isVisible) return;
            _isVisible = false;

            if (_animRoutine != null)
                StopCoroutine(_animRoutine);

            StartCoroutine(HideRoutine());
        }

        private IEnumerator HideRoutine()
        {
            iTween.ValueTo(gameObject, iTween.Hash(
                "from", 1f,
                "to", 0f,
                "time", _animTime,
                "onupdate", "UpdateViewAlpha"));
            yield return new WaitForSeconds(_animTime);
            _view.gameObject.SetActive(false);
            _animRoutine = null;
        }

        private void FixedUpdate()
        {
            if (_isVisible)
                _progressBar.value = _progressProcess.Progress;
        }

        //Tween anim
        private void UpdateViewAlpha(float value) => _view.alpha = value;
    }
}
