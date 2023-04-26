using System;

namespace Assets.Scripts.DependencyInjection
{
    public abstract class ServiceDescriptor
    {
        public Type ServiceType { get; set; }
    }

    public class MonoServiceDescriptor : ServiceDescriptor
    {
        public object Instance { get; set; }

        public MonoServiceDescriptor(Type serviceType, object instance)
        {
            ServiceType = serviceType;
            Instance = instance;
        }
    }

    public class TypeBaseServiceDescriptor : ServiceDescriptor
    {
        public Type ImplementationType { get; set; }
    }
}
