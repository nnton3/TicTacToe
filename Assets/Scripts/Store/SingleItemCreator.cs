using UnityEngine;

namespace Assets.Scripts.Store
{
    public class SingleItemCreator : MonoBehaviour, IItemCreator
    {
        [SerializeField] private GameObject _pref;

        public ItemView CreateItem(ItemModel itemData, Transform parent)
        {
            var instance = Instantiate(_pref, parent);
            var view = instance.GetComponent<ItemView>();
            view.Init(itemData);
            return view;
        }
    }
}
