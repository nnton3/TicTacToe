using Assets.Scripts.Configs;

namespace Assets.Scripts.Services
{
    public interface ILoadScreenService
    {
        public float AnimTime { get; }
        void Show(SceneLoadConfig loadData);
        void Hide();
    }
}
