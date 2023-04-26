using System;

namespace Assets.Scripts.DependencyInjection
{
    public class ProjectContext : DependencyContext
    {
        public static IContainer Container => _container;
        private static IContainer _container;

        protected override void Awake()
        {
            DontDestroyOnLoad(this);
            _container = Setup();
            Inject(_container);
        }

        protected override IContainer Setup() { throw new InvalidOperationException($"Don't use base class like an instance"); }
        protected override void Inject(IContainer container) { throw new InvalidOperationException($"Don't use base class like an instance"); }
    }
}