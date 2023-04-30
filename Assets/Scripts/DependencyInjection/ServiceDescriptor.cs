using System;

namespace Assets.Scripts.DependencyInjection
{

    public abstract class ServiceDescriptor
    {
        public Type ServiceType { get; set; }
    }

    public class TypeBaseServiceDescriptor : ServiceDescriptor
    {
        public Type ImplementationType { get; }
        public object Instance { get; set; }
        public bool IsSingletone { get; }

        public TypeBaseServiceDescriptor(Type serviceType, Type serviceImplementation, bool isSingletone)
        {
            ServiceType = serviceType;
            ImplementationType = serviceImplementation;
            IsSingletone = isSingletone;
        }

        public TypeBaseServiceDescriptor(Type serviceType, object instance, bool isSingletone)
        {
            ServiceType = serviceType;
            Instance = instance;
            IsSingletone = isSingletone;
        }
    }
}
