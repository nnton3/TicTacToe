using System;

namespace Assets.Scripts.Core
{
    public class MainInjector : IInjector
    {
        private IContainer _container;

        public MainInjector(IContainer container)
        {
            _container = container;
        }

        public void Inject(object dependant)
        {
            Type type = dependant.GetType();
            var injectMethod = type.GetMethod("Inject");
            if (injectMethod != null)
            {
                var argsTypes = injectMethod.GetParameters();
                var argsValues = new object[argsTypes.Length];

                for (int i = 0; i < argsTypes.Length; i++)
                    argsValues[i] = _container.Resolve(argsTypes[i].ParameterType);

                injectMethod.Invoke(dependant, argsValues);
            }
        }
    }
}
