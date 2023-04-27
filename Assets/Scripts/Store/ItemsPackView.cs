using UnityEngine;

namespace Assets.Scripts.Store
{
    public class ItemsPackView : ItemView
    {
        public Transform ItemsParent => _parent;
        [SerializeField] private Transform _parent;

        public override void Init(ItemModel data)
        {
            _price.text = data.price.ToString();       
            _currency.text = data.currency;
            _key = data.key;
        }
    }
}
