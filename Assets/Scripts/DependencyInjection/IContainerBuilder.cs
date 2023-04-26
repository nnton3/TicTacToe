using Assets.Scripts.DependencyInjection;

namespace Assets.Scripts
{
    public interface IContainerBuilder
    {
        void Register(ServiceDescriptor descriptor);
        IContainer Build();
    }
}
