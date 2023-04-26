using Assets.Scripts.Configs;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class StartApp : MonoBehaviour
    {
        [SerializeField] private SceneLoadConfig _startSceneConfig;
        private ISceneLoadService _sceneLoader;

        public void Inject(ISceneLoadService sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        void Start()
        {
            _sceneLoader.LoadScene(_startSceneConfig);
        }
    }
}