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

            if (descriptor is MonoServiceDescriptor msd)
                return msd.Instance;

            var tb = (TypeBaseServiceDescriptor)descriptor;

            var instance = Activator.CreateInstance(tb.ImplementationType);
            var injectMethod = tb.ImplementationType.GetMethod("Inject");
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
