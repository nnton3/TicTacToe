using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DependencyInjection;

namespace Assets.Scripts.Core
{
    public class MainContainer : IContainer
    {
        public Dictionary<Type, ServiceDescriptor> Descriptors => _descriptors; //TODO: Remove access to descriptors
        private readonly Dictionary<Type, ServiceDescriptor> _descriptors;

        public MainContainer(IEnumerable<ServiceDescriptor> descriptors)
        {
            _descriptors = descriptors.ToDictionary(x => x.ServiceType);
        }

        public object Resolve(Type service)
        {
            if (!_descriptors.TryGetValue(service, out var descriptor))
                throw new InvalidOperationException($"Service {service} is not registered");

            var td = descriptor as TypeBaseServiceDescriptor;

            if (td.IsSingletone)
            {
                if (td.Instance == null)
                    td.Instance = CreateInstance(td.ImplementationType);
                return td.Instance;
            }
            else
            {
                return CreateInstance(td.ImplementationType);
            }
        }

        private object CreateInstance(Type instanceType)
        {
            var instance = Activator.CreateInstance(instanceType);
            var injectMethod = instanceType.GetMethod("Inject");
            if (injectMethod != null)
            {
                var args = injectMethod.GetParameters();
                var argsMethod = new object[args.Length];
                for (int i = 0; i < args.Length; i++)
                    argsMethod[i] = Resolve(args[i].ParameterType);

                injectMethod.Invoke(instance, argsMethod);
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
