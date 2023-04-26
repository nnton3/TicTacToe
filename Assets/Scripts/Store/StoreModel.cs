using System;
using System.Collections.Generic;

namespace Assets.Scripts.Store
{
    [Serializable]
    public class StoreModel
    {
        public List<ItemModel> shopItems;
    }

    [Serializable]
    public class SameStoreModel
    {
        public List<string> shopItems;
    }
}
