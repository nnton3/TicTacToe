using Assets.Scripts.Core;
using Assets.Scripts.DependencyInjection;
using Assets.Scripts.Store;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class MainMenuSceneContext : DependencyContext
    {
        [SerializeField] private ItemCreator _storeItemCreator;

        protected override void Inject(IContainer container)
        {
            var injector = new MainInjector(container);
            foreach (var component in GetComponentsInChildren<MonoBehaviour>())
                injector.Inject(component);
        }

        protected override IContainer Setup()
        {
            IContainerBuilder builder = new MainContainerBuilder();
            builder
                .RegistryContainer(ProjectContext.Container)
                .RegisterTransient<IStoreItemsProvider, MockStoreItemsProvider>()
                .RegisterSingetone<IItemCreator>(_storeItemCreator);

            return builder.Build();
        }
    }
}
