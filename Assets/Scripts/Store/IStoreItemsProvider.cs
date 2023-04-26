using System;

namespace Assets.Scripts.Store
{
    public interface IStoreItemsProvider
    {
        void GetItems(Action<StoreModel> onComplete, Action onFail);
    }
}
