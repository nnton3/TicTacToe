using System;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace Assets.Scripts.Store
{
    public class MockStoreItemsProvider : IStoreItemsProvider
    {
        public async void GetItems(Action<StoreModel> onComplete, Action onFail)
        {
            await Task.Delay(1000);

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = Resources.Load<TextAsset>("storeModel");
            var storeModel = JsonConvert.DeserializeObject<StoreModel>(json.text, settings);

            if (storeModel == null)
                onFail?.Invoke();
            else
                onComplete?.Invoke(storeModel);
        }
    }
}
