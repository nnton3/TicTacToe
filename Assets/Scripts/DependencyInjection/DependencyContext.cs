using UnityEngine;

namespace Assets.Scripts.DependencyInjection
{
    public abstract class DependencyContext : MonoBehaviour
    {
        protected virtual void Awake()
        {
            var container = Setup();
            Inject(container);
        }

        protected abstract IContainer Setup();
        protected abstract void Inject(IContainer container);
    }
}
