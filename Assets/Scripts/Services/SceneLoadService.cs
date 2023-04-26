using System.Collections;
using Assets.Scripts.Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services
{
    public class SceneLoadService : MonoBehaviour, ISceneLoadService, IProgressProcess
    {
        public float Progress => _progress;
        private float _progress;
        private ILoadScreenService _loadScreenService;
        private Coroutine _loadCoroutine;
        private readonly float _minLoadTime = 0.5f;

        public void Inject(ILoadScreenService loadScreenService)
        {
            _loadScreenService = loadScreenService;
        }

        public void LoadScene(SceneLoadConfig loadData)
        {
            _loadCoroutine = StartCoroutine(LoadSceneAsync(loadData));
        }

        private IEnumerator LoadSceneAsync(SceneLoadConfig loadData)
        {
            _loadScreenService.Show(loadData);
            var startTime = Time.time;  
            float leftTime = 0f;
            yield return new WaitForSeconds(_loadScreenService.AnimTime);

            _progress = 0f;
            var loadTask = SceneManager.LoadSceneAsync(loadData.SceneName);

            while (!loadTask.isDone || leftTime < _minLoadTime)
            {
                leftTime = Time.time - startTime;
                var lazyProgress = leftTime / _minLoadTime;
                var realProgress = loadTask.progress;
                _progress = Mathf.Min(lazyProgress, realProgress);
                yield return null;
            }
            _loadScreenService.Hide();
            _loadCoroutine = null;
        }
    }
}
