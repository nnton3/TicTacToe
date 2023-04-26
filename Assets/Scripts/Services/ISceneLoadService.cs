using Assets.Scripts.Configs;

namespace Assets.Scripts.Services
{
    public interface ISceneLoadService
    {
        public void LoadScene(SceneLoadConfig sceneName);
    }
}
