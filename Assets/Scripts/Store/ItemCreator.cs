using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Store
{
    public class ItemCreator : MonoBehaviour, IItemCreator
    {
        [SerializeField] private SingleItemCreator 
            _currencyItemCreator,
            _artifactItemCreator;
        [SerializeField] private ItemsPackCreator _packCreator;
        [SerializeField] private Transform _parent;
        private Dictionary<Type, Func<ItemModel, Transform, ItemView>> _creators;

        private void Awake()
        {
            _creators = new Dictionary<Type, Func<ItemModel, Transform, ItemView>>
            {
                { typeof(CurrencyItem), _currencyItemCreator.CreateItem },
                { typeof(ArtifactItem), _artifactItemCreator.CreateItem },
                { typeof(ItemsPack), _packCreator.CreateItem }
            };
        }

        public ItemView CreateItem(ItemModel itemData, Transform parent) => _creators[itemData.GetType()](itemData, parent);
    }
}
