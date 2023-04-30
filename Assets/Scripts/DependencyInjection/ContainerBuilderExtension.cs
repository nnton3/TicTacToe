using System;

namespace Assets.Scripts.DependencyInjection
{
    public static class ContainerBuilderExtension
    {
        private static IContainerBuilder RegisterTransientType(IContainerBuilder builder, Type serviceType, Type serviceImplementation)
        {
            builder.Register(new TypeBaseServiceDescriptor(
                serviceType,
                serviceImplementation,
                false
                ));
            return builder;
        }

        public static IContainerBuilder RegisterTransient<IService, IImplementation>(this IContainerBuilder builder) where IImplementation : IService =>
            RegisterTransientType(builder, typeof(IService), typeof(IImplementation));

        private static IContainerBuilder RegisterSingletoneType(IContainerBuilder builder, Type serviceType, object instance)
        {
            builder.Register(new TypeBaseServiceDescriptor(
                serviceType,
                instance,
                true
            ));
            return builder;
        }

        public static IContainerBuilder RegisterSingleton<IService, IImplementation>(this IContainerBuilder builder) where IImplementation : IService
        {
            builder.Register(new TypeBaseServiceDescriptor(
                typeof(IService), 
                typeof(IImplementation),
                true
            ));
            return builder;
        }

        public static IContainerBuilder RegisterSingetone<IService>(this IContainerBuilder builder, object instance) =>
            RegisterSingletoneType(builder, typeof(IService), instance);

        public static IContainerBuilder RegistryContainer(this IContainerBuilder builder, IContainer container)
        {
            foreach (var d in container.Descriptors.Values)
                builder.Register(d);
            return builder;
        }
    }
}
