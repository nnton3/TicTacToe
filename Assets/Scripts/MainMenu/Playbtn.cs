using Assets.Scripts.Configs;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MainMenu
{
    public class Playbtn : MonoBehaviour
    {
        [SerializeField] private SceneLoadConfig _gameplaySceneConfig;
        private ISceneLoadService _sceneLoader;
        private Button _btn;

        public void Inject(ISceneLoadService sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            _sceneLoader.LoadScene(_gameplaySceneConfig);
        }
    }
}