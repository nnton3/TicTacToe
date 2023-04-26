using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Store
{
    public class ItemCreator : MonoBehaviour, IItemCreator
    {
        [SerializeField] private CurrencyItemCreator _currencyItemCreator;
        [SerializeField] private Transform _parent;
        private Dictionary<Type, Func<ItemModel, ItemView>> _creators;

        private void Awake()
        {
            _creators = new Dictionary<Type, Func<ItemModel, ItemView>>
            {
                { typeof(CurrencyItem), _currencyItemCreator.CreateItem }
            };
        }

        public ItemView CreateItem(ItemModel itemData) => _creators[itemData.GetType()](itemData);
    }
}
