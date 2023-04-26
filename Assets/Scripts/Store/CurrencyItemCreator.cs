using UnityEngine;

namespace Assets.Scripts.Store
{
    public class CurrencyItemCreator : MonoBehaviour, IItemCreator
    {
        [SerializeField] private GameObject _pref;
        [SerializeField] private Transform _parent;

        public ItemView CreateItem(ItemModel itemData)
        {
            var instance = Instantiate(_pref, _parent);
            var view = instance.GetComponent<CurrencyItemView>();
            view.Init(itemData);
            return view;
        }
    }
}
