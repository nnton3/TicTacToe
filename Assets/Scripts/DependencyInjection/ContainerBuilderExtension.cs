using System;

namespace Assets.Scripts.DependencyInjection
{
    public static class ContainerBuilderExtension
    {
        private static IContainerBuilder RegisterType(IContainerBuilder builder, Type serviceInterface, Type serviceImplementation)
        {
            builder.Register(new TypeBaseServiceDescriptor
            {
                ImplementationType = serviceImplementation,
                ServiceType = serviceInterface,
            });
            return builder;
        }

        public static IContainerBuilder RegisterSingleton<IService, IImplementation>(this IContainerBuilder builder) where IImplementation : IService =>
            RegisterType(builder, typeof(IService), typeof(IImplementation));

        public static IContainerBuilder RegisterTransient<IService, IImplementation>(this IContainerBuilder builder) where IImplementation : IService =>
            RegisterType(builder, typeof(IService), typeof(IImplementation));

        private static IContainerBuilder RegisterMonoInstance(this IContainerBuilder builder, Type service, object instance)
        {
            builder.Register(new MonoServiceDescriptor(service, instance));
            return builder;
        }

        public static IContainerBuilder RegisterMonoService<IService>(this IContainerBuilder builder, object instance) =>
            RegisterMonoInstance(builder, typeof(IService), instance);

        public static IContainerBuilder RegistryContainer(this IContainerBuilder builder, IContainer container)
        {
            foreach (var d in container.Descriptors.Values)
                builder.Register(d);
            return builder;
        }
    }
}
