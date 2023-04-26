using System.Collections.Generic;
using Assets.Scripts.DependencyInjection;

namespace Assets.Scripts.Core
{
    public class MainContainerBuilder : IContainerBuilder
    {
        private readonly List<ServiceDescriptor> _desciptors = new();

        public IContainer Build()
        {
            return new MainContainer(_desciptors);
        }

        public void Register(ServiceDescriptor descriptor)
        {
            _desciptors.Add(descriptor);
        }
    }
}
