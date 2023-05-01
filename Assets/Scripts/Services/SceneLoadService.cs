using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services
{
    public class SceneLoadService : ISceneLoadService, IProgressProcess
    {
        public float Progress => _progress;
        private float _progress;
        private ILoadScreenService _loadScreenService;
        private readonly float _minLoadTime = 0.5f;

        public void Inject(ILoadScreenService loadScreenService)
        {
            _loadScreenService = loadScreenService;
        }

        public void LoadScene(SceneLoadConfig loadData)
        {
            LoadSceneAsync(loadData);
        }

        private async void LoadSceneAsync(SceneLoadConfig loadData)
        {
            _loadScreenService.Show(loadData);
            var startTime = Time.time;  
            float leftTime = 0f;
            await Task.Delay((int)(_loadScreenService.AnimTime * 1000));

            _progress = 0f;
            var loadTask = SceneManager.LoadSceneAsync(loadData.SceneName);

            while (!loadTask.isDone || leftTime < _minLoadTime)
            {
                leftTime = Time.time - startTime;
                var lazyProgress = leftTime / _minLoadTime;
                var realProgress = loadTask.progress;
                _progress = Mathf.Min(lazyProgress, realProgress);
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }
            _loadScreenService.Hide();
        }
    }
}
