using Assets.Scripts.DependencyInjection;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MainProjectContext : ProjectContext
    {
        [SerializeField] private LoadScreenService _loadScreen;
        [SerializeField] private SceneLoadService _sceneLoader;
        [SerializeField] private ScreenBlockerService _screenBlocker;

        protected override IContainer Setup()
        {
            IContainerBuilder builder = new MainContainerBuilder();
            builder
                .RegisterSingetone<ILoadScreenService>(_loadScreen)
                .RegisterSingetone<ISceneLoadService>(_sceneLoader)
                .RegisterSingetone<IScreenBlockerService>(_screenBlocker);
            
            return builder.Build();
        }

        protected override void Inject(IContainer container)
        {
            var injector = new MainInjector(container);
            foreach (var component in GetComponentsInChildren<MonoBehaviour>())
                injector.Inject(component);
        }
    }
}
