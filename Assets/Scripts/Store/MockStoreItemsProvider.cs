using System;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Assets.Scripts.PlayerResources;
using System.Collections.Generic;

namespace Assets.Scripts.Store
{
    public class MockStoreItemsProvider : IStoreItemsProvider
    {
        public async void LoadItems(Action<StoreModel> onComplete, Action onFail)
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

        private static void SerializationTest()
        {
            var testModel = new StoreModel
            {
                shopItems = new List<ItemModel>
                {
                    new ItemsPack
                    {
                        currency = "$",
                        key = "pack",
                        price = 10.99f,
                        items = new List<ItemModel>
                        {
                            new CurrencyItem
                            {
                                amount = 10,
                                currency = "$",
                                key = "gold",
                                price = 1.29f
                            },
                            new ArtifactItem
                            {
                                price = 5.0f,
                                key = "sword",
                                currency = "$",
                                stats = new Dictionary<PlayerStat, int>
                                {
                                    { PlayerStat.Damage, 10 }
                                }
                            }
                        }
                    }
                }
            };

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(testModel, settings);
            var storeModel = JsonConvert.DeserializeObject<StoreModel>(json, settings);
        }
    }
}
