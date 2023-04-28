using Assets.Scripts.Core;
using Assets.Scripts.DependencyInjection;
using Assets.Scripts.Store;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameplayContext : DependencyContext
    {
        [SerializeField] private CrossZeroSpawner _spawner;
        [SerializeField] private BoardView _boardView;

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
                .RegisterSingleton<IBoard, Board>()
                .RegisterMonoService<ICrossZeroSpawner>(_spawner)
                .RegisterMonoService<IBoardView>(_boardView)
                ;

            return builder.Build();
        }
    }
}
