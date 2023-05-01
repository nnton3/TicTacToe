using Assets.Scripts.DependencyInjection;
using Assets.Scripts.Services;
using Assets.Scripts.UI.NotificationWindow;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MainProjectContext : ProjectContext
    {
        [SerializeField] private LoadScreenService _loadScreen;
        [SerializeField] private ScreenBlockerService _screenBlocker;
        [SerializeField] private NotificationWindowView _notificationWindowView;

        protected override IContainer Setup()
        {
            IContainerBuilder builder = new MainContainerBuilder();
            builder
                .RegisterSingleton<ILoadScreenService>(_loadScreen)
                .RegisterSingleton<ISceneLoadService, SceneLoadService>()
                .RegisterSingleton<IScreenBlockerService>(_screenBlocker)
                .RegisterSingleton<INotificationWindowView>(_notificationWindowView)
                .RegisterSingleton<INotificationWindowService, NotificationWindowService>()
                ;
            
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
