using System;
using Assets.Scripts.DependencyInjection;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public interface IContainer
    {
        public Dictionary<Type, ServiceDescriptor> Descriptors { get; }
        public object Resolve(Type service);
    }
}
