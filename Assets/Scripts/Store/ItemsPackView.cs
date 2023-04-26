using UnityEngine;

namespace Assets.Scripts.Store
{
    public class ItemsPackView : ItemView
    {
        public Transform ItemsParent => _parent;
        [SerializeField] private Transform _parent;

        public override void Init(ItemModel model)
        {
            _price.text = model.price.ToString();       
            _currency.text = model.currency;
        }
    }
}
