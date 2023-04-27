using System;

namespace Assets.Scripts.Store
{
    public interface IStoreItemsProvider
    {
        void LoadItems(Action<StoreModel> onComplete, Action onFail);
    }
}
